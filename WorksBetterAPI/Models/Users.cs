namespace WorksBetterAPI.Models;

public class Users
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BranchName { get; set; }
    public Int32 BranchId { get; set; }
    public string UserType { get; set; }
    public Int32 AuthLevel { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
