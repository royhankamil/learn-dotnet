namespace esemkarailways.Models
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
