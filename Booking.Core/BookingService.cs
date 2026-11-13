public class BookingService
{
    private readonly List<Booking> _bookings = new List<Booking>();
    public IReadOnlyList<Booking> Bookings => _bookings;
    private int _bookingId = 1;
    public BookingResult BookSeat(Passenger passenger, Flight flight, Seat seat)
    {
        /* the top of BookSeat, before the duplicate check, loop through flight.Seats and set a bool flag to true 
        if any seat has the same row and column as the seat parameter.for loop, while loop, foreach loop*/
        bool seatIsAssignable = false;
        foreach(Seat seatsAvailable in flight.Seats)
        {
            if (seatsAvailable.Row == seat.Row && seatsAvailable.Column == seat.Column)
            {
                seatIsAssignable = true;
                break;
            }
        }
        if (!seatIsAssignable)
            {
                return BookingResult.No($"{seat.Label} can not be assigned to {flight.FlightNumber} flight.");
            }

        foreach(Booking existing in _bookings)
        {
            if (existing.Seat.Row == seat.Row && existing.Seat.Column == seat.Column && existing.Flight == flight && existing.BookingStatus == Status.Confirmed)
            {
               return BookingResult.No($"{seat.Label} is already taken on {flight.FlightNumber} flight.");
            }
            if(existing.BookingStatus == Status.Confirmed)
            {
                if (existing.Flight != flight && existing.Passenger.Id == passenger.Id && !(existing.Flight.Arrival <= flight.Departure || flight.Arrival <= existing.Flight.Departure))
                {
                    return BookingResult.No($"Passenger already has flight {existing.Flight.FlightNumber} booked at that time.");
                }
            }
            
        }
  
     Booking booking = new Booking(passenger, flight, seat);
     _bookings.Add(booking);
     _bookingId = _bookingId +1; // doesnt do anything right now. ID needs to added to booking class. 
     return BookingResult.Yes(booking);

    }
}
