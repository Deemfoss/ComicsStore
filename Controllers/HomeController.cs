using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicsStores.Models;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;
using ComicsStores.Filters;


namespace ComicsStores.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        StoreContext db = new StoreContext();
        public ActionResult Index(int? page)
        {
            int PageSize = 9;
            int PageNumber = (page ?? 1);
            return View(db.Products.OrderBy(m => m.Id).ToPagedList(PageNumber, PageSize));
        }
        [HttpPost]
        public ActionResult BookSearch(string Search)
        {
            var allbooks = db.Products.Where(a => a.Name.Contains(Search)).ToList();

            return View(allbooks);
        }

        public ActionResult SortbyPrice()
        {

            var res = db.Products.OrderBy(m => m.Price).ToList();

            return View(res);
        }
        public ActionResult SortbydesPrice()
        {
            var res = db.Products.OrderBy(m => m.Price).ToList();
            res.Reverse();
            return View(res);
        }

        public ActionResult Description(int id)
        {
            var Description = db.Products.Find(id);

            return View(Description);
        }

        public ActionResult Categoryes()
        {

            return View(db.Categoryies);
        }

        public ActionResult CtegoryDet(int id)
        {
            ViewBag.CategoryDet = db.Products.Where(m => m.Category == id);
            return View();
        }

        public ActionResult AboutStore()
        {

            return View();
        }
        public ActionResult Delivery()
        {

            return View();
        }
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;

            List<string> cultures = new List<string>() { "ru", "en"};
            if (!cultures.Contains(lang))
            {
                lang = "en";
            }
            
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;  
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

    }
}