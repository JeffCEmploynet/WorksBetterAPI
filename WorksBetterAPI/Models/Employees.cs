﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorksBetterAPI.Models
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? MiddleInitial {  get; set; }
        public string? SSN { get; set; }
        public string? Street { get; set; }
        public string? StreetTwo { get; set; }
        public string? City { get; set; }
        public string? Zip {  get; set; }
        public string? State { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? PhoneTwo {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Branch { get; set; }
        public Int32 BranchId { get; set; }
    }
}
