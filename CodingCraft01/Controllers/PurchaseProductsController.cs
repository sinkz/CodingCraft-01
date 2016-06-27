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
    public class PurchaseProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchaseProducts
        public async Task<ActionResult> Index()
        {
            var purchasesProducts = db.PurchasesProducts.Include(p => p.Product).Include(p => p.Purchase);
            return View(await purchasesProducts.ToListAsync());
        }

        // GET: PurchaseProducts/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseProduct purchaseProduct = await db.PurchasesProducts.FindAsync(id);
            if (purchaseProduct == null)
            {
                return HttpNotFound();
            }
            return View(purchaseProduct);
        }

        // GET: PurchaseProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseID", "PurchaseID");
            return View();
        }

        // POST: PurchaseProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseProductID,ProductId,PurchaseId,Quantity,Price")] PurchaseProduct purchaseProduct)
        {
            if (ModelState.IsValid)
            {
                purchaseProduct.PurchaseProductId = Guid.NewGuid();
                db.PurchasesProducts.Add(purchaseProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", purchaseProduct.ProductId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseID", "PurchaseID", purchaseProduct.PurchaseId);
            return View(purchaseProduct);
        }

        // GET: PurchaseProducts/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseProduct purchaseProduct = await db.PurchasesProducts.FindAsync(id);
            if (purchaseProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", purchaseProduct.ProductId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseID", "PurchaseID", purchaseProduct.PurchaseId);
            return View(purchaseProduct);
        }

        // POST: PurchaseProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseProductID,ProductId,PurchaseId,Quantity,Price")] PurchaseProduct purchaseProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", purchaseProduct.ProductId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseID", "PurchaseID", purchaseProduct.PurchaseId);
            return View(purchaseProduct);
        }

        // GET: PurchaseProducts/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseProduct purchaseProduct = await db.PurchasesProducts.FindAsync(id);
            if (purchaseProduct == null)
            {
                return HttpNotFound();
            }
            return View(purchaseProduct);
        }

        // POST: PurchaseProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PurchaseProduct purchaseProduct = await db.PurchasesProducts.FindAsync(id);
            db.PurchasesProducts.Remove(purchaseProduct);
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
