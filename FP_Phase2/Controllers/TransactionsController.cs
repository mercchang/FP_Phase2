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
        /// Gets details for all transactions
        /// </summary>
        /// <returns></returns>
        [Route("GetAllTransactions")]
        public async Task<IHttpActionResult> GetAllTransactions()
        {
            var transactions = await db.GetAllTransactions();
            return Json(transactions, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get details for transactions of a specific bank account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetTransactionsByBankAccount")]
        public async Task<IHttpActionResult> GetTransactionsByBankAccount(int id)
        {
            var transactions = await db.GetTransactionsByBankAccount(id);
            return Json(transactions, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Gets details for a specific transaction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bId"></param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<IHttpActionResult> GetTransactionDetails(int id, int bId)
        {
            var transactions = await db.GetTransactionDetails(id, bId);
            return Json(transactions, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        //[Route("Transactions")]
        //public async Task<List<Transaction>> GetTransactions(int bankAccountId, int householdId)
        //{
        //    return await db.GetTransactions(bankAccountId, householdId);
        //}
    }
}
