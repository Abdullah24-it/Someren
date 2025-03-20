using Microsoft.AspNetCore.Mvc;
using Someren.Models;
using Someren.Repositories;

namespace Someren.Controllers
{
    public class LecturersController : Controller
    {
		private readonly LecturerRepository _lecturersRepository;
		public LecturersController(LecturerRepository lecturerRepository)
		{
			_lecturersRepository = lecturerRepository;
		}
		public IActionResult Index()
		{
			List<LecturerModel> lecturer = _lecturersRepository.GetAll();
			return View(lecturer);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(LecturerModel lecturer)
		{
			try
			{
				_lecturersRepository.Add(lecturer);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View(lecturer);
			}
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{

			LecturerModel? lecturer = _lecturersRepository.GetById((int)id);
			if (id == null)
			{
				return NotFound();
			}

			return View(lecturer);
		}

		[HttpPost]
		public ActionResult Edit(LecturerModel lecturer)
		{
			try
			{
				_lecturersRepository.Update(lecturer);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View(lecturer);
			}
		}

		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			LecturerModel? lecturer = _lecturersRepository.GetById((int)id);
			return View(lecturer);

		}

		[HttpPost]
		public ActionResult Delete(LecturerModel lecturer)
		{
			try
			{
				_lecturersRepository.Delete(lecturer);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View(lecturer);
			}
		}
	}
}
