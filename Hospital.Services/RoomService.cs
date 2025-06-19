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
    public class RoomService : IRoom
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteRoom(int roomId)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(roomId);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();
        }

        public PageResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            int count = 0;
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            var result = new PageResult<RoomViewModel>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = count,
                Data = new List<RoomViewModel>()
            };

            try
            {
                var allItems = _unitOfWork.GenericRepository<Room>().GetAll();

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

        public RoomViewModel GetRoomById(int roomId)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(roomId);
            var vm = new RoomViewModel(model);
            return vm;
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);

            var modelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);

            modelById.RoomNumber = room.RoomNumber;
            modelById.Status = room.Status;
            modelById.Type= room.Type;
            modelById.HospitalInfoId = room.HospitalInfoId;

            _unitOfWork.GenericRepository<Room>().Update(modelById);
            _unitOfWork.Save();
        }

        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModel(x)).ToList();
        }

    }
}
