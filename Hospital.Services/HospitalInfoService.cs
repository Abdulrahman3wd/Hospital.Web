using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class HospitalInfoService : IHospitalInfo
    {
        private readonly IUnitOfWork _unitOfWork;

        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
            _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
            _unitOfWork.Save();

        }

        public void DeleteHospitalInfo(int hospitalId)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(hospitalId);
            _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
            _unitOfWork.Save();

        }

        public PageResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber; 

            var result = new PageResult<HospitalInfoViewModel>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = new List<HospitalInfoViewModel>()
            };

            try
            {
                var allItems = _unitOfWork.GenericRepository<HospitalInfo>().GetAll();

                result.TotalItems = allItems.Count();
                result.Data = ConvertModelToViewModelList(
                    allItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAll: " + ex.Message);
            }

            return result;
        }

        public HospitalInfoViewModel GetHospitalById(int hospitalId)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(hospitalId);
            var vm = new HospitalInfoViewModel(model);
            return vm;

        }

        public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);

            var modelById = _unitOfWork.GenericRepository<HospitalInfo>().GetById(model.Id);

            modelById.Name = hospitalInfo.Name;

            modelById.City = hospitalInfo.City;
            modelById.Type = hospitalInfo.Type;

            modelById.Country = hospitalInfo.Country;
            modelById.PinCode = hospitalInfo.PinCode;
                    
            _unitOfWork.GenericRepository<HospitalInfo>().Update(modelById);
            _unitOfWork.Save();


        }

        private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
        {
            return modelList.Select(x => new HospitalInfoViewModel(x)).ToList();
        }
    }
}
