using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNet_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account() { account_number = "1234567890", customer_name = "Raguvaran", customer_address = "XYZ", balance = 10000 };
            
            Thread[] thread = new Thread[2];
            Console.WriteLine("-------------Thread Withdraw---------");
            thread[0] = new Thread(new ThreadStart(account.WithDraw));
            account.withdrawAmount = 2000.00;
            thread[0].Name = "Thread 1 ";

            Console.WriteLine("-------------Thread Deposit---------");
            thread[1] = new Thread(new ThreadStart(account.Deposit));
            account.depositAmount = 1000.00;
            thread[1].Name = "Thread 2 ";

            foreach (Thread t in thread)
            {
                t.Start();
            }

            Console.ReadLine();
        }
    }

    public class Account
    {
        public string account_number { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public double balance { get; set; }
        public double depositAmount { get; set; }
        public double withdrawAmount { get; set; }

        public void WithDraw()
        {
            Monitor.Enter(this);

            Console.WriteLine("----------------WithDraw Starts-------------------");
            if (this.balance > this.withdrawAmount)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread : " + Thread.CurrentThread.Name);
                Console.WriteLine("Balance before withdraw : " + this.balance);
                Console.WriteLine("Amount to be withdraw : " + this.withdrawAmount);
                this.balance = this.balance - this.withdrawAmount;
                Console.WriteLine("Amount Withdrawn");
                Console.WriteLine("Balance After withdraw : " + this.balance);

            }
            else
            {
                Console.WriteLine("Insufficent Balance in account {0} with  Amount {1}", this.account_number, this.balance);
            }


            Monitor.Exit(this);

            Console.WriteLine("----------------WithDraw Ends-------------------");

        }

        public void Deposit()
        {
            Monitor.Enter(this);

            Console.WriteLine("----------------Deposit Starts-------------------");
            if (this.depositAmount > 0)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread : " + Thread.CurrentThread.Name);
                Console.WriteLine("Balance before deposit : " + this.balance);
                Console.WriteLine("Amount to be deposit : " + this.depositAmount);
                this.balance = this.balance + this.depositAmount;
                Console.WriteLine("Amount Deposited");
                Console.WriteLine("Balance After deposit : " + this.balance);

            }
            else
            {
                Console.WriteLine("No amount {1} to deposit in account {0} ", this.account_number, this.balance);
            }


            Monitor.Exit(this);

            Console.WriteLine("----------------Deposit Ends-------------------");

        }
    }
}