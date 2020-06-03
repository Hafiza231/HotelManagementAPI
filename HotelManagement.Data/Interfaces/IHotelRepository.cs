using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Interfaces
{
    public interface IHotelRepository
    {
        IEnumerable<HotelViewModel> GetHotels();
        HotelViewModel GetById(int id);
        HotelViewModel AddHotel(HotelViewModel hvmodel);
        HotelViewModel EditHotel(int id, HotelViewModel hvmodel);
        void DeleteHotel(int id);

    }
}
