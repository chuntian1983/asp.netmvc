using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string salary { get; set; }


    }
}