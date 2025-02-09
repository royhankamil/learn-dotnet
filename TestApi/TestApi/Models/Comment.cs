namespace TestApi.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int book_id {  get; set; }
        public string content { get; set; }
        public Users? user { get; set; }
        public Books? book { get; set; }
    }
}
