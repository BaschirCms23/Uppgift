using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbok.Interfaces;

namespace Adressbok.Models
{
    public class Adress : IAdress // Koden definierar en modell som hanterar adressinformation
    {
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? FullAdress => $"{StreetName} {StreetNumber}, {PostalCode} {City} ";
    }
}
