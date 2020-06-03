using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebAPI.Controllers
{
    public class BookingController : ApiController
    {
        private IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet]
        public IEnumerable<BookingViewModel> GetAllBooking()
        {
            return _bookingManager.GetBookings();

        }

        [HttpGet]
        public IHttpActionResult GetRoomAvailibility(int roomId, string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            bool status = _bookingManager.GetRoomAvailability(roomId, dateTime);
            if(status==false)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPost]
        public IHttpActionResult BookRoom(BookingViewModel booking)
        {
            bool status = _bookingManager.BookRoom(booking.roomid, booking.bookingdate);
            if (status == false)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPut]
        public IHttpActionResult UpdateBookingDate(BookingViewModel booking)
        {
            bool status = _bookingManager.UpdateBookingDate(booking.roomid, booking.bookingdate);
            if (status == false)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPut]
        public IHttpActionResult UpdateBookingStatus(BookingViewModel booking)
        {
            bool updated = _bookingManager.UpdateBookingStatus(booking.bookingid, booking.bookingstatus);
            if (updated == false)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete]
        public IHttpActionResult DeleteBooking(int id)
        {
            bool status = _bookingManager.DeleteBooking(id);
            if (status == false)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}
