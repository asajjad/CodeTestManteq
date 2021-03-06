﻿using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ManteqCodeTest.Core;

namespace ManteqCodeTest.App_Start
{
    public static class Bootstrapper
    {
        public static void Start()
        {
           SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            //Create Autofac builder
            var builder = new ContainerBuilder();
            //Now register all depedencies to your custom IoC container

            //register mvc controller
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
               .AsImplementedInterfaces();

            builder.RegisterModelBinderProvider();

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //types

            builder.RegisterType<SqlDataStoreContext>().As<DbContext>().InstancePerRequest();
            
            builder.RegisterGeneric(typeof(Repository<>))
                  .As(typeof(IRepository<>)).InstancePerRequest();

            
            builder.RegisterType<FakeBus>().As<IEventPublisher>().InstancePerRequest();
            builder.RegisterType<FakeBus>().As<ICommandSender>().InstancePerRequest();
          
            var containerBuilder = builder.Build();

            //MVC resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerBuilder));

            // Create the depenedency resolver for Web Api
            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(containerBuilder);
            var config = new HttpConfiguration();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(containerBuilder);
        }

    }
}