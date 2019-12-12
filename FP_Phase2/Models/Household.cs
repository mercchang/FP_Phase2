using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP_Phase2.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Household
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// House Greeting
        /// </summary>
        public string Greeting { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime Created { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public Household()
        {
            Invitations = new HashSet<Invitation>();
            Notifications = new HashSet<Notification>();
            Users = new HashSet<ApplicationUser>();
            BankAccounts = new HashSet<BankAccount>();
            Budgets = new HashSet<Budget>();
            Transactions = new HashSet<Transaction>();
        }
    }
}