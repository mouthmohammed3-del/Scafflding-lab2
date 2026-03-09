using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Data;
using Scaffoldinglab2.Models;

namespace Scaffoldinglab2.Controllers
{
    public class SubjectController : Controller
    {
        private readonly dblab2DbContext context;

        public SubjectController(dblab2DbContext context)
        {
            this.context = context;
        }
        // GET: SubjectController
        public ActionResult Index()
        {
            var slist = context.Subjects.Include(s=>s.Teacher).ToList();

            return View(slist);
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            var ts = context.Teachers.ToList();
            ViewData["Techers"] = ts;
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Subjects.Add(obj);
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
                return View(obj);
            }
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                TempData["error"] = "mast be have number of Subject ";
                return RedirectToAction(nameof(Index));
            }

            var res = context.Subjects.FirstOrDefault(s => s.Id == id);
            if (res == null)
            {
                TempData["error"] = "mast be have not null ";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Subjects = context.Subjects.ToList();

            return View(res);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = context.Subjects.Update(obj);
                    if (res.State == EntityState.Modified)
                    {
                        context.Subjects.Update(obj);
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



        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubjectController/Delete/5
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
