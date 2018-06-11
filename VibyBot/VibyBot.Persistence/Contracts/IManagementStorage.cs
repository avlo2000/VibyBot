using VibyBot.Persistence.DTO;

namespace VibyBot.Persistence.Contracts
{
    public interface IManagementStorage
    {
        ManagerInfo GetConfig(); 

        void UpdateConfig(ManagerInfo info); 
    }
}
