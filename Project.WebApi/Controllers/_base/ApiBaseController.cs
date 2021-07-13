using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Project.WebApi.Attributes;

namespace Project.WebApi.Controllers
{
    [ExceptionAttribute]
    public class ApiBaseController : ApiController
    {
    }
}