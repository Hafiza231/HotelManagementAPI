using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.BusinessEntities.ViewModels;

namespace HotelManagement.Business.Interfaces
{
    public interface IBookingManager
    {
        bool BookRoom(int roomId, DateTime date);
        bool DeleteBooking(int bookingId);
        bool GetRoomAvailability(int roomId, DateTime date);
        bool UpdateBookingDate(int bid, DateTime date);
        bool UpdateBookingStatus(int id, string status);
        IEnumerable<BookingViewModel> GetBookings();

    }
}
