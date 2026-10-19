public class Passenger{
    public int Id {get;} //remove set since an ID should never be editable.
    public string FirstName {get; private set;} 
    public string LastName {get; private set;}
    public string Name => $"{LastName}, {FirstName}";
    public Passenger (string firstName, string lastName, int id)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name is invalid.", nameof(firstName));
            }
        if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name is invalid.", nameof(lastName));
            }    
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive number.");
        }

        FirstName = firstName.Trim().ToUpperInvariant();
        LastName = lastName.Trim().ToUpperInvariant();
        Id = id;
    }
}