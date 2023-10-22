namespace Adressbok.Interfaces
{
    public interface IContactService
    {
        void AddContact(IContact contact);// Lägger till en kontakt
        IEnumerable<IContact> GetAllContacts();// Hämtar alla kontaker

        IContact GetOneContact(string email);//Hämtar en kontakt
        void DeleteContact(string email);//Raderar en kontakt
    }
}