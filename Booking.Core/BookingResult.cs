public class BookingResult
{
    public bool Worked {get;} 
    public string? Reason {get;}
    public Booking? Booking {get;}
    private BookingResult(bool worked, string? reason, Booking? booking)
    {
        Worked = worked;
        Reason = reason;
        Booking = booking;
    }

    public static BookingResult Yes(Booking booking) => new BookingResult(true, null, booking);
    public static BookingResult No(string reason) => new BookingResult(false, reason, null);
}