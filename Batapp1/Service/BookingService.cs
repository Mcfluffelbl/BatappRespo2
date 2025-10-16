using Batapp1.Models;

namespace Batapp1.Service
{
    public class BookingService
    {
        private readonly List<BoatBooking> _bookings = new();

        public IEnumerable<BoatBooking> GetBookings() => _bookings;

        public void AddBooking(BoatBooking booking)
        {
            // Kolla så inte båten redan är bokad vid den tiden
            bool exists = _bookings.Any(b =>
                b.BoatName == booking.BoatName &&
                b.BookingDate.Date == booking.BookingDate.Date &&
                b.BookingTime == booking.BookingTime);

            if (!exists)
                _bookings.Add(booking);
            else
                throw new Exception("Denna båt är redan bokad vid denna tid!");
        }
    }
}
