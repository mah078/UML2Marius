using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        public Customer(string name, string mobile, string address)
        {
            Name = name;
            Mobile = mobile;
            Address = address;
            Id = ++counter;
        }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool ClubMember { get; set; }

        public int Id { get; }
        private static int counter;

        public override string ToString()
        {
            return $"name: {Name}, mobile, {Mobile}, address: {Address} is club member: {ClubMember}";
        }

        
    }
}
