using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelegramInteractionPOC.Services;
using VibyBot.Persistence.Contracts;
using VibyBot.TelegramAPI.Models;

namespace VibyBot.TelegramAPI.Controllers
{
    public class HomeController : Controller
    {
        private IMessageService _messageService;
        private IManagementStorage _managementStorage;
        private IAdminStorage _adminStorage;
        private IOrderStorage _orderStorage;

        public HomeController(IMessageService messageService, IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
        {
            _messageService = messageService;
            _managementStorage = managementStorage;
            _orderStorage = orderStorage;
            _adminStorage = userStorage;
        }

        public async Task<string> Index()
        {
            await Bot.GetAsync(_managementStorage, _adminStorage, _orderStorage);
            return "VIBY bot";
        }
    }
}