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
	    
    public class HotelController : ApiController
    {
        private IHotelManager _hotelManager;
        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }
		[BasicAuth]
    
        [Route("api/Hotel/GetHotels")]
        public IEnumerable<HotelViewModel> Get()
        {
            return _hotelManager.GetHotels();
        }

        // GET api/Hotel/Get/5
        public IHttpActionResult Get(int id)
        {
            var hotel = _hotelManager.GetById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        // POST api/Hotel/Post
        [Route("api/Hotel/AddHotel")]
        public IHttpActionResult Post(HotelViewModel hvmodel)
        {
            var h = _hotelManager.AddHotel(hvmodel);
            if(h==null)
            {
                return NotFound();
            }
            return Ok(h);
        }

        // PUT api/Hotel/Put/5
        public IHttpActionResult Put(int id, HotelViewModel hvmodel)
        {
            var h = _hotelManager.EditHotel(id, hvmodel);
            return Ok(h);
        }

        // DELETE api/Hotel/Delete/5
        public IHttpActionResult Delete(int id)
        {
            _hotelManager.DeleteHotel(id);
            return Ok();
        }

        
    }
}
