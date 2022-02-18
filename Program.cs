using System;


namespace Exception
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;






    class LimitExceedException : Exception
    {
        public override string Message
        {
            get
            {
                return "Account limit exceeded";
            }
        }

    }
    public class SavingsAccount
    {
        static double amount = 0;
        double limit = 100000;
        public virtual void withdraw(double withdrawAmount)
        {
            if (withdrawAmount <= amount)
            {
                amount -= withdrawAmount;
                Console.WriteLine("balance amount " + amount);
            }
            else
            {
                Console.WriteLine("Insuficient funds");
            }
        }

        public virtual void deposit(double depositamount)
        {
            try
            {
                if (amount + depositamount <= limit)
                {
                    amount += depositamount;
                }
                else
                {
                    throw new LimitExceedException();
                }
            }
            catch (LimitExceedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }
            finally
            {
                Console.WriteLine("Amount in savings account " + amount);
            }
        }
    }
    public class CurrentAccount : SavingsAccount
    {
        static double amount = 0;
        double limit = 200000;
        public override void withdraw(double withdrawAmount)
        {
            if (withdrawAmount <= amount)
            {
                amount -= withdrawAmount;
                Console.WriteLine("balance amount " + amount);

            }
            else
            {
                Console.WriteLine("Insuficient funds");
            }
        }
        public override void deposit(double depositamount)
        {
            try
            {
                if (amount + depositamount <= limit)
                {
                    amount += depositamount;
                }
                else
                {
                    throw new LimitExceedException();
                }
            }
            catch (LimitExceedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }
            finally
            {
                Console.WriteLine("Amount in current account " + amount);
            }
        }
    }

    public class ChildAccount : SavingsAccount
    {
        static double amount = 0;
        double limit = 50000;

        public double Amount { get => amount; set => amount = value; }

        public override void withdraw(double withdrawAmount)
        {
            if (withdrawAmount <= Amount)
            {
                Amount -= withdrawAmount;
                Console.WriteLine("balance amount " + Amount);

            }
            else
            {
                Console.WriteLine("Insuficient funds");
            }
        }
        public override void deposit(double depositamount)
        {
            try
            {
                if (Amount + depositamount <= limit)
                {
                    Amount += depositamount;
                }
                else
                {
                    throw new LimitExceedException();
                }
            }
            catch (LimitExceedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }
            finally
            {
                Console.WriteLine("Amount in child account " + Amount);
            }
        }
    }

    public delegate void DelegateWithdraw(double withdrawamount);
    class ATM : SavingsAccount
    {
        static double amount = 0;
        public override void withdraw(double withdrawAmount)
        {

            if (withdrawAmount <= amount)
            {
                amount -= withdrawAmount;
            }
            else
            {
                Console.WriteLine("Insuficient funds");
            }
        }

            static void Main(string[] args)
            {
                while (true)
                {


                    Console.WriteLine("Enter customer name ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter customer age");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter customer address");
                    string address = Console.ReadLine();


                    Console.WriteLine("Enter 1->savings 2->current 3->child");
                    Console.WriteLine("Choose an account");
                    int num = Convert.ToInt32(Console.ReadLine());
                Customer cst = new Customer();
                switch (num)
                    {
                        case 1:
                            while (true)
                            {
                                Console.WriteLine("1->deposit 2->withdraw 3->customersDetails 4->ATM");
                                Console.WriteLine("Choose an option");
                                int opt = Convert.ToInt32(Console.ReadLine());
                                SavingsAccount s = new SavingsAccount();
                                switch (opt)
                                {
                                    case 1:
                                        Console.WriteLine("Enter amount to deposit to savings");
                                        double depositAmount = Convert.ToDouble(Console.ReadLine());

                                        s.deposit(depositAmount);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter amount to withdraw from savings");
                                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                        s.withdraw(withdrawAmount);
                                        break;
                                    case 3:
                                       
                                        cst.CustomerDetails();
                                        break;
                                    case 4:
                                        int count = 0;
                                        while (true)
                                        {
                                            ATM a = new ATM();
                                            DelegateWithdraw dw = new DelegateWithdraw(a.withdraw);
                                            Console.WriteLine("Enter amount to withdraw from savings");
                                            double wdamount = Convert.ToDouble(Console.ReadLine());
                                            //dw(1000);
                                            s.withdraw(wdamount);
                                            count++;

                                            if (count == 3)
                                            {
                                                s.withdraw(500);
                                            }
                                            Console.WriteLine("Do You want withdraw again (yes/no");
                                            string str = Console.ReadLine();
                                            if (str == "yes")
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        break;
                                }

                                Console.WriteLine("Do you want to switch service(yes/no)");
                                string str2 = Console.ReadLine();
                                if (str2 == "yes")
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;

                        case 2:
                            while (true)
                            {
                                Console.WriteLine("1->deposit 2->withdraw 3->customerDetails 4->ATM");
                                Console.WriteLine("Choose an option");
                                int opt1 = Convert.ToInt32(Console.ReadLine());
                                CurrentAccount c1 = new CurrentAccount();
                                switch (opt1)
                                {
                                    case 1:
                                        Console.WriteLine("Enter amount to deposit to current");
                                        double depositAmount = Convert.ToDouble(Console.ReadLine());

                                        c1.deposit(depositAmount);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter amount to withdraw from current");
                                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                        c1.deposit(withdrawAmount);
                                        break;
                                    case 3:
                                        cst.CustomerDetails();
                                        break;
                                    case 4:
                                        int count = 0;
                                        while (true)
                                        {
                                            ATM a = new ATM();
                                            DelegateWithdraw dw = new DelegateWithdraw(a.withdraw);
                                            Console.WriteLine("Enter amount to withdraw from curent");
                                            double wdamount = Convert.ToDouble(Console.ReadLine());
                                            //dw(1000);
                                            c1.withdraw(wdamount);
                                            count++;

                                            if (count == 3)
                                            {
                                                c1.withdraw(500);
                                            }
                                            Console.WriteLine("Do You want withdraw again (yes/no");
                                            string str = Console.ReadLine();
                                            if (str == "yes")
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        break;
                                }
                                Console.WriteLine("Do you want to switch service(yes/no)");
                                string str2 = Console.ReadLine();
                                if (str2 == "yes")
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            }
                            break;
                        case 3:
                            while (true)
                            {
                                Console.WriteLine("1->deposit 2->withdraw 3->customerDetails 4->ATM");
                                Console.WriteLine("Choose an option");
                                int opt2 = Convert.ToInt32(Console.ReadLine());
                                ChildAccount c2 = new ChildAccount();
                                switch (opt2)
                                {
                                    case 1:
                                        Console.WriteLine("Enter amount to deposit to child");
                                        double depositAmount = Convert.ToDouble(Console.ReadLine());

                                        c2.deposit(depositAmount);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter amount to withdraw from child");
                                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                        c2.withdraw(withdrawAmount);
                                        break;
                                    case 3:
                                        cst.CustomerDetails();
                                        break;
                                    case 4:
                                        int count = 0;
                                        while (true)
                                        {
                                            ATM a = new ATM();
                                            DelegateWithdraw dw = new DelegateWithdraw(a.withdraw);
                                            Console.WriteLine("Enter amount to withdraw from child");
                                            double wdamount = Convert.ToDouble(Console.ReadLine());
                                            //dw(1000);
                                            c2.withdraw(wdamount);
                                            count++;

                                            if (count == 3)
                                            {
                                                c2.withdraw(500);
                                            }
                                            Console.WriteLine("Do You want withdraw again (yes/no");
                                            string str1 = Console.ReadLine();
                                            if (str1 == "yes")
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        break;


                                }
                                Console.WriteLine("Do you want to switch service(yes/no)");
                                string str2 = Console.ReadLine();
                                if (str2 == "yes")
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            }
                            break;
                    }
                    Console.WriteLine("Do You want to switch any account (yes/no)");
                    string t = Console.ReadLine();
                    if (t == "yes")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }

                }
            }


        }
    }





