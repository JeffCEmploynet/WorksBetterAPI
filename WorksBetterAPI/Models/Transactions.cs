using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models;

public class Transactions
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long AssignmentId { get; set; }
    public long EmployeeId { get; set; }
    public string CustomerName { get; set; }
    public long CustomerId { get; set; }
    public string BranchName { get; set; }
    public Int32 BranchId { get; set; }
    public string PayCode { get; set; }
    public decimal RHours { get; set; }
    public decimal OHours { get; set; }
    public decimal DHours { get; set; }
    public decimal PayRate { get; set; }
    public decimal OTPayRate { get; set; }
    public decimal? DTPayRate { get; set; }
    public decimal BillRate { get; set; }
    public decimal OTBillRate { get; set; }
    public decimal? DTBillRate { get; set; }
    public decimal GrossPay {  get; set; }
    public decimal NetPay {  get; set; }
    public decimal TotalBill {  get; set; }
    public decimal LocalTaxes { get; set; }
    public decimal StateTaxes { get; set; }
    public decimal FederalTaxes { get; set; }
    public DateTime? WeekEndingDate { get; set; }
    public DateTime? WeekEndingBill {  get; set; }
    public long InvoiceNumber { get; set; }
    public long CheckId { get; set; }
}
