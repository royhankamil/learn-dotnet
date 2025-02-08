namespace TestApi.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int bookId {  get; set; }
        public string content { get; set; }
        public Users? user { get; set; }
        public Books? book { get; set; }
    }
}
