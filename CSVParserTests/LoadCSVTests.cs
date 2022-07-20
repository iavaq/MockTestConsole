using FluentAssertions;
using CSVParser;

namespace CSVParserTests
{
    public class LoadCSVTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ShouldReturnAListOf5()
        {
            //Arrange
            string filePath = "C:\\Users\\iavaq\\source\\repos\\MockTestConsole\\CSVParser\\data\\subInput.txt";

            //Act
            List<string> records = LoadCSV.LoadFromFile(filePath);

            //Assert
            records.Should().NotBeEmpty()
                .And.HaveCount(5);
                 //should also check for datatype of list
        }

    }
}