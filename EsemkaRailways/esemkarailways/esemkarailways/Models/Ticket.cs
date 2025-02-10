namespace esemkarailways.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int PassengerID { get; set; }
        public int ScheduleID { get; set; }
        public string SeatNumber { get; set; }
        public DateTime BookingTime { get; set; }
        public Passenger? Passenger { get; set; }
        public Schedule? Schedule { get; set; }

    }
}
