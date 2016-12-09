using Diamond.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Diamond.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        //protected OwinContextProvider OwinContextProvider = new OwinContextProvider();

        //protected int? UserId
        //{
        //    get
        //    {
        //        string value = OwinContextProvider.GetClaimValue("userId");

        //        if (string.IsNullOrEmpty(value))
        //            return null;

        //        return Convert.ToInt32(value);
        //    }
        //}
    }
}
