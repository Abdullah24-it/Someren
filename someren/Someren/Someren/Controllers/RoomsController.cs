
using Microsoft.AspNetCore.Mvc;
using Someren.Models;
using Someren.Repositories;

namespace Someren.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomRepository _roomsRepository;
        public RoomsController(RoomRepository roomRepository)
        {
            _roomsRepository = roomRepository;
        }
        public IActionResult Index()
        {
            List<RoomModel> rooms = _roomsRepository.GetAll();
            return View(rooms);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoomModel room)
        {
            try
            {
                _roomsRepository.Add(room);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(room);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            RoomModel? room = _roomsRepository.GetById((int)id);
            if (id == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public ActionResult Edit(RoomModel room)
        {
            try
            {
                _roomsRepository.Update(room);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(room);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomModel? room = _roomsRepository.GetById((int)id);
            return View(room);

        }

        [HttpPost]
        public ActionResult Delete(RoomModel room)
        {
            try
            {
                _roomsRepository.Delete(room);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(room);
            }
        }


    }
}
