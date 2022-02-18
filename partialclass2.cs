using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    partial class Customer
    {

      //  public static string name { get; private set; }

        public void CustomerDetails()
        {
            Customer cust1 = new Customer()
            {
                name = "ram",
                id = 110,
                age = 20,
                address = "hyd",
                accountNo = 1234,
                transaction = 5000
            };

            Customer cust2 = new Customer()
            {
                name = "ramu",
                id = 210,
                age = 20,
                address = "ban",
                accountNo = 12354,
                transaction = 500
            };
            Customer cust3 = new Customer()
            {
                name = "akhil",
                id = 230,
                age = 20,
                address = "vijayawada",
                accountNo = 123544,
                transaction = 2220
            };
            Customer cust4 = new Customer()
            {
                name = "sukhi",
                id = 250,
                age =
                20,
                address = "pune",
                accountNo = 1235442,
                transaction = 2220
            };

            System.Collections.Generic.List<Customer> c = new List<Customer>();

            c.Add(cust1);
            c.Add(cust2);
            c.Add(cust3);
            c.Add(cust4);

            foreach (Customer c1 in c)
            {
                Console.WriteLine();
                Console.WriteLine("name     id       age        address       accountNo     transaction");
                Console.WriteLine("{0}      {1}      {2}          {3}        {4}            {5}", c1.name, c1.age, c1.id, c1.address, c1.accountNo, c1.transaction);
                Console.WriteLine();
            }
        }

    }


}


