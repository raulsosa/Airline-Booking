public class Flight{
    private readonly List<Seat> _seats = new List<Seat>();
    public IReadOnlyList<Seat> Seats => _seats;
    public int FlightId {get;}
    public int FlightCode {get;}
    public string AirlineCode {get;}
    public string FlightNumber => $"{AirlineCode}{FlightCode}";
    public string Origin {get;}
    public string Destination {get;}
    public string Route => $"{Origin} to {Destination}";
    public DateTimeOffset Departure {get;}
    public DateTimeOffset Arrival{get;}
    public TimeSpan Duration => Arrival - Departure;

    public Flight(string airlineCode, int flightCode ,string origin, string destination, DateTimeOffset departure, DateTimeOffset arrival){
    
        //an empty or whitespace-only airline code
        if (string.IsNullOrWhiteSpace(airlineCode))
        {
            throw new ArgumentException("Airline code cannot be empty or whitespace.", nameof(airlineCode));
        }

        //a flight code that isn’t positive
        if (flightCode <= 0 || flightCode > 9999)
        {
            throw new ArgumentOutOfRangeException(nameof (flightCode), "Flight code must be a positive number between 1 and 9999." ); 
        }
        
        //an empty or whitespace-only origin + make sure its only 3 characters long
        if (string.IsNullOrWhiteSpace(origin))
        {
            throw new ArgumentException("Origin cannot be empty or whitespace.", nameof(origin));
        }
        if (origin.Trim().Length !=3)
        {
            throw new ArgumentException("Origin airport must be exactly three characters long.", nameof(origin));
        }


        //an empty or whitespace only destination + make sure its only 3 characters long
        if (string.IsNullOrWhiteSpace(destination))
        {
            throw new ArgumentException("Destination cannot be empty or whitespace.", nameof(destination));
        }
        if (destination.Trim().Length !=3)
        {
            throw new ArgumentException("Destination airport must be exactly three characters long.", nameof(destination));
        }


        //if origin and destination are the same, compare it and throw an exception
        if(origin.Trim().Equals(destination.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Origin and destination can not be the same location.");
        }
        
         //Arrival must be later than departure and must not be equal
        if (departure >= arrival)
        {
            throw new ArgumentException("Arrival and departure cannot be the same date and timeframe. Arrival must also be later than departure date and timeframe.");
        }
       
        for(int row = 1; row <= 10; row++)
        {
            foreach(char col in "ABCDEF")
            {
                _seats.Add(new Seat(row, col));
            }
        }
    

        AirlineCode = airlineCode.Trim().ToUpperInvariant();
        FlightCode = flightCode;
        Origin = origin.Trim().ToUpperInvariant();
        Destination = destination.Trim().ToUpperInvariant();
        Departure = departure;
        Arrival = arrival;
    }

}
