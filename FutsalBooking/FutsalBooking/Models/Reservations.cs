namespace FutsalBooking.Models
{
    public class Reservations
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int field_id {  get; set; }
        public DateOnly date {  get; set; }
        public TimeSpan start_time {  get; set; }
        public TimeSpan end_time { get; set; }
        public string status { get; set; }
        public DateTime? created_at { get; set; }
        public Users user { get; set; }
        public Fields field { get; set; }
        public Payments? payment { get; set; }
    }
}
