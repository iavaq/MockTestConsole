using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    public static class LoadCSV
    {
        public static List<string> LoadFromFile(string filePath)
        {
            //returns a list of string from a csv file
            List<string> records = new();
            using (var reader = new StreamReader(filePath))
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    records.Add(row);
                }
            return records;
        }
    }
}
