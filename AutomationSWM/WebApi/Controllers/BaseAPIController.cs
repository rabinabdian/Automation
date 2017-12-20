using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BaseAPIController : ApiController
    {
        public AutomationDBEntities2 db = new AutomationDBEntities2();
       

    }
}
