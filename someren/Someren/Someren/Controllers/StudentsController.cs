using Microsoft.AspNetCore.Mvc;
using Someren.Models;
using Someren.Repositories;

namespace Someren.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentsRepository;
        public StudentsController(StudentRepository studentRepository)
        {
            _studentsRepository = studentRepository;
        }
        public IActionResult Index()
        {
            List<StudentModel> students = _studentsRepository.GetAll();
            return View(students);  
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentModel student)
        {
            try
            {
                _studentsRepository.Add(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(student);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            StudentModel? student = _studentsRepository.GetById((int)id);
            if (id == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel student)
        {
            try
            {
                _studentsRepository.Update(student);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(student);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentModel? user = _studentsRepository.GetById((int)id);
            return View(user);

        }

        [HttpPost]
        public ActionResult Delete(StudentModel student)
        {
            try
            {
                _studentsRepository.Delete(student);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(student);
            }
        }


    }
}
