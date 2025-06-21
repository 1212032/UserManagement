namespace Domain.User;

public class User : IEquatable<User>{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set;}
    public string Password { get; set;}

    private User()
    {
        Id= Guid.NewGuid();
     }
    public User(string username, string useremail, string password)
    {
        Id= Guid.NewGuid();
        UserName = username;
        UserEmail = useremail;
        Password = password;
    }
    
    public bool Equals(User? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return string.Equals(UserName, other.UserName, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(UserEmail, other.UserEmail, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj) => Equals(obj as User);

    public override int GetHashCode()
    {
        return HashCode.Combine(
            UserName?.ToLowerInvariant(),
            UserEmail?.ToLowerInvariant()
        );
    }

    
}