using Adressbok.Interfaces;
using Adressbok.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok.Services
{
    public class ContactService : IContactService
    {
        private List<IContact> _contactsList = new List<IContact>();// En lista för att lägga in alla kontaker
        public void AddContact(IContact contact)// Den här metoden lägger till en kund och sen sparar den till en Json-fil
        {
            _contactsList.Add(contact);
            FileService.SaveToFile(JsonConvert.SerializeObject(_contactsList));

        }

        public void DeleteContact(string email)// Metoden gör så att en kund raderas
        {
            var contact = GetOneContact(email);
                _contactsList.Remove(contact);
        }

        public IEnumerable<IContact> GetAllContacts() //Metoden gör så att man får lista av alla kontakter
        {

            return _contactsList;
        }

        public IContact GetOneContact(string email)//Metod för att få en kontakt
        {
            return _contactsList.FirstOrDefault(x => x.Email == email)!;
        }
    }
}
