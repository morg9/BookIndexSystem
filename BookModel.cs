using CsvHelper.Configuration.Attributes;


namespace BookSorter
{
    public class BookModel
    {
        [Index(0)]
        public string? Name { get; set; }

        [Index(1)]
        public string? Title { get; set; }

        [Index(2)]
        public string? Place { get; set; }

        [Index(3)]
        public string? Publisher { get; set; }

        [Index(4)]
        public string? Date { get; set; }
        [Index(5)]
        public string? ID { get; set; }
    }
}
