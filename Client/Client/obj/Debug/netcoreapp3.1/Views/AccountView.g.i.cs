﻿#pragma checksum "..\..\..\..\Views\AccountView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1BB9E7BBE7990FA1D925CF03A160CCE376F79D3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Client.Views {
    
    
    /// <summary>
    /// AccountView
    /// </summary>
    public partial class AccountView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Accountid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Lastname;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AccountIDResp;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameResp;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox date;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameResp;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Balance;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Phoneresp;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox credits;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\AccountView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageResp;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;component/views/accountview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\AccountView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\..\Views\AccountView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Accountid = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.firstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Lastname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 22 "..\..\..\..\Views\AccountView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SendAccount_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AccountIDResp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.FirstNameResp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.date = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.LastNameResp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.Balance = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.Phoneresp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.credits = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.MessageResp = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

