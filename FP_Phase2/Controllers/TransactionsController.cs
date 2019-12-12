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
    [RoutePrefix("Api/Transactions")]
    public class TransactionsController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <returns></returns>
        [Route("GetAllTransactions")]
        public async Task<IHttpActionResult> GetAllTransactions()
        {
            var transactions = await db.GetAllTransactions();
            return Json(transactions, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        [Route("TransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int id, float amount, string memo)
        {
            return await db.GetTransactionDetails(id, amount, memo);
        }

        //[Route("Transactions")]
        //public async Task<List<Transaction>> GetTransactions(int bankAccountId, int householdId)
        //{
        //    return await db.GetTransactions(bankAccountId, householdId);
        //}
    }
}
