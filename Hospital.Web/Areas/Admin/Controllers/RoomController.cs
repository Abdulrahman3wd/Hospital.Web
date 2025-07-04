﻿using Hospital.Models;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomController : Controller
    {
        private readonly IRoom _room;
        private readonly IHospitalInfo _hospitalInfo;

        public RoomController(IRoom room, IHospitalInfo hospitalInfo)
        {
            _room = room;
            _hospitalInfo = hospitalInfo;
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
            ViewBag.Hospitals = new SelectList(_hospitalInfo.GetAllHospitals(), "Id", "Name", viewModel.HospitalInfoId);
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
            ViewBag.Hospitals = new SelectList(_hospitalInfo.GetAllHospitals(), "Id", "Name");

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
