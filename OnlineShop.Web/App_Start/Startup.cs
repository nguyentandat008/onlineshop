using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using OnlineShop.Data.Infrastructure;
using OnlineShop.Data;
using OnlineShop.Data.Repositories;
using OnlineShop.Service;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(OnlineShop.Web.App_Start.Startup))]

namespace OnlineShop.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        public void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // Regist for controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Regist for web api controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // Regist for unit of work
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            // Regist for db factory
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            // Regist for db context
            builder.RegisterType<OnlineShopDBContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Set the web api dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
