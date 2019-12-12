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
    }
}
