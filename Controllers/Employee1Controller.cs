using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class Employee1Controller : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();        // GET: StoredProcedure
        public ActionResult Index()
        {
            var getEmp = dc.spCrud(null,null, null, null, "Select").ToList();
            return View();
        }

        // GET: StoredProcedure/Details/5
        public ActionResult Details(int id)
        {
            var empdetails = dc.spCrud(id, null, null, null, "Details").SingleOrDefault(x => x.Id == id);
            return View();
        }

        // GET: StoredProcedure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoredProcedure/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoredProcedure/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoredProcedure/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoredProcedure/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoredProcedure/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
