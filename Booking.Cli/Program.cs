TimeZoneInfo ny = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
TimeZoneInfo shanghai = TimeZoneInfo.FindSystemTimeZoneById("Asia/Shanghai");
DateTime NYdeparture = new DateTime(2026, 11, 2, 4, 30, 0);
DateTime CHarrival = new DateTime(2026, 11, 3, 12, 15, 0);
TimeSpan offsetNY = ny.GetUtcOffset(NYdeparture);
TimeSpan offsetChina = shanghai.GetUtcOffset(CHarrival);
DateTimeOffset departure = new DateTimeOffset(NYdeparture, offsetNY);
DateTimeOffset arrival = new DateTimeOffset(CHarrival, offsetChina);


Passenger passenger = new Passenger("Raul", "Sosa", 001);
Flight flight = new Flight("AA", 0498, "JKF", "pvg", departure, arrival);
Seat seat = new Seat(12, 'a');
Booking booking = new Booking(passenger, flight, seat);

//calculate total duration time
int durationHours = (int)Math.Floor(booking.Flight.Duration.TotalHours);
int durationMinutes = booking.Flight.Duration.Minutes;

Console.WriteLine($"{booking.Passenger.Name} is seated on seat {booking.Seat.Label}, on the American Airlines flight {booking.Flight.FlightNumber} from {booking.Flight.Route}. Flight leaves at {booking.Flight.Departure.ToString("MMM d, HH:mm zzz")} and arrives on {booking.Flight.Arrival.ToString("MMM d, HH:mm zzz")}. Estimated duration is {durationHours} hours {durationMinutes} minutes.");

try
{
DateTimeOffset departure2 = new DateTimeOffset(2026, 10, 26, 4, 30, 0, TimeSpan.FromHours(-4));
DateTimeOffset arrival2 = new DateTimeOffset(2026, 10, 26, 4, 15, 0, TimeSpan.FromHours(+8));
Flight flight2 = new Flight("AA", 0498, "JKF", "pvg", departure2, arrival2);
}
catch(Exception ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}
try
{
DateTimeOffset departure3 = new DateTimeOffset(2026, 10, 26, 4, 30, 0, TimeSpan.FromHours(-4));
DateTimeOffset arrival3 = new DateTimeOffset(2026, 10, 26, 4, 30, 0, TimeSpan.FromHours(-4));
Flight flight3 = new Flight("AA", 0498, "JKF", "pvg", departure3, arrival3);
}
catch(Exception ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

Console.WriteLine("Program keeps going");
Console.WriteLine(flight.Seats.Count);
Console.WriteLine(flight.Seats[0].Label);
Console.WriteLine(flight.Seats.Last().Label);
