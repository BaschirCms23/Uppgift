using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adressbok.Services
{
    public class FileService
    {
        private static readonly string filePath = @"C:\Users\basch\Desktop\Kontakter.Json";

        public static void SaveToFile(string contentAsJson)//Sparar Json-innehållet till en fil
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(contentAsJson);
        }
        public static string ReadFromFile(string contentAsJson)// gör så man kan läsa från en fil
        {
            if(File.Exists(filePath))
            {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();

            }
            return null!;
        }

     
    }
}
