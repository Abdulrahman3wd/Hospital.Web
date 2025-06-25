using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public int HospitalInfoId { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public ContactViewModel()
        {
            
        }

        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Email = model.Email;
            Phone = model.Phone;
            HospitalInfoId = model.HospitalInfoId;
            HospitalInfo = model.Hospital;
        }

        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                HospitalInfoId =model.HospitalInfoId,
                Email = model.Email,
                Phone = model.Phone,
                Hospital = model.HospitalInfo
            };

        }
    }
}
