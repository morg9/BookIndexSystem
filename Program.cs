using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BookSorter
{
    class Program
    {
        static void Main()
        {

            string existingCsvPath = @"CSVFiles\U16A2Task2Data.csv";
            string newCsvPath = @"CSVFiles\New_TaskData";

            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null,
                };
                using var reader = new StreamReader(existingCsvPath);
                using var csvIn = new CsvReader(reader, config);
                {
                    var books = csvIn.GetRecords<BookModel>();
                    SerialNumberGenerator serialNumberGenerator = new();

                    using var writer = new StreamWriter(newCsvPath);
                    using var CsvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    {
                        CsvOut.WriteHeader<BookModel>();
                        CsvOut.NextRecord();

                        foreach (var book in books)
                        {
                            book.ID = serialNumberGenerator.GenerateSerialNumber(book);
                            CsvOut.WriteRecord(book);
                            CsvOut.NextRecord();
                        }
                    }
                }
                Console.WriteLine("Book data has been sorted and written to new CSV file.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file.");
            }
            catch (CsvHelperException)
            {
                Console.WriteLine("Error occured in CsvHelper.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error occured.");
            }
        }
    }
}