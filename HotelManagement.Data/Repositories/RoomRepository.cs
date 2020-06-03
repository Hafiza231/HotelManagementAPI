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
    public class RoomRepository : IRoomRepository
    {
        public IEnumerable<RoomsViewModel> GetRooms()
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                List<RoomsViewModel> rvmodel = new List<RoomsViewModel>();
                List<room> list = db.rooms.OrderBy(p => p.roomprice).ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<room, RoomsViewModel>().ForMember(d => d.hotel, o => o.MapFrom(s => s.hotel));
                    cfg.CreateMap<hotel, HotelViewModel>();
                });

                IMapper mapper = config.CreateMapper();
                foreach (room item in list)
                {
                    var room = mapper.Map<room, RoomsViewModel>(item);
                    rvmodel.Add(room);
                }

                return rvmodel;
            }
        }
        public RoomsViewModel AddRooms(RoomsViewModel rvmodel)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                room r = new room();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RoomsViewModel, room>();
                });
                IMapper mapper = config.CreateMapper();
                r = mapper.Map<RoomsViewModel, room>(rvmodel);
                db.rooms.Add(r);
                db.SaveChanges();
                return rvmodel;
            }
        }

        public List<RoomsViewModel> GetRoomByHotelCity(string pcity)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                List<room> rlist = db.rooms.Where(x => x.hotel.city == pcity).ToList();
                List<RoomsViewModel> rvmodel = new List<RoomsViewModel>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<room, RoomsViewModel>().ForMember(d => d.hotel, o => o.MapFrom(s => s.hotel));
                    cfg.CreateMap<hotel, HotelViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                rvmodel = mapper.Map<List<room>, List<RoomsViewModel>>(rlist);


                return rvmodel;


            }

        }

        public List<RoomsViewModel> GetRoomByHotelPincode(int pcode)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                List<room> rlist = db.rooms.Where(x => x.hotel.pincode == pcode).ToList();
                List<RoomsViewModel> rvmodel = new List<RoomsViewModel>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<room, RoomsViewModel>().ForMember(d => d.hotel, o => o.MapFrom(s => s.hotel));
                    cfg.CreateMap<hotel, HotelViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                rvmodel = mapper.Map<List<room>, List<RoomsViewModel>>(rlist);
                return rvmodel;
            }

        }

        public List<RoomsViewModel> GetRoomByCategory(string category)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                List<room> rlist = db.rooms.Where(x => x.roomcategory == category).ToList();
                List<RoomsViewModel> rvmodel = new List<RoomsViewModel>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<room, RoomsViewModel>().ForMember(d => d.hotel, o => o.MapFrom(s => s.hotel));
                    cfg.CreateMap<hotel, HotelViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                rvmodel = mapper.Map<List<room>, List<RoomsViewModel>>(rlist);
                return rvmodel;
            }

        }

        public List<RoomsViewModel> GetRoomByPrice(decimal price)
        {
            using (HotelmanagementEntities db = new HotelmanagementEntities())
            {
                List<room> rlist = db.rooms.Where(x => x.roomprice == price).OrderBy(x => x.roomprice).ToList();
                List<RoomsViewModel> rvmodel = new List<RoomsViewModel>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<room, RoomsViewModel>().ForMember(d => d.hotel, o => o.MapFrom(s => s.hotel));
                    cfg.CreateMap<hotel, HotelViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                rvmodel = mapper.Map<List<room>, List<RoomsViewModel>>(rlist);
                return rvmodel;
            }

        }
    }
}
