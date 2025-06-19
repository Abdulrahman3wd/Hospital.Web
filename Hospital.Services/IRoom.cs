using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IRoom
    {
        PageResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
        RoomViewModel GetRoomById(int roomId);
        void UpdateRoom(RoomViewModel room);
        void AddRoom(RoomViewModel room);
        void DeleteRoom(int roomId);
    }
}
