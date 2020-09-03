using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using static LINQ.Program;

namespace LINQTests
{
    public class LINQTests
    {
        [Fact]
        public void DeDuplicate_takes_out_duplicates()
        {
            // Arrange
            string path = "../../../../LINQ/data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Act
            IEnumerable<string> deDuplicate =
                    (from feature in root.features
                     where !feature.properties.neighborhood.Equals("")
                     select feature.properties.neighborhood).Distinct();
            Console.WriteLine(String.Join(", ", deDuplicate));

            // Assert
            Assert.Equal(39, deDuplicate.Count());
        }
    }
}