﻿using System.Data.SqlTypes;

namespace MusteriYonetimSistemi.Models.ViewModels
{
    public class CustomerOrderViewModel
    {
        public int OrderID { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
    }
}