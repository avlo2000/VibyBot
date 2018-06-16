using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.Mockups
{
    class IManagementStorageImplementation : IManagementStorage
    {
        private ManagerInfo _config;

        public IManagementStorageImplementation()
        {
            _config = new ManagerInfo();
        }

        public ManagerInfo GetConfig()
        {
            return _config;
        }

        public void UpdateConfig(ManagerInfo info)
        {
            _config.Password = info.Password;
            _config.Prints = info.Prints;
        }
    }
}
