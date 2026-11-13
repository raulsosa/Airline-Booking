public class FlightSchedule
{
 private readonly List<Flight> _flights = [];
 public IReadOnlyList<Flight> Flights => _flights;
 private int _flightId = 1;
 public ScheduleResult AddFlight(Flight flight)
    {
        foreach (Flight existing in _flights)
        {
            if(existing.TailNumber == flight.TailNumber && existing.Departure < flight.Arrival && flight.Departure < existing.Arrival)
            {
                return ScheduleResult.No($"Aircraft {existing.TailNumber} is already scheduled on flight {existing.FlightNumber} at that time."); 
            }

        }
        //The fix is shorter than what you have. Assign the ID, add the same flight object to _flights, and return ScheduleResult.Yes(flight). Delete the ConfirmedFlight line.
        flight.FlightId = _flightId;
        _flights.Add(flight);
        _flightId++;
        return ScheduleResult.Yes(flight);
    }

}