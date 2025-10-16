using Batapp1.Models;

namespace Batapp1.Service
{
    public class BookingService
    {
        private readonly List<BoatBooking> _bookings = new();

        public IEnumerable<BoatBooking> GetBookings() => _bookings;

        public void AddBooking(BoatBooking booking)
        {
            // Kolla om tider överlappar
            bool overlaps = _bookings.Any(b =>
                b.BoatName == booking.BoatName &&
                b.BookingDate.Date == booking.BookingDate.Date &&
                booking.StartTime < b.EndTime &&
                booking.EndTime > b.StartTime);

            if (overlaps)
                throw new Exception("Denna båt är redan bokad under den tiden!");

            _bookings.Add(booking);
        }
    }
}
