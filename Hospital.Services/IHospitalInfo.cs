using Hospital.Models;
using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IHospitalInfo
    {
        List<HospitalInfo> GetAllHospitals();
        PageResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);
        HospitalInfoViewModel GetHospitalById(int hospitalId);
        void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo);
        void AddHospitalInfo(HospitalInfoViewModel hospitalInfo);
        void DeleteHospitalInfo(int hospitalId);

    }
}
