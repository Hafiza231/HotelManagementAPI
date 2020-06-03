using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<RoomsViewModel> GetRooms();
        RoomsViewModel AddRooms(RoomsViewModel rvmodel);
        //RoomsViewModel EditRooms(int id, RoomsViewModel rvmodel);
        List<RoomsViewModel> GetRoomByHotelCity(string pcity);
        List<RoomsViewModel> GetRoomByHotelPincode(int pcode);
        List<RoomsViewModel> GetRoomByCategory(string category);
        List<RoomsViewModel> GetRoomByPrice(decimal price);

    }
}
