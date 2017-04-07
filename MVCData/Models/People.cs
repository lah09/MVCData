using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //for validation
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;   //for [Bind] DataAnnotation

namespace MVCData.Models
{
    //[Bind(Include ="City, Telephone")]
    public class People
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "This Name field is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Enter at least 2 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This City field is required")]
        [Display(Name = "City")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Enter at least 2 letters")]
        public string City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Telephone")]
        [StringLength(10, ErrorMessage = "Telephone must contain 10 digits")]        
        public string Telephone { get; set; }       //declared as string so that the leading zero will be displayed

        [Key]       //primary key column
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Id is required")]
        [Display(Name = "PersonId")]
        public int PersonId { get; set; }        
    }
}
