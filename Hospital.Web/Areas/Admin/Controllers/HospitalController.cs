using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]

    public class HospitalController : Controller
    {
        private readonly IHospitalInfo _hospitalInfo;

        public HospitalController( IHospitalInfo hospitalInfo)
        {
              _hospitalInfo = hospitalInfo;
        }
        public IActionResult Index(int pageNumber =1 , int pageSize = 10)
        {
            return View(_hospitalInfo.GetAll(pageNumber , pageSize));
        }


        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _hospitalInfo.GetHospitalById(id);
            return View(viewModel);
        }



        [HttpPost]
        public IActionResult Edit(HospitalInfoViewModel viewModel)
        {
            _hospitalInfo.UpdateHospitalInfo(viewModel);
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
        public IActionResult Create(HospitalInfoViewModel viewModel)
        {
            _hospitalInfo.AddHospitalInfo(viewModel);
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            _hospitalInfo.DeleteHospitalInfo(id);
            return RedirectToAction("Index");
        } 
        #endregion
    }
}
