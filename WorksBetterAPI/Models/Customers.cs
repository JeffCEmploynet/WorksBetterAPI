using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models;

public class Customers
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    public string CustomerName { get; set; }
    public string Department {  get; set; }
    public string MainContact {  get; set; }
    public string Phone {  get; set; }
    public string Email { get; set; }
    public string Street { get; set; }
    public string? StreetTwo { get; set; }
    public string City { get; set; }
    public string Zip {  get; set; }
    public string State { get; set; }

    public string Branch { get; set; }
    public string? AccountManager { get; set; }
    public string? SalesTeam { get; set; }
    public DateTime? ActiveDate { get; set; }
    public string? PayTerms { get; set; }
    public string? Note {  get; set; }
    public string? Status { get; set; }
}
