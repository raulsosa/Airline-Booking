public class Booking{
   public Passenger Passenger {get; private set;}
   public Flight Flight {get; private set;}
   public Seat Seat{get; private set;}

   public Booking(Passenger passenger, Flight flight, Seat seat)
    {
        Passenger = passenger;
        Flight = flight;
        Seat = seat;
    }

}