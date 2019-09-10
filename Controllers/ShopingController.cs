using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicsStores.Models;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;
using Vereyon.Web;

namespace ComicsStores.Controllers
{
    public class ShopingController : Controller
    {
        // GET: Shoping
        StoreContext db = new StoreContext();
        public ActionResult ShopingCart(int id)
        {
            if (Session["Cart"] == null)
            {
                List<ShopingCart> Shopingcart = new List<Models.ShopingCart>();
               var getprod= db.Products.Find(id);
                Shopingcart.Add(new ShopingCart(getprod,1) );
                Session["Cart"] = Shopingcart;
            }
            else
            {
                List<ShopingCart> cart = (List<ShopingCart>)Session["Cart"];
                int index = SummaryProduct(id);
                if (index == -1)
                    cart.Add(new ShopingCart(db.Products.Find(id), 1));

                else
                    cart[index].quantity++;
                Session["Cart"] = cart;
            }
            return(RedirectToAction("Index","Home"));
           
        }
       private int  SummaryProduct(int id)
        {
            List<ShopingCart> cart = (List<ShopingCart>)Session["Cart"];
            for (int i = 0; i < cart.Count; i++)

                if (cart[i].product.Id == id)
                    return i;
            return -1;

        }

        public ActionResult Bag()
        {
                    if (Session["Cart"] == null)
           {
                //return RedirectToAction("Home", "Index");
              return Content("<h1> К сожалению ваша корзина пуста </h1>");
            }

            double sum = 0;
            foreach (var item in (List<ShopingCart>)Session["Cart"])
            {
                var i = Convert.ToDouble(item.quantity) * Convert.ToDouble(item.product.Price);
                sum += i;
            }
            ViewBag.Sum = sum;
            return View();

        }


        public ActionResult Delete(int id)
        {
          var del=( List<ShopingCart>) Session["Cart"];
           int index = SummaryProduct(id);
            if (index==-1)
            {
                del.RemoveAt(index);
                Session["Cart"] = del;
            }

            else
            {
                del[index].quantity--;
                Session["Cart"] = del;

            }
            
            return RedirectToAction("Bag","Shoping");

        }
        public ActionResult Order()
        {
          

            return View();

        }

        public ActionResult OrderFast()
        {


            return View();

        }
        [HttpPost]
        public ActionResult OrderFast(Purchas purchas, int id)
        {

            if (ModelState.IsValid)
            {
                if (id != 0)
                {
                  
                    purchas.Data = DateTime.Today;
                    purchas.IdProducts = id;
                    db.Purchases.Add(purchas);
                    db.SaveChanges();

                    FlashMessage.Confirmation("Спасибо за покупку");
                    return RedirectToAction("Index", "Home");
                }
              
            }

            return RedirectToAction("Order", "Shoping");
        }
        [HttpPost]
        public ActionResult Order(Purchas purchas)
        {
            
            if (ModelState.IsValid)
            {
          

         
                List<ShopingCart> cart = (List<ShopingCart>)Session["Cart"];
                Purchas puch = new Purchas();
                if (cart == null)
                {
                    return Content("<h1> К сожалению ваша корзина пуста </h1>");
                }
          
                else
                {
                    for (int i = 0; i < cart.Count; i++)
                    {

                        purchas.IdProducts = cart[i].product.Id;
                        //может добавлю название книги        
                        purchas.Data = DateTime.Today;
                        db.Purchases.Add(purchas);

                        db.SaveChanges();
                    }
                }
                FlashMessage.Confirmation("Спасибо за покупку");
                return RedirectToAction("Index", "Home");
            }
            return View();
    

            
        }

    }
}