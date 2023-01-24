using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace projectA.Models
{
    public class sell_fish_details
    {
        public int? id { get; set; }
        [Display(Name = "Fish Name")]
        public string sfish_name { get; set; }
        [Display(Name = "Fish Quantity")]
        public int? sfish_quantity { get; set; }
    }
}