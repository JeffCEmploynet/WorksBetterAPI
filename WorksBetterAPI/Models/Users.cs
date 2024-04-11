namespace WorksBetterAPI.Models;

public class Users
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public static string FirstName { get; set; }
    public static string LastName { get; set; }
    public static string BranchName { get; set; }
    public static Int32 BranchId { get; set; }
    public static string UserType { get; set; }
    public static Int32 AuthLevel { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
