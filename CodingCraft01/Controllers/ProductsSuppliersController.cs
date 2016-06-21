using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingCraft01.Models;

namespace CodingCraft01.Controllers
{
    public class ProductsSuppliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductsSuppliers
        public ActionResult Index()
        {
            var productsSuppliers = db.ProductsSuppliers.Include(p => p.Product).Include(p => p.Supplier);
            return View(productsSuppliers.ToList());
        }

        // GET: ProductsSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsSuppliers productsSuppliers = db.ProductsSuppliers.Find(id);
            if (productsSuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsSuppliers);
        }

        // GET: ProductsSuppliers/Create
        public ActionResult Create()
        {
            ViewBag.IdProduct = new SelectList(db.Products, "IdProduct", "Name");
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "Name");
            return View();
        }

        // POST: ProductsSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,IdProduct,IDSupplier")] ProductsSuppliers productsSuppliers)
        {
            if (ModelState.IsValid)
            {
                db.ProductsSuppliers.Add(productsSuppliers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProduct = new SelectList(db.Products, "IdProduct", "Name", productsSuppliers.IdProduct);
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "Name", productsSuppliers.IDSupplier);
            return View(productsSuppliers);
        }

        // GET: ProductsSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsSuppliers productsSuppliers = db.ProductsSuppliers.Find(id);
            if (productsSuppliers == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProduct = new SelectList(db.Products, "IdProduct", "Name", productsSuppliers.IdProduct);
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "Name", productsSuppliers.IDSupplier);
            return View(productsSuppliers);
        }

        // POST: ProductsSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,IdProduct,IDSupplier")] ProductsSuppliers productsSuppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsSuppliers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProduct = new SelectList(db.Products, "IdProduct", "Name", productsSuppliers.IdProduct);
            ViewBag.IDSupplier = new SelectList(db.Suppliers, "IDSupplier", "Name", productsSuppliers.IDSupplier);
            return View(productsSuppliers);
        }

        // GET: ProductsSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsSuppliers productsSuppliers = db.ProductsSuppliers.Find(id);
            if (productsSuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsSuppliers);
        }

        // POST: ProductsSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsSuppliers productsSuppliers = db.ProductsSuppliers.Find(id);
            db.ProductsSuppliers.Remove(productsSuppliers);
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
