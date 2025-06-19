using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IContact
    {
        PageResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        ContactViewModel GetContactById(int contactId);
        void UpdateContact(ContactViewModel contact);
        void AddContact(ContactViewModel contact);
        void DeleteContact(int contactId);
    }
}
