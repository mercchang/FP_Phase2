using FP_Phase2.Models;
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
        public IHttpActionResult AddBudget(int hhId, string ownerId, string name, float targetAmount)
        {
            return Ok(db.AddBudget(hhId, ownerId, name, targetAmount));
        }


    }
}
