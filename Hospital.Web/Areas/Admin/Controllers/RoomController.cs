using Hospital.Models;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomController : Controller
    {
        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }
        public IActionResult Index(int pageNumber= 1 , int pageSize= 10)
        {
            return View(_room.GetAll(pageNumber,pageSize));
        }

        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _room.GetRoomById(id);
            return View(viewModel);
        }



        [HttpPost]
        public IActionResult Edit(RoomViewModel viewModel)
        {
            _room.UpdateRoom(viewModel);
            return RedirectToAction("Index");
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(RoomViewModel viewModel)
        {
            _room.AddRoom(viewModel);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
