using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WorksBetterAPI.Models;

public class Timecards
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public long AssignmentId { get; set; }
    public long EmployeeId { get; set; }
    public long CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Branch {  get; set; }
    public Int32 BranchId { get; set; }
    public decimal? RHours { get; set; }
    public decimal? OHours { get; set; }
    public decimal? DHours { get; set; }
    public string PayCode { get; set; }
    public DateTime WeekEndingDate { get; set; }
    public decimal PayRate { get; set; }
    public decimal OTPayRate { get; set; }
    public decimal? DTPayRate { get; set; }
    public decimal BillRate { get; set; }
    public decimal OTBillRate {  get; set; }
    public decimal? DTBillRate { get; set; }
    public long? SessionId { get; set; }
    public string? SessionUser { get; set; }
    public string? Status { get; set; }
    public DateTime ProcessingWeek { get; set; }
}
