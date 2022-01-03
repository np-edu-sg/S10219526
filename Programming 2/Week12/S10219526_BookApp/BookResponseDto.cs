namespace S10219526_BookApp
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Qty { get; set; }
    }
}