namespace Adressbok.Interfaces
{
    public interface IAdress //Interfacet definierar egenskaper som representerar olika delar av adress
    {
        string? City { get; set; }
        string? FullAdress { get; }
        string? PostalCode { get; set; }
        string? StreetName { get; set; }
        string? StreetNumber { get; set; }
    }
}