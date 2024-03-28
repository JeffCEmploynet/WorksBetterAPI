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
    public string EmployeeName { get; set; }
    public long EmployeeId { get; set; }
    public long OrderId { get; set; }
    public string JobTitle { get; set; }
    public long CustomerId { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Shift { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public string? ShiftNotes { get; set; }
    public double? PayRate { get; set; }
    public double? BillRate { get; set; }
    public double? Salary { get; set; }
    public int W2 { get; set; }
}
