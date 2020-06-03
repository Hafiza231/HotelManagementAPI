using AutoMapper;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Database;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public IEnumerable<HotelViewModel> GetHotels()
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                List<HotelViewModel> hlist = new List<HotelViewModel>();
                List<hotel> hotellist = db.hotels.OrderBy(h => h.hotelname).ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<hotel, HotelViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                hlist = mapper.Map<List<hotel>, List<HotelViewModel>>(hotellist);
                return hlist;
            }
        }
        public HotelViewModel GetById(int id)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                HotelViewModel model = new HotelViewModel();
                hotel h = db.hotels.Where(p => p.hotelid == id).FirstOrDefault();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<hotel, HotelViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                model = mapper.Map<hotel, HotelViewModel>(h);
                return model;
            }
        }
        public HotelViewModel AddHotel(HotelViewModel hvmodel)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                hotel h = new hotel();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<HotelViewModel, hotel>();
                });
                IMapper mapper = config.CreateMapper();
                h = mapper.Map<HotelViewModel, hotel>(hvmodel);
                db.hotels.Add(h);
                db.SaveChanges();
                return hvmodel;
            }
        }

        public HotelViewModel EditHotel(int id, HotelViewModel hvmodel)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                var h = db.hotels.FirstOrDefault(p => p.hotelid == id);
                if (h == null)
                {
                    return null;
                }
                else
                {
                    h.hotelname = hvmodel.hotelname;
                    h.address = hvmodel.address;
                    h.city = hvmodel.city;
                    h.pincode = hvmodel.pincode;
                    h.contactnumber = hvmodel.contactnumber;
                    h.contactperson = hvmodel.contactperson;
                    h.website = hvmodel.website;
                    h.facebook = hvmodel.facebook;
                    h.twitter = hvmodel.twitter;
                    h.isactive = hvmodel.isactive;
                    h.isdelete = hvmodel.isdelete;
                    h.createddate = hvmodel.createddate;
                    h.createdby = hvmodel.createdby;
                    db.SaveChanges();
                    return hvmodel;
                }

            }
        }

        public void DeleteHotel(int id)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                hotel h = db.hotels.Where(p => p.hotelid == id).FirstOrDefault();
                db.Entry(h).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }
        }


    }
}
