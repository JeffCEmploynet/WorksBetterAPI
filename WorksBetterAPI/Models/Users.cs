using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WorksBetterAPI.Models;

public class Users
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BranchName { get; set; }
    public Int32 BranchId { get; set; }
    public Int32 AuthLevel { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
