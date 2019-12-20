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
    /// <summary>
    /// 
    /// </summary>
    public class BudgetsController : BaseController
    {
        /// <summary>
        /// Gets details for all budgets in a specific household
        /// </summary>
        /// <param name="householdId">Household ID</param>
        /// <returns></returns>
        [Route("GetBudgetsByHousehold")]
        public async Task<List<Budget>> GetBudgetsByHousehold(int householdId)
        {
            return await db.GetBudgetsByHousehold(householdId);
        }

        /// <summary>
        /// Gets details for a specific budget
        /// </summary>
        /// <param name="id">Budget ID</param>
        /// <returns></returns>
        [Route("GetBudgetDetails")]
        public async Task<List<Budget>> GetBudgetDetails(int id)
        {
            return await db.GetBudgetDetails(id);
        }

        /// <summary>
        /// Gets details for all budgets
        /// </summary>
        /// <returns></returns>
        [Route("GetAllBudgets")]
        public async Task<List<Budget>> GetAllBudgets()
        {
            return await db.GetAllBudgets();
        }

        /// <summary>
        /// Add new Budget to a household.
        /// </summary>
        /// <param name="hhId">Household ID</param>
        /// <param name="ownerId">Owner ID</param>
        /// <param name="name">Name of Budget</param>
        /// <param name="targetAmount">Target Amount</param>
        /// <returns></returns>
        [HttpPost, Route("AddBudget")]
        [ResponseType(typeof(List<Budget>))]
        public IHttpActionResult AddBudget(int hhId, string ownerId, string name, float targetAmount)
        {
            return Ok(db.AddBudget(hhId, ownerId, name, targetAmount));
        }

        /// <summary>
        /// Edit details for a budget
        /// </summary>
        /// <param name="budgetId">Budget ID</param>
        /// <param name="hhId">Household ID</param>
        /// <param name="ownerId">Owner ID</param>
        /// <param name="name">Name of Budget</param>
        /// <param name="targetAmount">Target Amount $</param>
        /// <returns></returns>
        [HttpPut, Route("EditBudget")]
        [ResponseType(typeof(List<Budget>))]
        public IHttpActionResult EditBudget(int budgetId, int hhId, string ownerId, string name, float targetAmount)
        {
            return Ok(db.EditBudget(budgetId, hhId, ownerId, name, targetAmount));
        }

        /// <summary>
        /// Delete a Budget from the database
        /// </summary>
        /// <param name="budgetId">Budget ID</param>
        /// <param name="hhId">ID of Household that the account belongs to</param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBudget")]
        [ResponseType(typeof(List<Budget>))]
        public IHttpActionResult DeleteBudget(int budgetId, int hhId)
        {
            return Ok(db.DeleteBudget(budgetId, hhId));
        }
    }
}
