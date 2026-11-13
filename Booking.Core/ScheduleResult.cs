public class ScheduleResult
{
    public bool Worked {get;} 
    public string? Reason {get;}
    public Flight? Flight {get;}
    private ScheduleResult(bool worked, string? reason, Flight? flight)
    {
        Worked = worked;
        Reason = reason;
        Flight = flight;
    }

    public static ScheduleResult Yes(Flight flight) => new ScheduleResult(true, null, flight);
    public static ScheduleResult No(string reason) => new ScheduleResult(false, reason, null);
}