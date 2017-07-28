using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class demoModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string strname { get; set; }
        [Required]
        public string strsex { get; set; }
        [Required]
        public string strphone { get; set; }
        [Required]
        public string stremail { get; set; }
    }
}