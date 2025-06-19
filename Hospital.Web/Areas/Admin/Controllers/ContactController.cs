using Hospital.Models;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly IContact _contact;
        private readonly IHospitalInfo _hospitalInfo;

        public ContactController(IContact contact ,IHospitalInfo hospitalInfo)
        {
            _contact = contact;
            _hospitalInfo = hospitalInfo;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_contact.GetAll(pageNumber, pageSize));
        }

        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _contact.GetContactById(id);
            ViewBag.Hospitals = new SelectList(_hospitalInfo.GetAllHospitals(), "Id", "Name", viewModel.HospitalInfoId);

            return View(viewModel);
        }



        [HttpPost]
        public IActionResult Edit(ContactViewModel viewModel)
        {
            _contact.UpdateContact(viewModel);
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
        public IActionResult Create(ContactViewModel viewModel)
        {
            _contact.AddContact(viewModel);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
