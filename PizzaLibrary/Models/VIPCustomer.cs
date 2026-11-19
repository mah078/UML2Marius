using System;
using System.Collections.Generic;
using System.Text;
using PizzaLibrary.Exceptions;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        public int Discount { get; set; }
        public VIPCustomer(string name, string mobile, string address, int discount) : base(name, mobile, address)
        {
            
            if (discount < 0 || discount > 25)
            {
                throw new InvalidDiscountException("discount must be between 0 and 25");
            }
            
            Discount = discount;
        }

        public override string ToString()
        {
            return $"discount: {Discount}" + base.ToString();
        }
    }
}
