namespace TestApi.Models
{
    public class Users
    {

        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        public ICollection<Books> Books { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
