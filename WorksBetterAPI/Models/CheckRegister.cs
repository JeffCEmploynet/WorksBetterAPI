using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models;

public class CheckRegister
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long CheckNumber { get; set; }
    public decimal RHours { get; set; }
    public decimal OHours { get; set; }
    public decimal? DHours { get; set; }
    public decimal PayRate { get; set; }
    public decimal OTPayRate { get; set; }
    public decimal? DTPayRate { get; set; }
    public decimal GrossPay { get; set; }
    public decimal NetPay { get; set; }
    public decimal LocalTaxes { get; set; }
    public decimal StateTaxes { get; set; }
    public decimal FederalTaxes { get; set; }
    public DateTime WeekEndingDate { get; set; }
    public DateTime WeekEndingBill { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long EmployeeId { get; set; }
    public string StreetOne {  get; set; }
    public string? StreetTwo { get; set;}
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}
