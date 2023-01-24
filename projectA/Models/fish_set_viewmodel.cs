using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectA.Models
{
    public class fish_set_viewmodel
    {
        public pond pondvm { get; set; }
        public fish fishvm { get; set; }
        public fish_set fish_setvm { get; set; }
        public food foodvm { get; set; }
        public fish_food fish_foodvm { get; set; }
        public sell sellvm { get; set; }
        public additional_cost addivm { get; set; }
        public total_cost tcvm { get; set; }
        public result resultvm { get; set; }
        public pond_detail pond_detailvm{get;set;}
        public set_fish_details sfdvm { get; set; }
        public sell_fish_details slfdvm { get; set; }

    }
}