using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    //ця команда особлива, оскільки вона надає адмін доступ
    public class AccessCommand : AdminCommand
    {
        public override string Name => @"/admin ";

        public override Answer Execute(string message, long chatId)
        {
            string answer;

            //тут у випадку якщо юзеру надано доступ його записують в бд як адміна
            object locker = new object();
            if (message.Contains(Name) && message.Contains(_managerInfo.Password))
            {
                lock (locker)
                    _adminStorage.SetAdminAccess(chatId);
                answer = "Доступ  надано.";
            }
            else
                answer = "Неправильний пароль.";

            return new Answer(answer);
        }

        public AccessCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage) 
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
