using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models;

public class Checks
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public decimal NetPay { get; set; }
    public decimal GrossPay { get; set; }
    public long EmployeeId { get; set; }
    public DateTime WeekEndingDate { get; set; }
}
