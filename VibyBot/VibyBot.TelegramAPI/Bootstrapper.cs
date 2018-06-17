using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TelegramInteractionPOC.Services;
using Unity.Mvc3;
using VibyBot.ControlTests.Mockups;
using VibyBot.Persistence.Contracts;

namespace TelegramInteractionPOC
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMessageService, MessageService>();
            container.RegisterType<IManagementStorage, ManagementStorageMock>();
            container.RegisterType<IOrderStorage, OrderStorageMock>();
            container.RegisterType<IAdminStorage, AdminStorageMock>();

            return container;
        }
    }
}