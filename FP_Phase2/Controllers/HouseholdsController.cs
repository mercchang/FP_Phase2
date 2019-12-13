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
        /// Gets details for all households
        /// </summary>
        /// <returns></returns>
        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            //var households = await db.GetAllHouseholdData();
            //return Json(households, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return await db.GetAllHouseholdData();
        }

        /// <summary>
        /// Gets details for all households as Json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetAllHouseholdData/Json")]
        public async Task<IHttpActionResult> GetAllHouseholdDataAsJson()
        {
            var data = JsonConvert.SerializeObject(await db.GetAllHouseholdData());
            return Ok(data);
        }

        /// <summary>
        /// Gets details for a specific household
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns></returns>
        [Route("GetHousehold")]
        public async Task<Household> GetHousehold(int id)
        {
            return await db.GetHousehold(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetHousehold/Json")]
        public async Task<IHttpActionResult> GetHouseholdAsJson(int id)
        {
            var data = JsonConvert.SerializeObject(await db.GetHousehold(id));
            return Ok(data);
        }

        /// <summary>
        /// Adds a household into the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greeting"></param>
        /// <returns></returns>
        [HttpPost, Route("AddHousehold")]
        public IHttpActionResult AddHousehold(string name, string greeting)
        {
            return Ok(db.AddHousehold(name, greeting));
        }

    }
}
