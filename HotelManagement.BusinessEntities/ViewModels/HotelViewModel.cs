using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessEntities.ViewModels
{
    public class HotelViewModel
    {
        public int hotelid { get; set; }
        public string hotelname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public int contactnumber { get; set; }
        public string contactperson { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public bool isactive { get; set; }
        public bool isdelete { get; set; }
        public System.DateTime createddate { get; set; }
        public Nullable<System.DateTime> updateddate { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set; }

    }
}
