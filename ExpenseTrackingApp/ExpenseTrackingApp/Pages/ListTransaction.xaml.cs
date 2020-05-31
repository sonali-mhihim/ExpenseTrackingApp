﻿using ExpenseTrackingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTrackingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTransactionPage : ContentPage
    {
        public ObservableCollection<ExpenseTrackingApp.Model.Transaction> Transactions { get; set; } = new ObservableCollection<ExpenseTrackingApp.Model.Transaction>();

        public ListTransactionPage()
        {
            InitializeComponent();
            this.InitializeTransactionItems();
        }

        private void InitializeTransactionItems()
        {
            TransactionItemsView.ItemsSource = Transactions;
            var transactions = BudgetManager.GetTransactions(TransactionType.Food);
            transactions.ForEach(transaction => Transactions.Add(transaction));
        }
    }
}