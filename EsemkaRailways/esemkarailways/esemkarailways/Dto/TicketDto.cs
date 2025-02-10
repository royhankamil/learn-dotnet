namespace esemkarailways.Dto
{
    public class TicketDto
    {
        public int PassengerID { get; set; }
        public int ScheduleID { get; set; }
        public List<string> SeatNumber { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
