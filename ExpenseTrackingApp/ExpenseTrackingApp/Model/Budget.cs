﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms.Internals;

namespace ExpenseTrackingApp.Model
{

    internal class Budget
    {
        public double BudgetLimit { get; set; }
        public string Month { get; set; }
        public string Filename { get; set; }
        public string Type { get; set; }

        public double TotalBudget { get; set; }

        public Budget()
        {

        }
        public double BudgetSpent
        {
            get
            {
                double budgetSpent = 0;
                foreach (var transaction in allTransactions)
                {
                    budgetSpent += transaction.Amount;

                }
                return budgetSpent;
            }
        }

        public double BudgetRemaining
        {
            get
            {
                return this.BudgetLimit - this.BudgetSpent;
            }
        }

        public void UpdateBudgetLimit(double budgetLimit)
        {
            if (budgetLimit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(budgetLimit), "Enter a larger budget");
            }

            this.BudgetLimit = budgetLimit;
        }

        public double GetAmountSpent(TransactionType transactionType)
        {
            var transactions = this.GetTransactions(transactionType);
            double budgetSpent = 0;
            foreach (var transaction in transactions)
            {
                budgetSpent += transaction.Amount;
            }

            return budgetSpent;
        }

        public static List<TransactionType> GetAllTransactionTypes()
        {
            return Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>().ToList();
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public Budget(double budgetLimit)
        {
            if (budgetLimit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(budgetLimit), "Enter a larger budget");
            }
            this.BudgetLimit = budgetLimit;
        }

        public Budget(string month)
        {
            this.Month = month;
        }

     

        public List<Transaction> GetTransactions(ExpenseTrackingApp.Model.TransactionType transactionType)
        {
            var transactionList = new List<Transaction>();
            var filteredTransactions = allTransactions.Where(transaction => transaction.Type == transactionType);
            filteredTransactions.ForEach(transaction => transactionList.Add(transaction));
            return transactionList;
        }
    }
}
