using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchPagingSorting.Models
{
    public class CustomerModel
    {
        
        public int customer_id { get; set; }
        [Required(ErrorMessage = "Enter Customer First Name!!!")]
        public string Cust_fname { get; set; }
        [Required(ErrorMessage = "Enter Customer Last Name!!!")]
        public string csut_sname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Country!!!")]
        public string Country { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Enter City!!!")]
        public string City { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}

