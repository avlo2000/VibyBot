using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Control.DTO;

namespace VibyBot.Control.Contracts
{
    //за цими домовленостями буде проводитися взаємодія з базою данних
    public interface IUserInfo
    {
        Order CurrentOrder(long UserId);

        bool GetAdminAccess(long UserId);

        void SetAdminAccess(long UserId);
    }
}
