using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bank.Models;

namespace Bank.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public Acount Acount { get; set; }

    }
}