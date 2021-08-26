using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bank.Models;

namespace Bank.Controllers
{
    public class EmployeeController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Employee
        public ActionResult Index()
        {
            var getEmp = dc.spCrud(null, null, null, null, "Select").ToList();
            return View(getEmp);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var empdetails = dc.spCrud(id, null, null, null, "Details").SingleOrDefault(x => x.Id == id);
            return View(empdetails);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                // TODO: Add insert logic here
                dc.spCrud(null, emp.Name, emp.Email, emp.Salary, "Insert");
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var empdetails = dc.spCrud(id, null, null, null, "Details").SingleOrDefault(x => x.Id == id);
            return View(empdetails);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                // TODO: Add update logic here
                dc.spCrud(id, emp.Name, emp.Email, emp.Salary, "Update");
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var empdetails = dc.spCrud(id, null, null, null, "Details").SingleOrDefault(x => x.Id == id);
            return View(empdetails);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                // TODO: Add delete logic here
                dc.spCrud(id, null, null, null, "Delete");
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
