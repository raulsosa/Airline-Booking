public class Booking{
   public Passenger Passenger {get; private set;}
   public Flight Flight {get; private set;}
   public Seat Seat{get; private set;}
   public Status BookingStatus{get; private set;}
   public Booking(Passenger passenger, Flight flight, Seat seat)
    {
        Passenger = passenger;
        Flight = flight;
        Seat = seat;
        BookingStatus = Status.Confirmed;
    }

/*  
    Add a Cancel() method to Booking that sets Status to Cancelled. 
    It has to live inside Booking, since the setter is private, so only the class can change it.
*/
    public Status Cancel()
    {
        BookingStatus = Status.Cancelled;
        return BookingStatus;
    }
}
