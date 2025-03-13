using Microsoft.AspNetCore.Mvc;

namespace Someren.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Repositories.IStudentRepository _studentsRepository;
        public StudentsController(Repositories.IStudentRepository studentRepository)
        {
            _studentsRepository = studentRepository;
        }
        public IActionResult Index()
        {

            List<Models.StudentModel> students = _studentsRepository.GetAllStudents();
            return View(students);  
        }


    }
}
