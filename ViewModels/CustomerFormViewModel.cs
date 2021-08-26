using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bank.Models;

namespace Bank.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<AccountType> AccountTypes { get; set; }
        public Acount Acount { get; set; }
        public Customer Customer { get; set; }
    }
}