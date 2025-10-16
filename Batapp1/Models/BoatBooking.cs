namespace Batapp1.Models
{
    public class BoatBooking
    {
        public int Id { get; set; }
        public string BoatName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string BookedBy { get; set; } = string.Empty;
    }
}
