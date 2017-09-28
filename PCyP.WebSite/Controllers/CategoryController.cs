using Domain.PCyP.Biz;
using Domain.PCyP.BLL;
using Domain.PCyP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace PCyP.WebSite.Controllers
{
    public class CategoryController : Controller
    {
        

        // GET: Student
        public ActionResult Index()
        {
            var lista = CategoryBusiness.GetCategoryList();
            return View(lista);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            //var person = db.Find(new Student { RowGuid = id });
            //return View(person);
            var category = CategoryBusiness.Find_Id(id);
            return View(category);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                // TODO: Add insert logic here
                CategoryBusiness.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Student/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            
            var category = CategoryBusiness.Find_Id(id);
            return View(category);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Category model) 
        {

            // TODO: Add update logic here
            //var lista = CategoryBusiness.GetCategoryList();
            //Student category = lista.Find(x => x.Id == id);
            //category.name = name;
            //category.ChangedOn = DateTime.Now;
            CategoryBusiness.Edit(model);
                return RedirectToAction("Index");
            
           
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            //var lista = CategoryBusiness.GetCategoryList();
            //Student category = lista.Find(x => x.Id == id);
            var category = CategoryBusiness.Find_Id(id);
            return View(category);
            //return View(category);

        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Category model)
        {
            try
            {
                // TODO: Add delete logic here
                //var lista = CategoryBusiness.GetCategoryList();
                //Student category = lista.Find(x => x.Id == id);
                //lista.Remove(category);
                CategoryBusiness.Delete(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
