using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CSVParser
{
    public static class ParseCSV
    {
        public static List<List<string>> MyStringParser(List<string> input)
        {
            //takes a list of string
            //parse each row of string into fields of string
            //returns a list of list

            List<string> fields = new();
            List<List<string>> listOfFields = new();
            char[] delimeters = { ',' };
            string pattern = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";

            foreach (string row in input)
            {
                //split row into list of "fields"
                // fields = row.Split(delimeters).ToList();

                //regex to escape comma in between ""
                fields = Regex.Split(row, pattern).ToList();
                listOfFields.Add(fields);
            }

            return listOfFields;
        }

        public static Dictionary<string, List<string>> ColumnBuilder(List<List<string>> input)
        {
            //takes a list of list
            //returns dictionary with column headers as keys with value from csv column
    

            List<string> header = input.First();

            input.RemoveAt(0);

            int colIndex = 0;
            Dictionary<string, List<string>> columns = new Dictionary<string, List<string>>();

            columns = header.ToDictionary(x => x, x => new List<string>());

            foreach (string col in header)
            {
                List<string> values = new List<string>();
                int rowIndex = 0;
                foreach (var row in input)
                {
                    values.Add(input[rowIndex][colIndex].Trim());
                    rowIndex++;
                }
                columns[col] = values;
                colIndex++;
            };

            return columns;
        }
    }
}
