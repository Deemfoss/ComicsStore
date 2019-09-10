using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicsStores.Models;
using System.Data.Entity;
using Vereyon.Web;
using System.Web.Security;

namespace ComicsStores.Controllers
{
    public class AdminController : Controller
    {
        StoreContext db = new StoreContext();

        // GET: Admin

[Authorize]
        public ActionResult Global()
        {

            return View();
        }
        public ActionResult CheckOrders()
        {
            
            return View(db.Purchases);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {

            var res = db.Purchases.Find(id);
            db.Purchases.Remove(res);
            db.SaveChanges();
            return RedirectToAction("CheckOrders", "Admin");

        }



        //[HttpPost]
        //public ActionResult Edit(Purchas purch)
        //    {

        //    // db.Entry(purch).State = EntityState.Modified;
        //    db.Entry(purch.PhoneNumber).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("CheckOrders", "Admin");

        //}

        [Authorize]
        public ActionResult Products()
        {
           // var prod = db.Products.Include(p=>p.Category);
            return View(db.Products);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
           Product Prod= db.Products.Find(id);
            db.Entry(Prod).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Products", "Admin");
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var edprod= db.Products.Find(id);

            return View(edprod);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Products", "Admin");


        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateProduct()
        {
           
            return View();


        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Products", "Admin");


        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Log model)
        {
            User user = null;
            if (ModelState.IsValid)
            {
                //user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                using (StoreContext db = new StoreContext())
                {

                    user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);//пытаемся найти пользователя
                }
            

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Global", "Admin");
                }
                else
                {
                    return Content("Не правильный логин или пароль");
                }

              
            }
            return View(model);
        }
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home"); ;
        }
    }
}