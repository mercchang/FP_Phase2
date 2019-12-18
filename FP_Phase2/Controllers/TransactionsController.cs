using FP_Phase2.Enums;
using FP_Phase2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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
        [ResponseType(typeof(List<Transaction>))]
        public async Task<IHttpActionResult> GetAllTransactions()
        {
            var transactions = await db.GetAllTransactions();
            return Json(transactions, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get details for transactions of a specific bank account
        /// </summary>
        /// <param name="id">Bank Account ID</param>
        /// <returns></returns>
        [Route("GetTransactionsByBankAccount")]
        [ResponseType(typeof(List<Transaction>))]
        public async Task<IHttpActionResult> GetTransactionsByBankAccount(int id)
        {
            var transactions = await db.GetTransactionsByBankAccount(id);
            return Json(transactions, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Gets details for a specific transaction
        /// </summary>
        /// <param name="id">Transaction ID</param>
        /// <param name="bId">Bank Account ID</param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        [ResponseType(typeof(List<Transaction>))]
        public async Task<IHttpActionResult> GetTransactionDetails(int id, int bId)
        {
            var transactions = await db.GetTransactionDetails(id, bId);
            return Json(transactions, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Add new transaction to a budget item.
        /// </summary>
        /// <param name="bankId">Bank Account ID</param>
        /// <param name="budgetItemId">Budget Item ID</param>
        /// <param name="ownerId">Owner ID</param>
        /// <param name="memo">Memo</param>
        /// <param name="transactionType">Transaction Type</param>
        /// <param name="amount">Amount</param>
        /// <returns></returns>
        [HttpPost, Route("AddTransaction")]
        [ResponseType(typeof(List<Transaction>))]
        public IHttpActionResult AddTransaction(int bankId, int budgetItemId, string ownerId, string memo, TransactionType transactionType, float amount)
        {
            return Ok(db.AddTransaction(bankId, budgetItemId, ownerId, memo, transactionType, amount));
        }

    }
}
