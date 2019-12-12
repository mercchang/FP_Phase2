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
    [RoutePrefix("Api/Households")]
    public class HouseholdsController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetAllHouseholdDataAsJson")]
        public async Task<IHttpActionResult> GetAllHouseholdDataAsJson(int id)
        {
            var data = await db.GetHouseholdDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns></returns>
        [Route("GetHouseholdDetails")]
        public async Task<Household> GetHouseholdDetails(int id)
        {
            return await db.GetHouseholdDetails(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetHouseholdAsJson")]
        public async Task<IHttpActionResult> GetHouseholdAsJson(int id)
        {
            var data = await db.GetHouseholdDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greeting"></param>
        /// <returns></returns>
        [HttpGet, Route("AddHousehold")]
        public IHttpActionResult AddHousehold(string name, string greeting)
        {
            return Ok(db.AddHousehold(name, greeting));
        }

    }
}
