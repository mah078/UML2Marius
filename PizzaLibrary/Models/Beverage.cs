using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        public bool IsAlcoholic { get; set; }
        public Beverage(string name, double price, string description, MenuType menuType, bool isAlcoholic) : base(name, price, description, menuType)
        {
            IsAlcoholic = isAlcoholic;
        }
        public override string ToString()
        {
            return base.ToString() +$"contains alcohol: {IsAlcoholic}";
        }
    }
}
