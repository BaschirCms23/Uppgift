using Adressbok.Interfaces;
using Adressbok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Adressbok.Services
{
    public class MenyService
    {
        private readonly IContactService contactService = new ContactService();
        




        public void MainMeny() // De här visas först när programmet startas
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create a new contact: ");
                Console.WriteLine("2. Show all contacts: ");
                Console.WriteLine("3. show a specific: ");
                Console.WriteLine("4  Delete a contact: ");
                Console.WriteLine("0: Exit ");
                Console.Write("Choose one of the options above: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddContactMenu();
                        break;
                    case "2":
                        ListAllContactsMenu();
                        break;
                    case "3":
                        ViewOneContactMenu();
                        break;
                    case "4":
                        DeleteContactMenu();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;

                }


                Console.ReadKey();


            } while (true);
        }



        public void AddContactMenu()//Här skriver man in all kontakt information
        {
            string answer = "n";
                do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Create a new contact");
                    Console.WriteLine("-----------------------");

                    IContact contact = new Contact();
                    contact.FirstName = GetUserInput("Firstname: ").Trim().ToLower();
                    contact.LastName = GetUserInput("Lastname: ").Trim().ToLower();
                    contact.Email = GetUserInput("Email: ").Trim().ToLower();


                    Console.Write("Phonenumber: ");
                    contact.PhoneNumber = Console.ReadLine();


                        

                    contact.Adress = new Adress();
                    contact.Adress.StreetName = GetUserInput("Street: ");
                    Console.Write("Streetnumber: ");
                    contact.Adress.StreetNumber = Console.ReadLine();
                    Console.Write("Postalcode: ");
                    contact.Adress.PostalCode = Console.ReadLine();
                    contact.Adress.City = GetUserInput("City: ");

                    Console.WriteLine("A new user has been added");
                    Console.WriteLine("Do you want to add another contact (y/n)");
                    answer = Console.ReadLine() ?? "";
                    contactService.AddContact(contact);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error was found {ex.Message}");
                }



            } while ((string.IsNullOrEmpty(answer) || answer != "n"));
        }
       
        
        
        private string GetUserInput(string prompt)//De här gör så att man  t ex inte kan skriva siffror som förnamn
        {
            string userInput;
            Regex onlyLettersRegex = new Regex("^[a-öA-Ö@.]+$");
            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine()?.Trim()!;

                if (!onlyLettersRegex.IsMatch(userInput))
                {
                    Console.WriteLine("Please only enter letters");
                }
                else
                {
                    break;
                }
            } while (true);
            return userInput;
        }
        public void ListAllContactsMenu() // Här skriver de ut en lista på alla kontaker
        {
            var contacts = contactService.GetAllContacts();
            if (contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    if(contact != null)
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine(contact.FullName);
                        Console.WriteLine(contact.Adress?.FullAdress);
                        Console.WriteLine(contact.PhoneNumber);
                       

                    }
                    else
                    {
                        Console.WriteLine("No user was found");
                    }


                }
            }
            else
            {
                Console.WriteLine("No contacts was not found");
            }
        }
        public void ViewOneContactMenu()//Här skriver den ut en kontakt om du skriver in dens email
        {
            string answer = "";
            do
            {
                Console.Write("Email: ");
                var email = Console.ReadLine();

                var contact = contactService.GetOneContact(email!);

                if (contact != null)
                {
                    Console.WriteLine(contact.FullName);
                    Console.WriteLine(contact.Adress?.FullAdress);
                    Console.WriteLine(contact.PhoneNumber);
                }
                else
                {
                    Console.WriteLine($"No user  with this email: <{email}> was found");
                }
                Console.Write("Do you want to find another contact y/n: ");
                answer = Console.ReadLine()!;

            } while (answer != "n");




        }
        public void DeleteContactMenu()// Här raderar du en kontankt om du skriver in dens email
        {
            string answer;
            do
            {
                Console.Write("Type users email: ");
                var email = Console.ReadLine();

                var contact = contactService.GetOneContact(email!);
                if (contact != null)
                {
                    contactService.DeleteContact(email!);
                    Console.WriteLine("Contact has been deleted");

                }
                else { Console.WriteLine($"No user with this email: <{email}> was found"); }

                Console.Write("Do you want to delete another contact y/n: ");
                answer = Console.ReadLine()!;
            } while (answer.ToLower() == "y");


        }

      
       
    }
}



                


                
