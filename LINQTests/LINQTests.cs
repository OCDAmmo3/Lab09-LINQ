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
        public void Question1_returns_all_neighborhoods()
        {
            // Arrange
            string path = "../../../../LINQ/data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Act
            IEnumerable<string> neighborhoods = Questions.Question1(root);

            // Assert
            Assert.Equal(147, neighborhoods.Count());
        }

        [Fact]
        public void Question2_removes_empty_names()
        {
            // Arrange
            string path = "../../../../LINQ/data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Act
            IEnumerable<string> noEmpties = Questions.Question2(root);

            // Assert
            Assert.Equal(143, noEmpties.Count());
        }

        [Fact]
        public void Question3_takes_out_duplicates()
        {
            // Arrange
            string path = "../../../../LINQ/data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Act
            IEnumerable<string> deDuplicate = Questions.Question3(root);

            // Assert
            Assert.Equal(39, deDuplicate.Count());
        }

        [Fact]
        public void Question4_does_all_the_things()
        {
            // Arrange
            string path = "../../../../LINQ/data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Act
            IEnumerable<string> allTheThings = Questions.Question4(root);

            // Assert
            Assert.Equal(39, allTheThings.Count());
        }

        [Fact]
        public void Question5_removes_empty_names_in_other_way()
        {
            // Arrange
            string path = "../../../../LINQ/data.json";
            string lines = File.ReadAllText(path);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(lines);

            // Act
            IEnumerable<string> noEmpties2 = Questions.Question5(root);

            // Assert
            Assert.Equal(143, noEmpties2.Count());
        }
    }
}