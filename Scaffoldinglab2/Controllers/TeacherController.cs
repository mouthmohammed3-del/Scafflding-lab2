using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Data;
using Scaffoldinglab2.Models;

namespace Scaffoldinglab2.Controllers
{
    public class TeacherController : Controller
    {
        private readonly dblab2DbContext context;

        public TeacherController(dblab2DbContext context)
        {
            this.context = context;
        }
        // GET: TeacherController
        public ActionResult Index()
        {
            var slist = context.Teachers;

            return View(slist);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(  Teacher obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Teachers.Add(obj);
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

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                TempData["error"] = "mast be have number of Teacher ";
                return RedirectToAction(nameof(Index));
            }

            var res = context.Teachers.FirstOrDefault(s => s.Id == id);
            if (res == null)
            {
                TempData["error"] = "mast be have not null ";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Teachers = context.Teachers.ToList();

            return View(res);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = context.Teachers.Update(obj);
                    if (res.State == EntityState.Modified)
                    {
                        context.Teachers.Update(obj);
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
    
        

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
