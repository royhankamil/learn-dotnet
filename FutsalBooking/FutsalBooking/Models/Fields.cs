namespace FutsalBooking.Models
{
    public class Fields
    {
        public int id {  get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }
        public ICollection<Reservations> reservations { get; set; }
    }
}
