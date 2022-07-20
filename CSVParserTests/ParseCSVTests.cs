using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using CSVParser;

namespace CSVParserTests
{
    public class ParseCSVTests
    {
        private List<string> records;

        [SetUp]
        public void Setup()
        {
            string file = "C:\\Users\\iavaq\\source\\repos\\MockTestConsole\\CSVParser\\data\\subInput.txt";
            records = LoadCSV.LoadFromFile(file);
        }

        [Test]
        public void ShouldReturnANoneEmptyList()
        {
            //Arrange
            int expected = 5;

            //Act
            List<List<string>> actual = ParseCSV.MyStringParser(records);

            //Assert
            actual.Should().NotBeEmpty()
                .And.HaveCount(expected);
        }

        [Test]
        public void ShouldReturnAListInList()
        {
            //Arrange
            List<string> expected = new(){"first_name", "last_name", "company_name", "address", "city", "county", "postal", "phone1", "phone2", "email", "web"};

            //Act
            List<List<string>> actual = ParseCSV.MyStringParser(records);


            //Assert
            actual[0].Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldReturnValuesOfColumnAsAList()
        {
            //Arrange
            List<string> expected = new(){"Aleshia", "Evan", "France", "Ulysses"};
            List<List<string>> rows = ParseCSV.MyStringParser(records);


            //Act
            Dictionary<string, List<string>> actual = ParseCSV.ColumnBuilder(rows);


            //Assert
            actual["first_name"].Should().BeEquivalentTo(expected);
        }
    }
}
