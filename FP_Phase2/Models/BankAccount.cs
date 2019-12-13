using FP_Phase2.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FP_Phase2.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>

        [StringLength(50, MinimumLength = 2), Required]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AccountType AccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float StartingBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float CurrentBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float? LowBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Household Household { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ApplicationUser Owner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BankAccount()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}