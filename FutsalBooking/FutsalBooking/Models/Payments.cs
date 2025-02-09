using System.Runtime.CompilerServices;

namespace FutsalBooking.Models
{
    public class Payments
    {
        public int id { get; set; }
        public int reservation_id {  get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public Reservations reservation { get; set; }
    }
}
