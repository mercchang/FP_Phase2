using FP_Phase2.Models;
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
    public class BudgetItemsController : BaseController
    {
        /// <summary>
        /// Gets Budget Item details for a specific budget
        /// </summary>
        /// <param name="id">Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemsByBudget")]
        public async Task<List<Budget>> GetBudgetItemsByBudget(int id)
        {
            return await db.GetBudgetItemsByBudget(id);
        }

        /// <summary>
        /// Gets details for a specific Budget Item
        /// </summary>
        /// <param name="id">Budget Item Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<List<Budget>> GetBudgetItemDetails(int id)
        {
            return await db.GetBudgetItemDetails(id);
        }

        /// <summary>
        /// Gets details for all budget items
        /// </summary>
        /// <returns></returns>
        [Route("GetAllBudgetItems")]
        public async Task<List<Budget>> GetAllBudgetItems()
        {
            return await db.GetAllBudgetItems();
        }

        /// <summary>
        /// Add a new Budget Item to a budget.
        /// </summary>
        /// <param name="budgetId">Budget ID</param>
        /// <param name="name">Name of Budget Item</param>
        /// <param name="targetAmount">Target Amount</param>
        /// <param name="currentAmount">Current Amount</param>
        /// <returns></returns>
        [HttpPost, Route("AddBudgetItem")]
        [ResponseType(typeof(List<BudgetItem>))]
        public IHttpActionResult AddBudgetItem(int budgetId, string name, float targetAmount, float currentAmount)
        {
            return Ok(db.AddBudgetItem(budgetId, name, targetAmount, currentAmount));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="budgetItemId"></param>
        /// <param name="name"></param>
        /// <param name="targetAmount"></param>
        /// <param name="currentAmount"></param>
        /// <returns></returns>
        [HttpPut, Route("EditBudgetItem")]
        [ResponseType(typeof(List<BudgetItem>))]
        public IHttpActionResult EditBudgetItem(int budgetId, int budgetItemId, string name, float targetAmount, float currentAmount)
        {
            return Ok(db.EditBudgetItem(budgetId, budgetItemId, name, targetAmount, currentAmount));
        }

        /// <summary>
        /// Delete a Budget Item from the database
        /// </summary>
        /// <param name="budgetId">Budget ID</param>
        /// <param name="budgetItemId">ID of Budget Item</param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBudgetItem")]
        [ResponseType(typeof(List<BudgetItem>))]
        public IHttpActionResult DeleteBudgetItem(int budgetId, int budgetItemId)
        {
            return Ok(db.DeleteBudgetItem(budgetId, budgetItemId));
        }
    }
}
