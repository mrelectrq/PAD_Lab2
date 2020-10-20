using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class ConsistentHash<T>
    {
        SortedDictionary<int, T> circle = new SortedDictionary<int, T>();

        // Default value for nodes limits to add
        int _replicate = 100;    
        //For caching nodes
        int[] ayKeys = null;     

        public void Init(IEnumerable<T> nodes)
        {
            Init(nodes, _replicate);
        }

        //Initialization 
        public void Init(IEnumerable<T> nodes, int replicate)
        {
            _replicate = replicate;

            foreach (T node in nodes)
            {
                this.Add(node, false);
            }
            ayKeys = circle.Keys.ToArray();
        }

        //Add Node Method with updated Key true
        public void Add(T node)
        {
            Add(node, true);
        }

        // Add Node Method
        private void Add(T node, bool updateKeyArray)
        {
            for (int i = 0; i < _replicate; i++)
            {
                int hash = Hash(node.GetHashCode().ToString() + i);
                circle[hash] = node;
            }

            if (updateKeyArray)
            {
                ayKeys = circle.Keys.ToArray();
            }
        }

        // Remove Node
        public void Remove(T node)
        {
            for (int i = 0; i < _replicate; i++)
            {
                int hash = Hash(node.GetHashCode().ToString() + i);
                if (!circle.Remove(hash))
                {
                    throw new Exception("Error! Can't remove a node that wasn't added.");
                }
            }
            ayKeys = circle.Keys.ToArray();
        }

        // Determination of First key 
        int FirstKey(int[] ay, int val)
        {
            int begin = 0;
            int end = ay.Length - 1;

            if (ay[end] < val || ay[0] > val)
            {
                return 0;
            }

            int mid = begin;
            while (end - begin > 1)
            {
                mid = (end + begin) / 2;
                if (ay[mid] >= val)
                {
                    end = mid;
                }
                else
                {
                    begin = mid;
                }
            }

            if (ay[begin] > val || ay[end] < val)
            {
                throw new Exception("Error! Can't determine first key.");
            }

            return end;
        }

        // Get Node Method
        public T GetNode(String key)
        { 

            int hash = Hash(key);

            int first = FirstKey(ayKeys, hash);

            return circle[ayKeys[first]];
        }

        // Hashing Nodes
        public static int Hash(String key)
        {
            uint hash = MurmurHash2.Hash(Encoding.ASCII.GetBytes(key));
            return (int)hash;
        }

    }
}
