﻿using FP_Phase2.Models;
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
        /// <param name="householdId">Household Id</param>
        /// <returns></returns>
        [Route("GetBudgetsByHousehold")]
        public async Task<List<Budget>> GetBudgetsByHousehold(int householdId)
        {
            return await db.GetBudgetsByHousehold(householdId);
        }

        /// <summary>
        /// Gets details for a specific budget
        /// </summary>
        /// <param name="id">Budget Id</param>
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


    }
}
