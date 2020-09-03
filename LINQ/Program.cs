using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ASK KEITH WHY ON TUESDAY
            string path = "../../../data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Question 1 - Output all neighborhoods from data
            IEnumerable<string> locData = root.features.Select(data => data.properties.neighborhood);
            Console.WriteLine(String.Join(", ", locData));

            // Spacing because data is large
            Console.WriteLine();
            Console.WriteLine("=================");
            Console.WriteLine();

            // Question 2 - Filter out all neighborhoods without names
            IEnumerable<string> filtered =
                from data in root.features
                where data.properties.neighborhood.Length > 0
                select data.properties.neighborhood;
            Console.WriteLine(String.Join(", ", filtered));

            // Question 3 - Remove all duplicates
            IEnumerable<string> deDuplicate =
                from feature in root.features
                where !feature.properties.neighborhood.Equals("")
                select feature.properties.neighborhood;
            Console.WriteLine(String.Join(", ", deDuplicate));
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
