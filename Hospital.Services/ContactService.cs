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
    public class ContactService : IContact
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public void AddContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteContact(int contactId)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(contactId);
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        public PageResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            var result = new PageResult<ContactViewModel>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = new List<ContactViewModel>()
            };

            try
            {
                var allItems = _unitOfWork.GenericRepository<Contact>().GetAll();

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



        public ContactViewModel GetContactById(int contactId)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(contactId);
            var vm = new ContactViewModel(model);
            return vm;
        }

        public void UpdateContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);

            var modelById = _unitOfWork.GenericRepository<Contact>().GetById(model.Id);

            modelById.Phone = contact.Phone;
            modelById.Email = contact.Email;
            modelById.HospitalInfoId = contact.HospitalInfoId;


            _unitOfWork.GenericRepository<Contact>().Update(modelById);
            _unitOfWork.Save();
        }
        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }
    }
}
