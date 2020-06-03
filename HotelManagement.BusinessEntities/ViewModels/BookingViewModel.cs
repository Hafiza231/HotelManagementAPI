using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessEntities.ViewModels
{
    public class BookingViewModel
    {
        public int bookingid { get; set; }
        public int roomid { get; set; }
        public System.DateTime bookingdate { get; set; }
        public string bookingstatus { get; set; }

    }
}
