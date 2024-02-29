using SearchPagingSorting.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchPagingSorting.Models
{
    public class ToViewModel
    {
        public customer_table ToCustomer(CustomerModel customer) {

            return new customer_table
            {
                customer_id = customer.customer_id,
                Cust_fname = customer.Cust_fname.Trim(),
                csut_sname = customer.csut_sname.Trim(),
                Email = customer.Email.Trim(),
                Country = customer.Country.Trim(),
                State=customer.State.Trim(),
                City=customer.City.Trim(),
                IsActive=customer.IsActive
                
            };
        
        }
        public CustomerModel CustomerToData(customer_table customer)
        {

            return new CustomerModel
            {
                customer_id = customer.customer_id,
                Cust_fname = customer.Cust_fname.Trim(),
                csut_sname = customer.csut_sname.Trim(),
                Email = customer.Email.Trim(),
                Country = customer.Country.Trim(),
                State = customer.State.Trim(),
                City = customer.City.Trim(),
                IsActive = customer.IsActive

            };

        }
    }
}