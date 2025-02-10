namespace esemkarailways.Dto
{
    public class ScheduleDto
    {
        public int TrainID { get; set; }
        public int DepartureStationID { get; set; }
        public int ArrivalStationID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
