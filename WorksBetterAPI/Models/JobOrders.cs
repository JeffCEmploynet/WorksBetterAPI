using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WorksBetterAPI.Models;

public class JobOrders
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long JobOrdersId { get; set; }
    [Required]
    public string CustomerName { get; set; }
    public long CustomerId { get; set; }
    public string JobTitle { get; set; }
    public string? JobDescription { get; set; }
    public string WorksiteState { get; set; }
    public string WorksiteCity { get; set; }
    public string WorksiteZip {  get; set; }
    public decimal PayRate { get; set; }
    public decimal BillRate { get; set; }
    public double BillCalc {  get; set; }
    public double OTBillCalc { get; set; }
    public double? DTBillCalc { get; set; }
    public int  CountNeed {  get; set; }
    public int CountFilled { get; set; }
    public string Branch {  get; set; }
    public Int32 BranchId { get; set; }
    public DateTime OpenDate { get; set; }
    public string Status { get; set; }
    public DateTime? CloseDate { get; set; }
}
