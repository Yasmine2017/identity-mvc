﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Identityyy.Startup1))]

namespace Identityyy
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                          new CookieAuthenticationOptions
                          {
                              AuthenticationType = "ApplicationCookie",
                              LoginPath = new PathString("/accont/Login")
                          }
                          );
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
