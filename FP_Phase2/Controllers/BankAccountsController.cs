using FP_Phase2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FP_Phase2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("Api/BankAccounts")]
    public class BankAccountsController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("BankAccounts")]
        public async Task<List<BankAccount>> GetBankAccounts(int householdId)
        {
            return await db.GetBankAccounts(householdId);
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("BankAccountDetails")]
        public async Task<BankAccount> GetBankAccountDetails(int bankAccountId, int householdId)
        {
            return await db.GetBankAccountDetails(bankAccountId, householdId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("BankAccountDetails/json")]
        public async Task<IHttpActionResult> GetBankAccountDetailsJson(int bankAccountId, int householdId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBankAccountDetails(bankAccountId, householdId));
            return Ok(json);
        }
    }
}
