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
using System.Web.Http.Description;

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
        /// <param name="householdId">ID for the Household</param>
        /// <returns></returns>
        [Route("GetBankAccounts")]
        public async Task<List<BankAccount>> GetBankAccounts(int householdId)
        {
            return await db.GetBankAccounts(householdId);
        }

        /// <summary>
        /// Gets details for all bank accounts belonging to a household, as JSON
        /// </summary>
        /// <param name="householdId">ID for the Household</param>
        /// <returns></returns>
        [Route("BankAccounts/json")]
        [ResponseType(typeof(List<BankAccount>))]
        public async Task<IHttpActionResult> GetBankAccountsJson(int householdId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBankAccounts(householdId));
            return Ok(json);
        }

        /// <summary>
        /// Gets details for a specific bank account
        /// </summary>
        /// <param name="bankAccountId">Bank Account ID</param>
        /// <param name="householdId">Household ID</param>
        /// <returns></returns>
        [Route("GetBankAccountDetails")]
        public async Task<BankAccount> GetBankAccountDetails(int bankAccountId, int householdId)
        {
            return await db.GetBankAccountDetails(bankAccountId, householdId);
        }

        /// <summary>
        /// Gets details for a bank account as JSON
        /// </summary>
        /// <param name="bankAccountId">Bank Account ID</param>
        /// <param name="householdId">Household ID</param>
        /// <returns></returns>
        [Route("GetBankAccountDetails/json")]
        [ResponseType(typeof(List<BankAccount>))]
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
        /// <param name="name">Name of Bank Account</param>
        /// <param name="startingBalance">Starting Balance</param>
        /// <param name="lowBalance">Low Balance Warning</param>
        /// <returns></returns>
        [HttpPost, Route("AddBankAccount")]
        [ResponseType(typeof(List<BankAccount>))]
        public IHttpActionResult AddBankAccount(int householdId, string ownerId, AccountType accountType, string name, float startingBalance, float lowBalance)
        {
            return Ok(db.AddBankAccount(householdId, ownerId, accountType, name, startingBalance, lowBalance));
        }

        /// <summary>
        /// Edit Details for a Bank Account
        /// </summary>
        /// <param name="bankId">Bank Account ID</param>
        /// <param name="householdId">Household ID</param>
        /// <param name="ownerId">Owner ID</param>
        /// <param name="accountType">Account Type</param>
        /// <param name="name">Name of account</param>
        /// <param name="startingBalance">Starting Balance</param>
        /// <param name="currentBalance">Current Balance</param>
        /// <param name="lowBalance">Low Balance Warning</param>
        /// <returns></returns>
        [HttpPut, Route("EditBankAccount")]
        [ResponseType(typeof(List<BankAccount>))]
        public IHttpActionResult EditBankAccount(int bankId, int householdId, string ownerId, AccountType accountType, string name, float startingBalance, float currentBalance, float lowBalance)
        {
            return Ok(db.EditBankAccount(bankId, householdId, ownerId, accountType, name, startingBalance, currentBalance, lowBalance));
        }

        /// <summary>
        /// Delete a Bank Account from the database
        /// </summary>
        /// <param name="bankId">Bank Account ID</param>
        /// <param name="hhId">ID of Household that the account belongs to</param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBankAccount")]
        [ResponseType(typeof(List<BankAccount>))]
        public IHttpActionResult DeleteBankAccount(int bankId, int hhId)
        {
            return Ok(db.DeleteBankAccount(bankId, hhId));
        }
    }
}
