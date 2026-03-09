using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Data;
using Scaffoldinglab2.Models;

namespace Scaffoldinglab2.Controllers
{
    public class StudentController : Controller
    {
        private readonly dblab2DbContext context;

        public StudentController(dblab2DbContext context)
        {
            this.context = context;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var slist = context.Students;

            return View(slist);

        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Students.Add(obj);
                    context.SaveChanges();
                    TempData["msg"] = "the add sucssed ";

                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    return View(obj);


                }


            }
            catch (Exception ex)
            {
                TempData["error"] = "Error dont aplicible";
                Console.WriteLine(ex.Message);
                return View(obj);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                TempData["error"] = "mast be have number of student ";
                return RedirectToAction(nameof(Index));
            }

            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                TempData["error"] = "mast be have not null ";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Teachers = context.Teachers.ToList();

            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = context.Students.Update(obj);
                    if (res.State == EntityState.Modified)
                    {
                        context.Students.Update(obj);
                        context.SaveChanges();
                        TempData["msg"] = "the Updated sucssed ";

                        return RedirectToAction(nameof(Index));

                    }

                    TempData["msg"] = "cat not the Editing ";
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    return View(obj);


                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;

                return View(obj);
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                TempData["error"] = "mast be have number of student ";
                return RedirectToAction(nameof(Index));
            }

            var itme = context.Students.FirstOrDefault(s => s.Id == id);
            if (itme == null)
            {
                TempData["error"] = "mast be have not null ";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Teachers = context.Teachers.ToList();

            return View(itme);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = context.Students.Remove(obj);
                    if (res.State == EntityState.Deleted)
                    {

                        context.SaveChanges();
                        TempData["msg"] = "the deleted is sucssed ";

                        return RedirectToAction(nameof(Index));

                    }

                    TempData["msg"] = "cat not the Delete ";
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    return View(obj);


                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;

                return View(obj);
            }
        }
    }
}
