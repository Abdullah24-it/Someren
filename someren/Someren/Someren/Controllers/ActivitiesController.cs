using Microsoft.AspNetCore.Mvc;
using Someren.Models;
using Someren.Repositories;

namespace Someren.Controllers
{
    public class ActivitiesController : Controller
    {
		private readonly ActivityRepository _activitiesRepository;
		public ActivitiesController(ActivityRepository activityRepository)
		{
			_activitiesRepository = activityRepository;
		}
		public IActionResult Index()
		{
			List<ActivityModel> activities = _activitiesRepository.GetAll();
			return View(activities);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(ActivityModel activity)
		{
			try
			{
				_activitiesRepository.Add(activity);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View(activity);
			}
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{

			ActivityModel? activity = _activitiesRepository.GetById((int)id);
			if (id == null)
			{
				return NotFound();
			}

			return View(activity);
		}

		[HttpPost]
		public ActionResult Edit(ActivityModel activity)
		{
			try
			{
				_activitiesRepository.Update(activity);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View(activity);
			}
		}

		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ActivityModel? activity = _activitiesRepository.GetById((int)id);
			return View(activity);

		}

		[HttpPost]
		public ActionResult Delete(ActivityModel activity)
		{
			try
			{
				_activitiesRepository.Delete(activity);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View(activity);
			}
		}
	}
}
