namespace TestApi.Dto
{
    public class BooksDto
    {
        public int Id { get; set; }
        public int creatorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string category { get; set; }
    }
}
