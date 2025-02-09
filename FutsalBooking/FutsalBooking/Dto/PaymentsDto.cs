namespace FutsalBooking.Dto
{
    public class PaymentsDto
    {
        public int id { get; set; }
        public int reservation_id { get; set; }
        public float amount { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
    }
}
