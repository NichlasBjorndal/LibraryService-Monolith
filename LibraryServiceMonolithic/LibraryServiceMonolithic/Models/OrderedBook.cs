namespace LibraryServiceMonolithic.Models
{
    public class OrderedBook
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}