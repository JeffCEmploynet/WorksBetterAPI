using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WorksBetterAPI.Models;

public class Assignments
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long EmployeeId { get; set; }
    public long OrderId { get; set; }
    public string JobTitle { get; set; }
    public long CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Branch {  get; set; }
    public Int32 BranchId { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public decimal? PayRate { get; set; }
    public decimal? BillRate { get; set; }
    public decimal? OTBillRate { get; set; }
    public decimal? DTBillRate { get; set; }
    public decimal? Salary { get; set; }
    public int W2 { get; set; }
}
