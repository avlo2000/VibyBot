using System.Collections.Generic;

namespace VibyBot.Persistence.Contracts
{
    //за цими домовленостями буде проводитися взаємодія з базою данних
    public interface IAdminStorage
    {
        bool GetAdminAccess(long userId);

        void SetAdminAccess(long userId);

        IEnumerable<long> GetAllAdmins(); //повертає айдішки всіх адмінів
    }
}
