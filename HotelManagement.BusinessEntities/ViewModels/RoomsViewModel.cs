using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessEntities.ViewModels
{
    public class RoomsViewModel
    {
        public int roomid { get; set; }
        public int hotelid { get; set; }
        public string roomname { get; set; }
        public string roomcategory { get; set; }
        public decimal roomprice { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }
        public System.DateTime createddate { get; set; }
        public Nullable<System.DateTime> updateddate { get; set; }
        public HotelViewModel hotel { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set; }

    }
}
