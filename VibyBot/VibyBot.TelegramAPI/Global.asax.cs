﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TelegramInteractionPOC;
using VibyBot.TelegramAPI.Models;

namespace VibyBot.TelegramAPI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Bootstrapper.Initialise();
        }
    }
}
