namespace Batapp1.Models
{
    public class BoatBooking
    {
        public string BoatName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string BookedBy { get; set; } = string.Empty;
    }
}
