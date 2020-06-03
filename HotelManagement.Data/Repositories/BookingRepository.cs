using AutoMapper;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Database;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public IEnumerable<BookingViewModel> GetBookings()
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                List<BookingViewModel> bvmodel = new List<BookingViewModel>();
                List<booking> bdata = db.bookings.ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<booking, BookingViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                bvmodel = mapper.Map<List<booking>, List<BookingViewModel>>(bdata);
                return bvmodel;

            }
        }
        public bool BookRoom(int roomId, DateTime date)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                bool status = false;
                try
                {
                    booking temp = db.bookings.Where(x => x.roomid == roomId && x.bookingdate == date).FirstOrDefault();
                    if (temp != null)
                    {
                        return status;
                    }
                    booking booking = new booking { roomid = roomId, bookingdate = date, bookingstatus = "optional" };
                    db.bookings.Add(booking);
                    if (db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool DeleteBooking(int bookingId)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                bool status = false;
                try
                {
                    booking booking = db.bookings.Where(x => x.bookingid == bookingId).AsNoTracking().FirstOrDefault();
                    booking.bookingstatus = "Deleted";
                    db.Entry(booking).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool GetRoomAvailability(int roomId, DateTime date)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                bool status = false;
                try
                {
                    List<booking> bookings = db.bookings.Where(x => x.roomid == roomId && x.bookingdate.Equals(date) && (x.bookingstatus == "Optional" || x.bookingstatus == "Definitive")).ToList();
                    if (bookings.Count <= 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
        public bool UpdateBookingDate(int roomId, DateTime date)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                bool status = false;
                try
                {
                    booking temp = db.bookings.Where(x => x.roomid == roomId && x.bookingdate == date).FirstOrDefault();
                    if (temp != null)
                    {
                        return status;
                    }
                    booking booking = db.bookings.Where(x => x.roomid == roomId).FirstOrDefault();
                    booking.bookingdate = date; ;
                    if (db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool UpdateBookingStatus(int id, string status)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                bool updated = false;
                try
                {
                    booking booking = db.bookings.AsNoTracking().Where(x => x.bookingid == id).FirstOrDefault();
                    booking.bookingstatus = status;
                    db.Entry(booking).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        updated = true;
                    }
                    return updated;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

    }
}
