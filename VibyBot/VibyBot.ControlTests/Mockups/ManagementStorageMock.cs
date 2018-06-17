using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.Mockups
{
    public class ManagementStorageMock : IManagementStorage
    {
        private static ManagerInfo _config;

        public ManagementStorageMock()
        {
            if (_config == null)
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
