using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control
{
    public class StorageControl
    {
        protected IManagementStorage _managementStorage;

        protected IAdminStorage _adminStorage;

        protected IOrderStorage _orderStorage;

        protected ManagerInfo _managerInfo;
    }
}
