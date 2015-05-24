using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tema2.Models;

namespace tema2.Controllers
{
    public class BeriController : Controller
    {
        private BereDBContext db = new BereDBContext();
     //   public static Cart cart = new Cart();
        private CartDBContext cartDb = new CartDBContext();
        //
        // GET: /Beri/

        public ActionResult Index()
        {
           // Object user = HttpContext.User;
            return View(db.Beri.ToList());
        }

        //
        // GET: /Beri/Details/5

        public ActionResult Details(int id = 0)
        {
            Bere bere = db.Beri.Find(id);
            if (bere == null)
            {
                return HttpNotFound();
            }
            return View(bere);
        }

        //
        // GET: /Beri/Create

        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else return RedirectToAction("Index");
        }

        //
        // POST: /Beri/Create

        [HttpPost]
        public ActionResult Create(Bere bere)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                db.Beri.Add(bere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bere);
        }

        //
        // GET: /Beri/Edit/5

        public ActionResult Edit(int id = 0)
            
        {
            if (User.Identity.IsAuthenticated)
            {
                Bere bere = db.Beri.Find(id);
                if (bere == null)
                {
                    return HttpNotFound();
                }
                return View(bere);
            }
            else return RedirectToAction("Index");
        }

        //
        // POST: /Beri/Edit/5

        [HttpPost]
        public ActionResult Edit(Bere bere)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bere).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bere);
            }
            else return RedirectToAction("Index");
        }

        //
        // GET: /Beri/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (User.Identity.IsAuthenticated)
            {
                Bere bere = db.Beri.Find(id);
                if (bere == null)
                {
                    return HttpNotFound();
                }
                return View(bere);
            }
            else return RedirectToAction("Index");
        }

        //
        // POST: /Beri/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Bere bere = db.Beri.Find(id);
            db.Beri.Remove(bere);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult SearchIndex(string searchString)
        {
            var beri = from m in db.Beri
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                beri = beri.Where(s => s.Nume.Contains(searchString));
            }

            return View(beri);
        }
        [ ActionName("addToCart")]
        public ActionResult addToCart(int id)
        {
            Bere bere = db.Beri.Find(id);
            cartDb.cart.Add(bere);
            cartDb.SaveChanges();
            
            return RedirectToAction("Index");
            
        }
         [ActionName("checkOut")]
       public ActionResult checkOut()
        {
            decimal pretTotal = 0;
            foreach (var entity in cartDb.cart)
               pretTotal+= entity.Pret;
           var cart = from m in cartDb.cart
                      select m;
           ViewData["pretTotal"] = pretTotal.ToString();
           return View(cart);
       }
         public ActionResult clearCart()
         {
             foreach (var entity in cartDb.cart)
                 cartDb.cart.Remove(entity);
             cartDb.SaveChanges();
             return RedirectToAction("Index");
         }
         public ActionResult exportJson()
         {
             JsonExporter exporter = new JsonExporter();
             exporter.Export(db.Beri.ToList());
             return RedirectToAction("Index");
         }
         public ActionResult exportCsv()
         {
             CsvExporter exporter = new CsvExporter();
             exporter.Export(db.Beri.ToList());
             return RedirectToAction("Index");
         }
    }
}