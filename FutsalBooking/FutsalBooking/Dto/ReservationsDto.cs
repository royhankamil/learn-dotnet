namespace FutsalBooking.Dto
{
    public class ReservationsDto
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int field_id { get; set; }
        public DateOnly date { get; set; }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }
        public string status { get; set; }
        public DateTime? created_at { get; set; }
    }
}
