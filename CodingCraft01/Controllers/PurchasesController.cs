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
    public class PurchasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Purchases
        public async Task<ActionResult> Index()
        {
            var purchases = db.Purchases.Include(p => p.Supplier);
            return View(await purchases.ToListAsync());
        }

        public ActionResult NewLineProducts(string input, Guid? PurchaseId = null)
        {
            ViewBag.Products = new SelectList(db.ProductsSuppliers.Where(p => p.SupplierId == new Guid(input)).Select(p => p.Product).ToList(),
                "ProductId", "Name", "Price");
            return PartialView("_LinePurchaseProduct", new PurchaseProduct { PurchaseProductId = Guid.NewGuid() });
        }



  
        // GET: Purchases/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name");
            return View(new Purchase
            {
                PurchaseProducts = new List<PurchaseProduct>()
            });
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseId,SupplierId,DatePurchase,PayDay,PurchaseProducts")] Purchase purchase)
        {

            if (ModelState.IsValid)
            {
                var total = new Decimal(0);
                foreach (PurchaseProduct p in purchase.PurchaseProducts)
                {
                    total += (p.Price * p.Quantity);
                }
                purchase.TotalPurchase = total;
                purchase.PurchaseId = Guid.NewGuid();
                db.Purchases.Add(purchase);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", purchase.SupplierId);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", purchase.SupplierId);
            ViewBag.purchaseProducts = purchase.PurchaseProducts;
            return View(new Purchase
            {
                PurchaseId = purchase.PurchaseId,
                PayDay = purchase.PayDay,
                SupplierId = purchase.SupplierId,
                TotalPurchase = purchase.TotalPurchase,
                DatePurchase = purchase.DatePurchase,
                PurchaseProducts = new List<PurchaseProduct>()
            });

        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseId,SupplierId,DatePurchase,TotalPurchase,PayDay,PurchaseProducts")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                if (purchase.PurchaseProducts != null)
                {
                    var total = new Decimal(0);
                    foreach (var item in purchase.PurchaseProducts)
                    {
                        total += (item.Price * item.Quantity);
                        item.PurchaseId = purchase.PurchaseId;
                        db.PurchasesProducts.Add(item);

                    }
                    Console.Write(purchase.TotalPurchase);
                    purchase.TotalPurchase = total+ purchase.TotalPurchase;
                }
              
                db.Entry(purchase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", purchase.SupplierId);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Purchase purchase = await db.Purchases.FindAsync(id);
            db.Purchases.Remove(purchase);
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
