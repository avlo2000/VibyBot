using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;

namespace VibyBot.ControlTests.Mockups
{
   public class AdminStorageMock : IAdminStorage
    {
        private List<long> _admins;

        public AdminStorageMock()
        {
            _admins = new List<long>();
        }

        public bool GetAdminAccess(long userId)
        {
            foreach (var id in _admins)
            {
                if (id == userId)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<long> GetAllAdmins()
        {
            return _admins;
        }

        public void SetAdminAccess(long userId)
        {
            _admins.Add(userId);
        }
    }
}
