using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //for validation
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCData.Models
{
    public class People
    {
        [Required]      //not null
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        public int Telephone { get; set; }

        [Key]       //primary key column
        [Required]
        public int PersonId { get; set; }        
    }
}
