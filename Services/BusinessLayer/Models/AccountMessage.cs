﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AccountMessage
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Phone { get; set; }
        public string Credits { get; set; }
        public string Description { get; set; }
    }
}
