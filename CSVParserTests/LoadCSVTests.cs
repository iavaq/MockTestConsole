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
        public void ShouldReturnAList()
        {
            //Arrange
            string filePath = "C:\\Users\\iavaq\\source\\repos\\MockTestConsole\\CSVParser\\data\\subInput.txt";

            //Act
            List<string> records = LoadCSV.LoadFromFile(filePath);

            //Assert
            records.Should().NotBeEmpty()
                .And.HaveCount(4);
        }

    }
}