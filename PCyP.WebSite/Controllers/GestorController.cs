using Domain.PCyP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCyP.WebSite.Controllers
{
    public class GestorController : Controller
    {
        // GET: Gestor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int? id)
        {
            try
            {
                // TODO: Add insert logic here
                StudentBusiness.CargarDato();
                return RedirectToAction("Index", "Student", new { area = "" } );
            }
            catch
            {
                return View();
            }
        }
    }
}