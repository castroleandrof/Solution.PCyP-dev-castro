using Domain.PCyP.BLL;
using Domain.PCyP.Biz;
using System.Linq;
using System.Web.Mvc;

namespace PCyP.WebSite.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var lista = StudentBusiness.GetStudentList();
            StudentBusiness.Controller();
            return View(lista);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            var student = StudentBusiness.Find_Id(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student model)
        {
            try
            {
                // TODO: Add insert logic here
               
                StudentBusiness.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            var student = StudentBusiness.Find_Id(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            try
            {
                // TODO: Add update logic here

                StudentBusiness.Edit(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            var student = StudentBusiness.Find_Id(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Student model)
        {
            try
            {
                StudentBusiness.Delete(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
