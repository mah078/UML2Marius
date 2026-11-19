using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Exceptions
{
    public class CustomerMobileNumberExists : Exception
    {
        public CustomerMobileNumberExists(string message) : base(message)
        {

        }
    }
}
