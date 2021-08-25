using SampleMVCProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCProject1.Controllers
{
    public class CategoryController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            return View(db.Categories.ToList()) ;
        }

        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Category category)
        {

            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }
        public ActionResult Update(int id)
        {
           Category category = db.Categories.Find(id);
            if (category != null)
            {
                return View(category);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}