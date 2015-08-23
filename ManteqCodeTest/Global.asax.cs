using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ManteqCodeTest.App_Start;
using ManteqCodeTest.Core;


namespace ManteqCodeTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Start();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region Bus

            var bus = new FakeBus();

            var storage = new EventStore(bus);
            var rep = new Repository<MedicalApprovalProcedure>(storage);
            var commands = new CommandHandlers(rep);
            bus.RegisterHandler<CreateMedicalProcedureApprovalRequest>(commands.Handle);
            var eventHandler = new ManteqEventHandler();
            bus.RegisterHandler<ApprovalCreated>(eventHandler.Handle);
            ServiceLocator.Bus = bus;
            
            #endregion Bus

        }
        protected void Application_BeginRequest()
        {
            if (Request.ApplicationPath != "/"
                    && Request.ApplicationPath.Equals(Request.Path, StringComparison.CurrentCultureIgnoreCase))
            {
                var redirectUrl = VirtualPathUtility.AppendTrailingSlash(Request.ApplicationPath);
                Response.RedirectPermanent(redirectUrl);
            }
        }
    
    }
}
