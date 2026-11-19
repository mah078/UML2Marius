using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Exceptions
{
    public class InvalidDiscountException :Exception
    {
        public InvalidDiscountException(string message) : base(message)
        {

        }
    }
}
