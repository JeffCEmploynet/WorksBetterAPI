using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WorksBetterAPI.Models;

public class Branches
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int32 Id { get; set; }
    public string BranchName { get; set; }
    public string Email { get; set; }
    public string Phone {  get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip {  get; set; }
}
