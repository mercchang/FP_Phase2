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
        /// Bank Account Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Household Id
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// Id of Account Owner
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// Name of Account
        /// </summary>
        [StringLength(50, MinimumLength = 2), Required]
        public string Name { get; set; }
        /// <summary>
        /// Created Date of Bank Account
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Type of account: Checking or Savings
        /// </summary>
        public AccountType AccountType { get; set; }
        /// <summary>
        /// Starting balance of Account
        /// </summary>
        public float StartingBalance { get; set; }
        /// <summary>
        /// Current balance of account
        /// </summary>
        public float CurrentBalance { get; set; }
        /// <summary>
        /// Low balance warning for account
        /// </summary>
        public float? LowBalance { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual Household Household { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ApplicationUser Owner { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ICollection<Transaction> Transactions { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public BankAccount()
        //{
        //    Transactions = new HashSet<Transaction>();
        //}
    }
}