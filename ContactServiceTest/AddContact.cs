using Adressbok.Interfaces;
using Adressbok.Models;
using Adressbok.Services;

namespace ContactServiceTest
{
    public class UnitTest1
    {
        [Fact]
        //Testar om man kan lägga till kontakt i listan
        public void AddContact_ShouldAdd_ContactToList()
        {
            //Arrange (referar menyService och contactService och skapar en kontakten kontakt)
           MenyService menyService = new MenyService();
            IContactService contactService = new ContactService();

            IContact contact = new Contact()
            {
                FirstName = "Baschir",
                LastName = "Sheikhabdi",
                Email = "Baschir.Sheikhabdi@gmail.com",
                PhoneNumber = "1234567890",
                Adress = new Adress()
                {
                    StreetName = "Snapphanevägen",
                    StreetNumber = "216",
                    PostalCode = "177 55",
                    City = "Stockholm"
                }
            };

            //Act Utförande (Här lägger den till kontakten till listan)

            contactService.AddContact(contact);
            var contacts = contactService.GetAllContacts();

            //Assert (Här kontrollerar den om kontankten har lagts till i listan)
            Assert.Contains(contacts, c => c.Email == "Baschir.Sheikhabdi@gmail.com");

        }
    }
}