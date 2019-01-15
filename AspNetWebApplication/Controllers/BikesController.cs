using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetWebApplication.Models;

namespace AspNetWebApplication.Controllers
{
    public class BikesController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: Bikes
        public ActionResult Index(string sortOrder)
        {
            var bikesDb = db.Bikes.Include(b => b.CurrentCategory);

            var bikesList = new List<Double>();
            foreach(var item in bikesDb)
                {
                bikesList.Add(item.Weight);
            }
            ViewBag.BikesMaxWeight = bikesList.Max();


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Brand" ? "brand_desc" : "Brand";
            var bikes = db.Bikes.Include(b => b.CurrentCategory);

            

            switch (sortOrder)
            {
                case "name_desc":
                    bikes = from b in bikes orderby b.Name descending select b;
                    break;
                case "Brand":
                    bikes = from b in bikes orderby b.Brand select b;
                    break;
                case "brand_desc":
                    bikes = from b in bikes orderby b.Brand descending select b;
                    break;
                default:
                    bikes = from b in bikes orderby b.Name select b;
                    break;
            }
            return View(bikes.ToList());


            //return View(bikes.ToList());
        }

        // GET: Bikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            ViewBag.Category = db.Categories.Find(bike.CurrentCategoryId);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // GET: Bikes/Create
        public ActionResult Create()
        {
            ViewBag.CurrentCategoryId = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Bikes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Brand,Weight,CurrentCategoryId")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Bikes.Add(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentCategoryId = new SelectList(db.Categories, "ID", "Name", bike.CurrentCategoryId);
            return View(bike);
        }

        // GET: Bikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentCategoryId = new SelectList(db.Categories, "ID", "Name", bike.CurrentCategoryId);
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Brand,Weight,CurrentCategoryId")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentCategoryId = new SelectList(db.Categories, "ID", "Name", bike.CurrentCategoryId);
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bike bike = db.Bikes.Find(id);
            db.Bikes.Remove(bike);
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
