﻿using ExpenseTrackingApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseTrackingApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            this.Title = "TabbedPage";

            InitializeComponent();

            Children.Add(new BudgetPage());
            Children.Add(new TransactionPage());

        }
    }
}
