using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCData.Models
{
    public class People
    {
        [Display(Name ="name")]
        public string name { get; set; }

        [Display(Name ="city")]
        public string city { get; set; }        
        public int telephone { get; set; }
    }
}