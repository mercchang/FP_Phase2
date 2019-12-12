﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP_Phase2.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public float TargetAmount { get; set; }
        public float CurrentAmount { get; set; }

        public virtual Budget Budget { get; set; }

        //public virtual ICollection<Transaction> Transactions { get; set; }

        //public BankAccount()
        //{
        //    Transactions = new HashSet<Transaction>();
        //}
    }
}