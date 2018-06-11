namespace VibyBot.Persistence.Contracts
{
    public interface IManagementStorage
    {
        void RestoreConfig(); //цей метод заміняє доля в ManagerConfig на ті що в базі

        void UpdateConfig(); //цей метод заміняє конфіг у базі на боточний зонфіг з ManagerConfig 
    }
}
