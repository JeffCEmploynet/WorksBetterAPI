using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models;

public class LoginAudit
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string UserName { get; set; }
    public DateTime LoginDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public Guid Token { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BranchName { get; set; }
    public Int32 BranchId { get; set; }
    public string UserType { get; set; }
    public Int32 AuthLevel { get; set; }
}