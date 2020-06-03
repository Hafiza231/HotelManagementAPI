using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebAPI.Controllers
{
    public class RoomsController : ApiController
    {
        private IRoomManager _roomManager;
        public RoomsController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

		[BasicAuth]
        [HttpGet]
	
        public IHttpActionResult GetRooms()
        {
            var data = _roomManager.GetRooms();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [Route("api/values/AddRooms")]
        [HttpPost]
        public IHttpActionResult AddRooms(RoomsViewModel rvmodel)
        {
            var data = _roomManager.AddRooms(rvmodel);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(string city)
        {
            var data = _roomManager.GetRoomByHotelCity(city);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetRoomByPincode(int pcode)
        {
            var data = _roomManager.GetRoomByHotelPincode(pcode);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetRoomBycategory(string category)
        {
            var data = _roomManager.GetRoomByCategory(category);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetRoomByPrice(decimal price)
        {
            var data = _roomManager.GetRoomByPrice(price);
            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }

    }
}
