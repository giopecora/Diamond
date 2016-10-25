using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Diamond.App_Start;

[assembly: OwinStartup(typeof(Diamond.Startup))]

namespace Diamond
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AutoMapperConfiguration.Configure();
        }
    }
}
