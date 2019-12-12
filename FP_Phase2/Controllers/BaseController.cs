using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FP_Phase2.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected ApiContext db = new ApiContext();
    }
}
