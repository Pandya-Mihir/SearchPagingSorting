using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SearchPagingSorting.App_Data;
using SearchPagingSorting.Models;

namespace SearchPagingSorting.Controllers
{
    public class customer_tableController : Controller
    {
        private crudopEntities db = new crudopEntities();

        private ToViewModel ViewModelObj = new ToViewModel();

        // GET: customer_table
        public ActionResult Index( string FnameSs, string SnameSs, string EmailSs, string CountrySs, string StateSs, string CitySs)
        {

           
            if (!String.IsNullOrEmpty(FnameSs))
            {
                return View(db.customer_table.Where(n => n.Cust_fname.Contains(FnameSs)|| FnameSs == null).ToList());
            }
            //else if (!Int32.TryParse())
            //{
            //    return View(db.customer_table.Where(n => n.customer_id.Contains(IdSs) || IdSs == null).ToList());
            //}
            else if (!String.IsNullOrEmpty(SnameSs))
            {
                return View(db.customer_table.Where(n => n.csut_sname.Contains(SnameSs) || SnameSs == null).ToList());
            }
            else if (!String.IsNullOrEmpty(EmailSs))
            {
                return View(db.customer_table.Where(n => n.Email.Contains(EmailSs) || EmailSs == null).ToList());
            }
            else if (!String.IsNullOrEmpty(CountrySs))
            {
                return View(db.customer_table.Where(n => n.Country.Contains(CountrySs) || CountrySs == null).ToList());
            }
            else if (!String.IsNullOrEmpty(StateSs))
            {
                return View(db.customer_table.Where(n => n.State.Contains(StateSs) || StateSs == null).ToList());
            }
            else if (!String.IsNullOrEmpty(CitySs))
            {
                return View(db.customer_table.Where(n => n.City.Contains(CitySs) || CitySs == null).ToList());
            }
            else
            {
                return View(db.customer_table.ToList());
            }
        }

        // GET: customer_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_table customer_table = db.customer_table.Find(id);
            if (customer_table == null)
            {
                return HttpNotFound();
            }
            return View(customer_table);
        }

        // GET: customer_table/Create
        public ActionResult Create()
        {
            CustomerModel obj = new CustomerModel();
            return View(obj);
        }

        // POST: customer_table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,Cust_fname,csut_sname,Email,Country,State,City,IsActive")] CustomerModel Customer)
        {
            if (ModelState.IsValid)
            {
                db.customer_table.Add(ViewModelObj.ToCustomer(Customer));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Customer);
        }

        // GET: customer_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_table customer_table = db.customer_table.Find(id);
            CustomerModel obj1 = ViewModelObj.CustomerToData(customer_table);
            if (customer_table == null)
            {
                return HttpNotFound();
            }
            return View(obj1);
        }

        // POST: customer_table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,Cust_fname,csut_sname,Email,Country,State,City,IsActive")] CustomerModel Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ViewModelObj.ToCustomer(Customer)).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Customer);
        }

        // GET: customer_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_table customer_table = db.customer_table.Find(id);

            if (customer_table == null)
            {
                return HttpNotFound();
            }
            return View(customer_table);
        }

        // POST: customer_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customer_table customer_table = db.customer_table.Find(id);
            db.customer_table.Remove(customer_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
