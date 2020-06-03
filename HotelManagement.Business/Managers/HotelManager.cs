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
    public class HotelManager : IHotelManager
    {
        private IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public HotelViewModel AddHotel(HotelViewModel hvmodel)
        {
            var data = _hotelRepository.AddHotel(hvmodel);
            return data;
        }

        public void DeleteHotel(int id)
        {
             _hotelRepository.DeleteHotel(id);
        }

        public HotelViewModel EditHotel(int id, HotelViewModel hvmodel)
        {
            var data = _hotelRepository.EditHotel(id, hvmodel);
            return data;
        }

        public HotelViewModel GetById(int id)
        {
            var data = _hotelRepository.GetById(id);
            return data;
        }

        public IEnumerable<HotelViewModel> GetHotels()
        {
            return _hotelRepository.GetHotels();
        }

    }
}
