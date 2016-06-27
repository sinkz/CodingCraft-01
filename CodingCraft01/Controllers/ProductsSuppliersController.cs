using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var productsSuppliers = db.ProductsSuppliers.Include(p => p.Product).Include(p => p.Supplier);
            return View(await productsSuppliers.ToListAsync());
        }

        // GET: ProductsSuppliers/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSupplier productsSuppliers = await db.ProductsSuppliers.FindAsync(id);
            if (productsSuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsSuppliers);
        }

        // GET: ProductsSuppliers/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name");
            return View();
        }

        // POST: ProductsSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductSupplierId,Price,ProductId,SupplierId")] ProductSupplier productsSuppliers)
        {
            if (ModelState.IsValid)
            {
                productsSuppliers.ProductSupplierId = Guid.NewGuid();
                db.ProductsSuppliers.Add(productsSuppliers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productsSuppliers.ProductId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", productsSuppliers.SupplierId);
            return View(productsSuppliers);
        }

        // GET: ProductsSuppliers/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSupplier productsSuppliers = await db.ProductsSuppliers.FindAsync(id);
            if (productsSuppliers == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productsSuppliers.ProductId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", productsSuppliers.SupplierId);
            return View(productsSuppliers);
        }

        // POST: ProductsSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductSupplierId,Price,ProductId,SupplierId")] ProductSupplier productsSuppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsSuppliers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", productsSuppliers.ProductId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", productsSuppliers.SupplierId);
            return View(productsSuppliers);
        }

        // GET: ProductsSuppliers/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSupplier productsSuppliers = await db.ProductsSuppliers.FindAsync(id);
            if (productsSuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsSuppliers);
        }

        // POST: ProductsSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProductSupplier productsSuppliers = await db.ProductsSuppliers.FindAsync(id);
            db.ProductsSuppliers.Remove(productsSuppliers);
            await db.SaveChangesAsync();
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
