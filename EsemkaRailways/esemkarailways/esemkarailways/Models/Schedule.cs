namespace esemkarailways.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int TrainID { get; set; }
        public int DepartureStationID { get; set; }
        public int ArrivalStationID {  get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Train? Train { get; set; }
        public Station? DepartureStation { get; set; }
        public Station? ArrivalStation { get; set; }

    }
}
