public class Seat{
    public int Row {get;}
    public char Column {get;}
    public string Label => $"{Row}{Column}";

    public Seat(int seatRow, char seatColumn)
    {
        if(seatRow <= 0 || seatRow > 500)
            {
                throw new ArgumentOutOfRangeException(nameof(seatRow),"Seat row must be within 1 and 500.");
            }

        if (!char.IsAsciiLetter(seatColumn))
        {
            throw new ArgumentException("Not a valid column letter.", nameof(seatColumn));
        }
 //the letter I is skipped on all airplanes to avoid confusions with 1, and l on bording passes. 
// Some airlines also skip O, Q, S, and Z. 
// Reminder to do that later.
        //Lets try to make it capital
        char makeColCaps = char.ToUpperInvariant(seatColumn);

        Row = seatRow;
        Column = makeColCaps;
    }
}
