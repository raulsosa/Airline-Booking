TimeZoneInfo ny = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
TimeZoneInfo shanghai = TimeZoneInfo.FindSystemTimeZoneById("Asia/Shanghai");
DateTime NYdeparture = new DateTime(2026, 11, 2, 4, 30, 0);
DateTime CHarrival = new DateTime(2026, 11, 3, 12, 15, 0);
TimeSpan offsetNY = ny.GetUtcOffset(NYdeparture);
TimeSpan offsetChina = shanghai.GetUtcOffset(CHarrival);
DateTimeOffset departure = new DateTimeOffset(NYdeparture, offsetNY);
DateTimeOffset arrival = new DateTimeOffset(CHarrival, offsetChina);


Passenger passenger = new Passenger("Raul", "Sosa", 001);
Flight flight = new Flight("AA", 0498, "N-34502", "JFK", "pvg", departure, arrival);
Seat seat = new Seat(5, 'C');
BookingService service = new BookingService();
BookingResult result = service.BookSeat(passenger, flight, seat);

if (result.Worked)
{
    //calculate total duration time
    int durationHours = (int)Math.Floor(flight.Duration.TotalHours);
    int durationMinutes = flight.Duration.Minutes;
    Console.WriteLine($"{passenger.Name} is seated on seat {seat.Label}, on the American Airlines flight {flight.FlightNumber} (aircraft {flight.TailNumber}) from {flight.Route}. Flight leaves at {flight.Departure.ToString("MMM d, HH:mm zzz")} and arrives on {flight.Arrival.ToString("MMM d, HH:mm zzz")}. Estimated duration is {durationHours} hours {durationMinutes} minutes.");
    Console.WriteLine(result.Booking?.BookingStatus);
}
else
{
    Console.WriteLine($"Booking Failed! {result.Reason}");
    //Console.WriteLine($"{result.Booking?.BookingStatus}"); Failed bookings can't be cancelled since it was never created to begin with.
}
//Seat mapping
Console.WriteLine("----- Seat map -----");
Console.WriteLine($"{flight.Seats.Count} seats on this flight.");
Console.WriteLine($"First seat: {flight.Seats[0].Label}");
Console.WriteLine($"Last seat: {flight.Seats.Last().Label}");

//Booking rules
Console.WriteLine("----- Booking rules -----");
ShowResult("First booking, 5C", result);
ShowResult("Same seat again", service.BookSeat(passenger, flight, seat));
ShowResult("duplicate seat object, 5C", service.BookSeat(passenger, flight, new Seat(5, 'C')));
ShowResult("seat not on flight, 11A", service.BookSeat(passenger, flight, new Seat(11, 'A')));



Flight overlapping = MakeFlight(100, "G-459", "JFK", "LAX", At(11, 2, 10, -5), At(11, 2, 13, -8));
Flight later       = MakeFlight(101, "N16500","LAX", "JFK", At(11, 4, 10, -8), At(11, 4, 18, -5));

ShowResult("overlapping flight, 1A", service.BookSeat(passenger, overlapping, new Seat(1, 'A')));
ShowResult("later flight, 1A", service.BookSeat(passenger, later, new Seat(1, 'A')));

result.Booking?.Cancel();
ShowResult("rebook cancelled seat, 5C", service.BookSeat(passenger, flight, new Seat(5, 'C')));
ShowResult("valid free seat, 10F", service.BookSeat(passenger, flight, new Seat(10, 'F')));

Console.WriteLine("----- Aircraft rules -----");
Flight sameAircraft = MakeFlight(102, "N-34502", "JFK", "BOS", At(11, 2, 11, -5), At(11, 2, 12, -5));
FlightSchedule schedule = new FlightSchedule();

ShowSchedule("first flight, N-34502", schedule.AddFlight(flight));
ShowSchedule("overlapping, different aircraft", schedule.AddFlight(overlapping));
ShowSchedule("overlapping, same aircraft", schedule.AddFlight(sameAircraft));
ShowSchedule("later flight", schedule.AddFlight(later));


void ShowResult(string label, BookingResult r)
{
    string outcome = r.Worked ? "accepted" : $"refused: {r.Reason}";
    Console.WriteLine($"{label} -> {outcome}"); 
}
DateTimeOffset At(int month, int day, int hour, int offsetHours) =>
    new DateTimeOffset(2026, month, day, hour, 0, 0, TimeSpan.FromHours(offsetHours));

Flight MakeFlight(int code, string tailNumber, string from, string to, DateTimeOffset dep, DateTimeOffset arr) =>
    new Flight("AA", code, tailNumber, from, to, dep, arr);

void ShowSchedule(string label, ScheduleResult r)
{
    string outcome = r.Worked ? $"accepted (flight ID {r.Flight?.FlightId})" : $"refused: {r.Reason}";
    Console.WriteLine($"{label} -> {outcome}");
}