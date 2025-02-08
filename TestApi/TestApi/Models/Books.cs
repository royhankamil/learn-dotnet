namespace TestApi.Models
{
    public class Books
    {
        public int id { get; set; }
        public int creator_id {  get; set; }
        public string title {  get; set; }
        public string? description { get; set; } 
        public string? category { get; set; }
        public Users? creator { get; set; }
        public ICollection<Comment> comments { get; set; }

        
    }
}
