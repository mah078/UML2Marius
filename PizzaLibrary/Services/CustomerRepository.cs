using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaLibrary.Exceptions;

namespace PizzaLibrary.Services
{
    public class CustomerRepository:ICustomerRepository
    {
        private Dictionary<string, ICustomer> _customers;

        public CustomerRepository(){
            _customers = MockData.CustomerData;
        }

        public int Count { get { return _customers.Count(); } }

        public void AddCustomer(ICustomer customer)
        {
            if (_customers.ContainsKey(customer.Mobile)) throw new CustomerMobileNumberExists("customer mobile already exists");
            _customers.Add(customer.Mobile, customer);
        }

        public List<ICustomer> GetAll()
        {
            List<ICustomer> returnList = new();
            foreach (ICustomer customer in _customers.Values) returnList.Add(customer);
            return returnList;
        }

        public ICustomer GetCustomerByMobile(string mobile)
        {
            if (_customers.ContainsKey(mobile)) return _customers[mobile];
            return null;
        }

        public void PrintAllCustomers()
        {
            foreach (ICustomer customer in _customers.Values){
                Console.WriteLine(customer.ToString());
            }
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }

        public List<ICustomer> GetAllMembers()
        {
            List<ICustomer> returnList = new();
            foreach (ICustomer customer in _customers.Values)
            {
                if (customer.ClubMember) returnList.Add(customer);
            }
            return returnList;
        }

        public List<ICustomer> GetAllFromAddress(string address)
        {
            List<ICustomer> returnList = new();
            foreach (ICustomer customer in _customers.Values)
            {
                if (customer.Address == address) returnList.Add(customer);
            }
            return returnList;
        }
    }
}
