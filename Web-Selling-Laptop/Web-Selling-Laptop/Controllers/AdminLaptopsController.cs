using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Selling_Laptop.Models;

namespace Web_Selling_Laptop.Controllers
{
    public class AdminLaptopsController : Controller
    {
        private LaptopDBContext db = new LaptopDBContext();

        // GET: AdminLaptops
        public ActionResult Index()
        {
            var laptops = db.Laptops.Include(l => l.Category);
            return View(laptops.ToList());
        }

        // GET: AdminLaptops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: AdminLaptops/Create
        public ActionResult Create()
        {
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName");
            return View();
        }

        // POST: AdminLaptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaptopId,LaptopName,CPU,RAM,Card,HDH,USB,Price,ImgPath,CateId")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                db.Laptops.Add(laptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", laptop.CateId);
            return View(laptop);
        }

        // GET: AdminLaptops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", laptop.CateId);
            return View(laptop);
        }

        // POST: AdminLaptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaptopId,LaptopName,CPU,RAM,Card,HDH,USB,Price,ImgPath,CateId")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", laptop.CateId);
            return View(laptop);
        }

        // GET: AdminLaptops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: AdminLaptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laptop laptop = db.Laptops.Find(id);
            db.Laptops.Remove(laptop);
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
