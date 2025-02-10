namespace esemkarailways.Models
{
    public class Train
    {
        public int TrainID {  get; set; }
        public string TrainName { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
