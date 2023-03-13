using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.IO;

namespace CSVtoJSONlib
{
    internal class Data
    {
        public int TransactionID { get; set; }
        public DateOnly TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string? AccountID { get; set; }
        public string? AccountOwnerName { get; set; }
        public string? AccountType { get; set; }
    }

    public class Processor
    {
        public static void ProcessLines(string path, out int validAccounts, out int validTransactions)
        {
            List<Data> _data = new List<Data>();
            validAccounts = 0;
            validTransactions = 0;

            // Get filename without extension
            string fileNameNoExtension = System.IO.Path.ChangeExtension(path, null);

            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.SetDelimiters(",");
                string[] currentRow = parser.ReadFields();
                while (!parser.EndOfData)
                {
                    currentRow = parser.ReadFields();
                    if(Array.IndexOf(currentRow, string.Empty) == -1)
                    {
                        _data.Add(new Data() 
                        {
                            TransactionID = int.Parse(currentRow[0]),
                            TransactionDate = DateOnly.Parse(currentRow[1]),
                            TransactionAmount = decimal.Parse(currentRow[2]),
                            AccountID = currentRow[3],
                            AccountOwnerName = currentRow[4],
                            AccountType = currentRow[5]
                        });

                        // TODO: Determine how to properly count unique account ID's.
                        validAccounts++;
                        validTransactions++;
                    }
                }
            }

            string json = JsonConvert.SerializeObject( _data.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(fileNameNoExtension + ".json", json);
        }
    }
}