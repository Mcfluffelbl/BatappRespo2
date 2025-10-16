namespace Batapp1.Models
{
    public class BoatBooking
    {
        public int Id { get; set; }
        public string BoatName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string BookedBy { get; set; } = string.Empty;
    }
}
