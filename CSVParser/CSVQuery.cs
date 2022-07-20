using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CSVParser
{
    public class CSVQuery
    {
        public string FilePath { get; private set; }
        public List<List<string>> RecordList { get; private set; }
        public Dictionary<string, List<string>> DataTable { get; private set; }

        public CSVQuery(string filePath)
        {
            FilePath = filePath;
            RecordList = ParseCSV.MyStringParser(LoadCSV.LoadFromFile(FilePath));
            DataTable = ParseCSV.ColumnBuilder(RecordList);
        }

        public List<string> KeywordSearch(string column, string word)
        {
            //returns index of matches, else return -1
            List<int> matches = DataTable[column].Select((item, index) =>
                item.ToLower().Contains(word.ToLower()) ? index : -1).ToList();

            if (!matches.Any())
            {
            }
                
            return GetOutput(matches);
        }

        public List<string> ExactSearch(string column, string word)
        {
            //returns index of matches, else return -1
            List<int> matches = DataTable[column].Select((item, index) =>
                item.ToLower().Equals(word.ToLower()) ? index : -1).ToList();

            if (!matches.Any())
            {
            }

            return GetOutput(matches);

        }

        public List<string> RegexSearch(string column, string pattern)
        {
            //string word = @"^\d{2}[^\d]";
            //returns index of matches, else return -1
            string y = DataTable[column][0];
            List<int> matches = DataTable[column].Select((item, index) =>
                Regex.IsMatch(item, pattern) ? index : -1).ToList();

            if (!matches.Any())
            {
            }

            return GetOutput(matches);
        }

        public List<string> LimitByLength(string column, int num)
        {
            string y = DataTable[column][0];
            List<int> matches = DataTable[column].Select((item, index) =>
                item.Length>num ? index : -1).ToList();

            if (!matches.Any())
            {
            }

            return GetOutput(matches);
        }

        public List<string> CompareColumns(string colA, string colB)
        {
            List<double> phone1s = new();
            List<double> phone2s = new();

            string test = DataTable[colA][3];

            for (int i = 0; i < DataTable[colA].Count; i++)
            {
                double phone1 = double.Parse(DataTable[colA][i].Replace("-", ""));
                phone1s.Add(phone1);

                double phone2 = double.Parse(DataTable[colB][i].Replace("-", ""));
                phone2s.Add(phone2);
            }

            List<int> matches = phone1s.Select((item, index) =>
                item > phone2s[index] ? index : -1).ToList();

            if (!matches.Any())
            {
            }

            return GetOutput(matches);
        }
        private List<string> GetOutput(List<int> indices )
        {
            List<string> output = new List<string>();

            foreach (int i in indices)
            {
                //find row i from RecordList
                //RecordList has a header
                //get first_name, last_name, company

                if (i > -1) //greater than 0 means a match
                {
                    string firstName = RecordList[i][0];
                    string lastName = RecordList[i][1];
                    string companyName = RecordList[i][2];
                    string match = $"{i} - {firstName} {lastName} - {companyName}";
                    output.Add(match);
                }

            }
            return output;
        }
    }
}
