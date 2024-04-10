using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models;

public class TaxSetup
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public string? Zip {  get; set; }
    public double? LocalTax { get; set; }
    public string? State { get; set; }
    public double? StateTax { get; set; }
    public double FederalTax { get; set; }
    public decimal? AddedWithholding { get; set; }
}
