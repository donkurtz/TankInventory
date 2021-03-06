﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace MobileApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           // EvaluateDisplayMode(); //Evaluate incoming request and update Display Mode table
        }
        /// <summary>
        /// Evaluates incoming request and determines and adds an entry into the Display mode table
        /// </summary>
        private static void EvaluateDisplayMode()
        {
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("Phone")
                {  //...modify file (view that is served)
                    //Query condition
                    ContextCondition = (ctx => (
                        //look at user agent
                        (ctx.GetOverriddenUserAgent() != null) &&
                        (//...either iPhone or iPad                           
                            (ctx.GetOverriddenUserAgent().IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (ctx.GetOverriddenUserAgent().IndexOf("iPod", StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                ))
                });
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("Tablet")
                {
                    ContextCondition = (ctx => (
                        (ctx.GetOverriddenUserAgent() != null) &&
                        (
                            (ctx.GetOverriddenUserAgent().IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (ctx.GetOverriddenUserAgent().IndexOf("Playbook", StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                ))
                });
        }
    }
}