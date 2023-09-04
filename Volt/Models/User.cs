namespace Volt.Models;

public class User
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }

    public User(string username, string firstName, string lastName)
    {
        UserName = username;
        FirstName = firstName;
        LastName = lastName;
        FullName = $"{firstName} {lastName}";
    }
}
