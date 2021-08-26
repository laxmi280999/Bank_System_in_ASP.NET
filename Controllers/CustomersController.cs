using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Bank.Models;
using Bank.ViewModels;

namespace Bank.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = from c in _context.Customers
                join a in _context.Acounts on c.Id equals a.CustomerId
                join at in _context.AccountTypes on a.AccountTypeId equals at.Id
                select new CustomerAndAccountDetailsViewModel
                {
                    Customers = c, 
                    Acounts = a,
                    AccountType = at
                };
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var accountTypes = _context.AccountTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                AccountTypes = accountTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer, Acount acount)
        {
            /*
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    Acount = acount,
                    AccountTypes = _context.AccountTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            */

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                _context.Acounts.Add(acount);
            }
            else
            {
                var cust = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                cust.Name = customer.Name;
                cust.Gender = customer.Gender;
                cust.Birthdate = customer.Birthdate;
                cust.Address = customer.Address;
                cust.Phone = customer.Phone;
                cust.Email = customer.Email;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var account = _context.Acounts.Include(a => a.AccountType).SingleOrDefault(a => a.CustomerId == id);

            if(customer == null || account == null)
            {
                return View("NotFound");
            }

            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                Acount = account,

            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var account = _context.Acounts.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null || account == null)
            {
                return View("NotFound");
            }

            var viewModel = new CustomerFormViewModel
            {
                AccountTypes = _context.AccountTypes.ToList(),
                Acount = account,
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult DeleteCustomer (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var account = _context.Acounts.Include(a => a.AccountType).SingleOrDefault(a => a.CustomerId == id);

            if (customer == null || account == null)
            {
                return View("NotFound");
            }

            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                Acount = account,

            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Delete (int id)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                }

                if (ModelState.IsValid)
                {
                    TempData["message"] = "Your data has been deleted.";
                }

                return RedirectToAction("Index", "Customers");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please select an excel file<br />";
                return View("ImportData");
            }
            else
            {
                string fileExtension = System.IO.Path.GetExtension(excelfile.FileName);

                if (fileExtension.EndsWith(".xls") || fileExtension.EndsWith(".xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + excelfile.FileName);

                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    excelfile.SaveAs(path);


                    //Import data
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(Server.MapPath("~/Content/" + excelfile.FileName));
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;

                    List<Customer> customers = new List<Customer>();
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        Customer c = new Customer();

                        string s1 = ((Excel.Range)range.Cells[row, 3]).Text;
                        //DateTime dt = Convert.ToDateTime(((Excel.Range)range.Cells[row, 3]).Text);
                        //string s2 = s1.ToString("dd-MM-yyyy");
                        DateTime dtnew = Convert.ToDateTime(s1);
                        

                        c.Name = ((Excel.Range)range.Cells[row, 1]).Text;
                        c.Gender = ((Excel.Range)range.Cells[row, 2]).Text;
                        c.Birthdate = dtnew;
                        c.Address = ((Excel.Range)range.Cells[row, 4]).Text;
                        c.Phone = ((Excel.Range)range.Cells[row, 5]).Text;
                        c.Email = ((Excel.Range)range.Cells[row, 6]).Text;

                        customers.Add(c);

                    }
                    ViewBag.ListCustomers = customers;
                    workbook.Close(false);
                    application.Quit();
                    //System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
                    
                    return View("ImportData");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect";
                    return View("Index");
                }
            }

        }

        [HttpPost]
        public ActionResult SaveToDB(Customer customer)
        {
            try
            {
                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);
                }
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return View("Error");
            }

            return Content("Data has been added to database.");
        }
    }
}