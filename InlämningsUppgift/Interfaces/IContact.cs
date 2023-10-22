using Adressbok.Models;

namespace Adressbok.Interfaces
{
    public interface IContact //Här definierar Interfacet olika egenskaper som en kontakt kan ha
    {
        Adress? Adress { get; set; }
        string? Email { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? FullName { get; }
        string? PhoneNumber { get; set; }
        
    }
}