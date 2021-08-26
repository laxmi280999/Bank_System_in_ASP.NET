using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bank.Models;

namespace Bank.ViewModels
{
    public class CustomerAndAccountDetailsViewModel
    {
        public Customer Customers { get; set; }
        public Acount Acounts { get; set; }

        public AccountType AccountType { get; set; }

    }
}