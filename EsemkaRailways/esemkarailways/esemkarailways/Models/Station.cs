namespace esemkarailways.Models
{
    public class Station
    {
        public int StationID {  get; set; }
        public string StationName { get; set; }
        public string Location { get; set; }
        public ICollection<Schedule> DepartureSchedules { get; set; }
        public ICollection<Schedule> ArrivalSchedules { get; set; }


    }
}
