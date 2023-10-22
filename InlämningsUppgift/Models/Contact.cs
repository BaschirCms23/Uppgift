using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbok.Interfaces;

namespace Adressbok.Models
{
    public class Contact : IContact // den här koden definerar en modell för att hantera kontaktinformation
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Adress? Adress { get; set; }

        public string? FullName => $"{FirstName} {LastName}";

    }
}
