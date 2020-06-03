using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Managers
{
    public class RoomManager : IRoomManager
    {
        private IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomsViewModel AddRooms(RoomsViewModel rvmodel)
        {
            var data = _roomRepository.AddRooms(rvmodel);
            return data;
        }

        public List<RoomsViewModel> GetRoomByCategory(string category)
        {
            List<RoomsViewModel> roomcat = _roomRepository.GetRoomByCategory(category);
            return roomcat;
        }

        public List<RoomsViewModel> GetRoomByHotelCity(string pcity)
        {
            List<RoomsViewModel> roomcity = _roomRepository.GetRoomByHotelCity(pcity);
            return roomcity;
        }

        public List<RoomsViewModel> GetRoomByHotelPincode(int pcode)
        {
            List<RoomsViewModel> roompcode = _roomRepository.GetRoomByHotelPincode(pcode);
            return roompcode;
        }

        public List<RoomsViewModel> GetRoomByPrice(decimal price)
        {
            List<RoomsViewModel> roomprice = _roomRepository.GetRoomByPrice(price);
            return roomprice;
        }

        public IEnumerable<RoomsViewModel> GetRooms()
        {
           return _roomRepository.GetRooms();
        }

    }
}
