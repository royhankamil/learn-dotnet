namespace FutsalBooking.Dto
{
    public class PaymentsDto
    {
        public int id { get; set; }
        public int reservation_id { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
    }
}
