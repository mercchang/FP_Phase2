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
        /// 
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("HouseholdBudgets")]
        public async Task<List<Budget>> GetBudgetsByHousehold(int householdId)
        {
            return await db.GetBudgetsByHousehold(householdId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("Budgets")]
        public async Task<List<Budget>> GetBudgets(int householdId)
        {
            return await db.GetBudgets(householdId);
        }
    }
}
