using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.DTO;

namespace VibyBot.Persistence.Contracts
{
    //за цими домовленостями буде проводитися взаємодія з базою данних
    public interface IUserInfo
    {
        Order CurrentOrder(long UserId);

        bool GetAdminAccess(long UserId);

        void SetAdminAccess(long UserId);
    }
}
