using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models;

public class InvoiceRegister
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string CustomerName { get; set; }
    public long CustomerId {  get; set; }
    public decimal RHours { get; set; }
    public decimal OHours { get; set; }
    public decimal? DHours { get; set; }
    public decimal BillRate { get; set; }
    public decimal OBillRate { get; set; }
    public decimal DBillRate { get; set; }
    public decimal TotalBill {  get; set; }
    public decimal AmountPaid { get; set; }
    public decimal AmountDue { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public DateTime WeekEndingDate { get; set; }
    public DateTime WeekEndingBill {  get; set; }
    public string PayTerms { get; set; }
    public string StreetOne { get; set; }
    public string? StreetTwo { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}
