using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace LINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ASK KEITH WHY ON TUESDAY
            string path = "../../../data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Question 1 - Output all neighborhoods from data
            Console.WriteLine("This is all neighborhoods printed.");
            Console.WriteLine("==================================");
            Console.WriteLine();
            Questions.Question1(root);

            // Spacing because data is large
            Console.ReadLine();
            Console.Clear();

            // Question 2 - Filter out all neighborhoods without names
            Console.WriteLine("This is neighborhoods with empty names filtered out.");
            Console.WriteLine("==================================");
            Console.WriteLine();
            Questions.Question2(root);

            // Spacing because data is large
            Console.ReadLine();
            Console.Clear();

            // Question 3 - Remove all duplicates
            Console.WriteLine("This is neighborhoods with empty names and duplicates filtered out.");
            Console.WriteLine("==================================");
            Console.WriteLine();
            Questions.Question3(root);

            // Spacing because data is large
            Console.ReadLine();
            Console.Clear();

            // Question 4 - Chain them all together
            Console.WriteLine("This is everything done in one chain.");
            Console.WriteLine("==================================");
            Console.WriteLine();
            Questions.Question4(root);

            // Spacing because data is large
            Console.ReadLine();
            Console.Clear();

            // Question 5 - Rewrite one of them in a different way
            Console.WriteLine("This is removing empties in a different way.");
            Console.WriteLine("==================================");
            Console.WriteLine();
            Questions.Question5(root);
        }

        public class Questions
        {
            public static IEnumerable<string> Question1(RootObject root)
            {
                IEnumerable<string> locData = root.features
                    .Select(data => data.properties.neighborhood);
                Console.WriteLine(String.Join(", ", locData));
                return locData;
            }

            public static IEnumerable<string> Question2(RootObject root)
            {
                IEnumerable<string> filtered =
                    from data in root.features
                    where data.properties.neighborhood.Length > 0
                    select data.properties.neighborhood;
                Console.WriteLine(String.Join(", ", filtered));

                return filtered;
            }

            public static IEnumerable<string> Question3(RootObject root)
            {
                IEnumerable<string> deDuplicate =
                    (from feature in root.features
                     where !feature.properties.neighborhood.Equals("")
                     select feature.properties.neighborhood).Distinct();
                Console.WriteLine(String.Join(", ", deDuplicate));
                return deDuplicate;
            }

            public static IEnumerable<string> Question4(RootObject root)
            {
                IEnumerable<string> chained = root.features
                    .Select(data => data.properties.neighborhood)
                    .Where(neighborhood => !neighborhood.Equals(""))
                    .Distinct();
                Console.WriteLine(String.Join(", ", chained));
                return chained;
            }

            public static IEnumerable<string> Question5(RootObject root)
            {
                IEnumerable<string> noEmpties2 = root.features
                    .Select(data => data.properties.neighborhood)
                    .Where(neighborhood => neighborhood.Length > 0);
                Console.WriteLine(String.Join(", ", noEmpties2));
                return noEmpties2;
            }
        }

        public class RootObject
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }

            public Geometry geometry { get; set; }
            public Property properties { get; set; }
        }

        public class Geometry
        {
            public Geometry(string type, double[] coordinates)
            {
                this.type = type;
                this.coordinates = coordinates;
            }

            public string type { get; set; }
            public double[] coordinates { get; set; }
        }

        public class Property
        {
            /*public Property(string zip, string city, string state, string address, string borough, string neighborhood, string county)
            {
                this.zip = zip;
                this.city = city;
                this.state = state;
                this.address = address;
                this.borough = borough;
                this.neighborhood = neighborhood;
                this.county = county;
            }*/

            public string zip { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string address { get; set; }
            public string borough { get; set; }
            public string neighborhood { get; set; }
            public string county { get; set; }
        }
    }
}
