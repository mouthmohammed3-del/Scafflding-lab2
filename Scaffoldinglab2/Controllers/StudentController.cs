using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Data;
using Scaffoldinglab2.Models;
using Scaffoldinglab2.Repositories.Interfaces;

namespace Scaffoldinglab2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StudentController : Controller
    {
        private readonly IRepositoryManager repository;




        //private readonly dblab2DbContext context;

        public StudentController(IRepositoryManager repository )
        {
            this.repository = repository;

            //this.context = context;
        }
        // GET: StudentController
        [AllowAnonymous]
        public ActionResult Index()
        {
            //var slist = context.Students;

            return View(repository.StudentRepository.GetAll());

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
                    repository.StudentRepository.Add(obj);
                    repository.unitOfwork.saveChanges();
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

            var student = repository.StudentRepository.GetById(id);

            if (student == null)
            {
                TempData["error"] = "mast be have not null ";
                return RedirectToAction(nameof(Index));
            }

            //ViewBag.Teachers = context.Teachers.ToList();

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
                    var res = repository.StudentRepository.Update(obj);
                    if (res != null)
                    {
                       repository.unitOfwork.saveChanges();
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

            var itme = repository.StudentRepository.GetById(id);  
            if (itme == null)
            {
                TempData["error"] = "mast be have not null ";
                return RedirectToAction(nameof(Index));
            }
           // ViewBag.Teachers = context.Teachers.ToList();

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
                    var res = repository.StudentRepository.Delete(obj);
                    if (res)
                    {

                        repository.unitOfwork.saveChanges();
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
        public ActionResult ChangeState(int id,int state)
        {
            try
            {
                if (id == 0)
                {
                    TempData["error"] = "mast be have number of student ";
                    return RedirectToAction(nameof(Index));
                }

                var item = repository.StudentRepository.GetById(id);
                if (item == null)
                {
                   

                    TempData["error"] = "mast be have not null ";
                    return RedirectToAction(nameof(Index));
                }
               // ViewBag.Teachers = context.Teachers.ToList();
                item.IsActive = state == 1 ? true : false;
                repository.unitOfwork.saveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception )
            {
                TempData["error"] = "خطاء غير متوقع ";

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
