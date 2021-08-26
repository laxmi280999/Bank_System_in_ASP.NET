using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bank.Models;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Acount
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public AccountType AccountType { get; set; }

        [Display(Name ="Account Type")]
        public int AccountTypeId { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name ="Account Number")]
        public string AccountNumber { get; set; }

        public int Balance { get; set; }
    }
}