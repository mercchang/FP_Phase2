using FP_Phase2.Enums;
using FP_Phase2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FP_Phase2.Controllers
{
    /// <summary>
    /// Create/Details for Bank Accounts
    /// </summary>
    [RoutePrefix("Api/BankAccounts")]
    public class BankAccountsController : BaseController
    {
        /// <summary>
        /// Gets details for all bank accounts belonging to a household
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("GetBankAccounts")]
        public async Task<List<BankAccount>> GetBankAccounts(int householdId)
        {
            return await db.GetBankAccounts(householdId);
        }

        /// <summary>
        /// Gets details for all bank accounts belonging to a household, as JSON
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("BankAccounts/json")]
        public async Task<IHttpActionResult> GetBankAccountsJson(int householdId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBankAccounts(householdId));
            return Ok(json);
        }

        /// <summary>
        /// Gets details for a specific bank account
        /// </summary>
        /// <param name="bankAccountId">Bank Account Id</param>
        /// <param name="householdId">Household Id</param>
        /// <returns></returns>
        [Route("GetBankAccountDetails")]
        public async Task<BankAccount> GetBankAccountDetails(int bankAccountId, int householdId)
        {
            return await db.GetBankAccountDetails(bankAccountId, householdId);
        }

        /// <summary>
        /// Gets details for a bank account as JSON
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("GetBankAccountDetails/json")]
        public async Task<IHttpActionResult> GetBankAccountDetailsJson(int bankAccountId, int householdId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBankAccountDetails(bankAccountId, householdId));
            return Ok(json);
        }

        /// <summary>
        /// Add a new Bank Account
        /// </summary>
        /// <param name="householdId">Household Id</param>
        /// <param name="ownerId">Id of Account Owner</param>
        /// <param name="accountType">Account Type</param>
        /// <param name="name">Name</param>
        /// <param name="startingBalance">Starting Balance</param>
        /// <param name="lowBalance">Low Balance Warning</param>
        /// <returns></returns>
        [HttpPost, Route("AddBankAccount")]
        public IHttpActionResult AddBankAccount(int householdId, string ownerId, AccountType accountType, string name, float startingBalance, float lowBalance)
        {
            return Ok(db.AddBankAccount(householdId, ownerId, accountType, name, startingBalance, lowBalance));
        }

    }
}
