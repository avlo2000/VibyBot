using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    //ця команда особлива, оскільки вона надає адмін доступ
    public class AccessCommand : AdminCommand
    {
        public override string Name => @"/admin";

        public override string Execute(string message, long chatId)
        {
            string answer = "Доступ  дозволено.";

            //тут у випадку якщо юзеру надано доступ його записують в бд як адміна
            object locker = new object();
            if (Contains(message))
                lock (locker)
                    _adminStorage.SetAdminAccess(chatId);

            return answer;
        }

        public override bool Contains(string command)
        {
            return (command.Contains(Name) && command.Contains(_managerInfo.Password));
        }

        public AccessCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage) 
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
