using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.WebApi;
using MessageServices;
using System;

namespace WebApplication3
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your services here
            //container.RegisterType<IMessageService, MessageServices.MessageService>();
            container.RegisterSingleton<IOrganizationservice, MessageServices.Organizationservice>();
            container.RegisterSingleton<IMessageService, MessageServices.MessageService>();
            

            DependencyResolver.SetResolver(new Unity.AspNet.Mvc.UnityDependencyResolver(container));

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container)); // MVC
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container); // Web API
        }
    }
}