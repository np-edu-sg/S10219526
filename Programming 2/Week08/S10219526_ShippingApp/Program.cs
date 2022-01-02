using System;
using System.Collections.Generic;

namespace S10219526_ShippingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerList = new List<Customer>();
            InitCustomerList(customerList);
            ListCustomers(customerList);
        }

        public static void InitCustomerList(List<Customer> customerList)
        {
            customerList.Add(new Customer("John Tan", "98501111", new ShippingAddr("Singapore", "Clementi")));
            customerList.Add(new Customer("Amy Lim", "99991111", new ShippingAddr("Hong Kong", "Mong Kok Rd")));
            customerList.Add(new Customer("Tony Tay", "91112222", new ShippingAddr("Malaysia", "Malacca Rd")));
        }

        public static void ListCustomers(List<Customer> customerList)
        {
            Console.WriteLine($"{"Name",-10}{"Tel",-12}{"Country",-15}{"Street",-20}");
            foreach (var customer in customerList) Console.WriteLine(customer);
        }
    }
}