using Batapp1.Models;

namespace Batapp1.Service
{
    public class BookingService
    {
        private readonly List<BoatBooking> _bookings = new();

        public IEnumerable<BoatBooking> GetBookings() => _bookings;

        public void AddBooking(BoatBooking booking)
        {
            // Kontrollera överlappning för varje existerande bokning
            bool overlaps = _bookings.Any(b =>
                b.BoatName == booking.BoatName &&
                DatesOverlap(b.StartDate, b.EndDate, booking.StartDate, booking.EndDate) &&
                TimesOverlap(b, booking)
            );

            if (overlaps)
                throw new Exception("Denna båt är redan bokad under den perioden!");

            _bookings.Add(booking);
        }

        /// <summary>
        /// Kollar om två datumintervall överlappar.
        /// </summary>
        private bool DatesOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 <= end2 && start2 <= end1;
        }

        /// <summary>
        /// Om bokningen är för flera dagar, tillåt samma tider andra dagar.
        /// Men om någon dag överlappar och tiden också gör det – det är konflikt.
        /// </summary>
        private bool TimesOverlap(BoatBooking b1, BoatBooking b2)
        {
            // Om bokningen överlappar enbart på datum men tider är helt olika, så är det okej.
            // Om datumen överlappar men också tiderna överlappar – då är det konflikt.
            return b1.StartTime < b2.EndTime && b2.StartTime < b1.EndTime;
        }
    }
}
