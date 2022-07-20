using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using CSVParser;
using CSVParser.Models;

namespace CSVParserTests
{
    public class CSVQueryTests
    {
        private CSVQuery query;

        [SetUp]
        public void Setup()
        {
            string file = "C:\\Users\\iavaq\\source\\repos\\MockTestConsole\\CSVParser\\data\\subInput.txt";
            query = new CSVQuery(file);
        }

        [Test]
        public void ShouldNotBeNull()
        {
            //Arrange
            string column = TableColumns.company_name.ToString();
            string word = "cap";
            string expected = "1 - Evan Zigomalas - Cap Gemini America";

            //Act
            var actual = query.KeywordSearch(column, word);

            //Assert
            actual.Should().NotBeNull();
        }

        [Test]
        public void ShouldHaveAList()
        {
            //Arrange
            string column = TableColumns.company_name.ToString();
            string word = "cap";
            string expected = "1 - Evan Zigomalas - Cap Gemini America";

            //Act
            var actual = query.KeywordSearch(column, word);

            //Assert
            actual[0].Should().Contain(expected);
        }

        [Test]
        public void SearchExactShouldMatchExactlyOne()
        {
            //Arrange
            string column = TableColumns.county.ToString();
            string word = "KENT";
            string expected = "0 - Aleshia Tomkiewicz - Alan D Rosenburg Cpa Pc";

            //Act
            var actual = query.ExactSearch(column, word);

            //Assert
            actual[0].Should().Be(expected);
        }

        [Test]
        public void RegexAddressShouldMatchExactlyOne()
        {
            //Arrange
            string column = TableColumns.postal.ToString();
            string word = "^[0-9]{2}";
            string expected = "0 - Aleshia Tomkiewicz - Alan D Rosenburg Cpa Pc";

            //Act
            var actual = query.RegexSearch(column, word);

            //Assert
            actual[0].Should().Be(expected);
        }

        [Test]
        public void RegexPostalShouldHaveCount2()
        {
            //Arrange
            string column = TableColumns.postal.ToString();
            string word = "^[^\\d]{1,2}\\d{1}(\\y|[^\\d])";
            string expected = "0 - Aleshia Tomkiewicz - Alan D Rosenburg Cpa Pc";

            //Act
            var actual = query.RegexSearch(column, word);

            //Assert
            actual.Should().HaveCount(2);
        }
       
        [Test]
        public void LimitByLengthSearchShouldNotBeNull()
        {
            //Arrange
            string column = TableColumns.web.ToString();
            int num = 35;
            string expected = "0 - Aleshia Tomkiewicz - Alan D Rosenburg Cpa Pc";

            //Act
            var actual = query.LimitByLength(column, num);

            //Assert
            actual[0].Should().Be(expected);
        }

        [Test]
        public void CompareColumnsShoulReturnAListof2()
        {
            //Arrange
            string colA = TableColumns.phone1.ToString();
            string colB = TableColumns.phone2.ToString();
            string expected = "1 - Evan Zigomalas - Cap Gemini America";

            //Act
            var actual = query.CompareColumns(colA, colB);

            //Assert
            actual.Should().HaveCount(2)
                .And.Contain(expected);
        }

    }
}
