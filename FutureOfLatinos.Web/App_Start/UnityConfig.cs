using FutureOfLatinos.Data;
using FutureOfLatinos.Data.Providers;
using FutureOfLatinos.Services;
using FutureOfLatinos.Services.Cryptography;
using FutureOfLatinos.Services.Interfaces;
using FutureOfLatinos.Web.Core.Services;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;


namespace FutureOfLatinos.Web.Interfaces
{
	public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            //this should be per request
            container.RegisterType<IConfigTypeService, ConfigTypeService>();
            container.RegisterType<IConfigService, ConfigService>();
            container.RegisterType<IConfigDataTypeService, ConfigDataTypeService>();
            container.RegisterType<IAuthenticationService, OwinAuthenticationService>();
            container.RegisterType<ILinksService, LinksService>();
            container.RegisterType<ICryptographyService, Base64StringCryptographyService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IEventTypeService, EventTypeService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IPersonService, Person_Services>();
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<IRssFeedService, RssFeedService>();
            container.RegisterType<IEventService, EventService>();
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IBlogCommentService, BlogCommentService>();
            container.RegisterType<IEventTypeService, EventTypeService>();
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<ISocialMediaServices, SocialMediaServices>();
            container.RegisterType<IEventTypeService, EventTypeService>();
            container.RegisterType<IEventCategoryService, EventCategoryService>();
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<IPhoneService, PhoneService>();
            container.RegisterType<IPhoneTypeService, PhoneTypeService>();
            container.RegisterType<IFAQService, FAQService>();
            container.RegisterType<IFileStorageService, FileStorageService>();
            container.RegisterType<IContactUsService, ContactUsService>();
            container.RegisterType<ILogService, LogService>();
            container.RegisterType<IFileStorageService, FileStorageService>();
            container.RegisterType<ICarouselImageUploadService, CarouselImageUploadService>();
            container.RegisterType<IProfileImageService, ProfileImageService>();
            container.RegisterType<ICarouselTextService, CarouselTextService>();
            container.RegisterType<ILogService, LogService>();
            container.RegisterType<IAdminRolesService, AdminRolesService>();
            container.RegisterType<IProfileImageService, ProfileImageService>();
            container.RegisterType<IThirdPartyUserService, ThirdPartyUserService>();


            container.RegisterType<IDataProvider, SqlDataProvider>(
            new InjectionConstructor(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            container.RegisterType<IPrincipal>(new TransientLifetimeManager(),
            new InjectionFactory(con => HttpContext.Current.User));
            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));


        }
    }
}
