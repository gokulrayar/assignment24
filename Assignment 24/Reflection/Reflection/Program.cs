using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {
   
            public class Source
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }

        public class Destination
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Occupation { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }
        public static void MapProperties(Destination destination, Source source)
        {
            var destinationProperties = destination.GetType().GetProperties();
            var sourceProperties = source.GetType().GetProperties();

            foreach (var destinationProperty in destinationProperties)
            {
                var matchingSourceProperty = sourceProperties.FirstOrDefault(p => p.Name == destinationProperty.Name && p.PropertyType == destinationProperty.PropertyType);

                if (matchingSourceProperty != null)
                {
                    destinationProperty.SetValue(destination, matchingSourceProperty.GetValue(source));
                }
            }
        }
        public static void Main(string[] args)
        {
            var source = new Source
            {
                Name = "Gokul",
                Age = 22,
                Address = "Tamilnadu,india"
            };

            var destination = new Destination();

            MapProperties(destination, source);

            Console.WriteLine($"Name: {destination.Name}");
            Console.WriteLine($"Age: {destination.Age}");
            Console.WriteLine($"Occupation: {destination.Occupation}");
            Console.WriteLine($"Address: {destination.Address}");
            Console.WriteLine($"Email: {destination.Email}");
            Console.ReadKey();
        }
        
    }

}