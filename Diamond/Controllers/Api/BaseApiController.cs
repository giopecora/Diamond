﻿using Diamond.Providers;
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
        protected OwinContextProvider OwinContextProvider = new OwinContextProvider();

        protected int? AuthenticatedUserId
        {
            get
            {
                string value = OwinContextProvider.GetClaimValue("userId");

                if (string.IsNullOrEmpty(value))
                    return null;

                return Convert.ToInt32(value);
            }
        }

        private bool _isAdmin { get; set; }
        public bool IsAdmin
        {
            get
            {
                string value = OwinContextProvider.GetClaimValue("isAdmin");
                if (string.IsNullOrEmpty(value))
                    return false;

                return Convert.ToBoolean(value);
            }
        }
    }
}
