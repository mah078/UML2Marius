using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
            No = ++counter;
        }

        
        public string Name { get; set ; }
        public double Price { get; set; }
        public string Description { get; set; }
        public MenuType TheMenuType { get; set; }
        public int No { get; }
        private static int counter;

        public override string ToString()
        {
            return $"nr.{No} name: {Name}, {Price},-, description: {Description}, menu type: {TheMenuType}";
        }
        
    }
}
