using System;
using System.Web;
using System.Web.Http;
using DailyEntry.Core.Interfaces;
using DailyEntry.Core.Services;
using DailyEntry.Infrastructure;
using DailyEntry.Infrastructure.Repositories;
using DailyEntry.WebAPI;
using DailyEntry.WebAPI.Services;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebApiContrib.IoC.Ninject;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace DailyEntry.WebAPI
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            // Support WebAPI
            GlobalConfiguration.Configuration.DependencyResolver =
              new NinjectResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDailyFeelingRepository>().To<DailyFeelingRepository>();
            kernel.Bind<IWorkoutRepository>().To<WorkoutRepository>();
            kernel.Bind<TrainningDB>().To<TrainningDB>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();            
            kernel.Bind<IServiceDailyTracker>().To<ServiceDailyTracker>();
            kernel.Bind<IDailyEntryIdentityService>().To<DailyEntryIdentityService>();
        }
    }
}
