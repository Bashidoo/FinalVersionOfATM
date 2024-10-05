using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATMwithOOP
{
    public class bankaccountClass
    {
        private string? name;
        private int cardnumber;
        private double balance;
       

        public bankaccountClass(string name, int cardnumber, double startbalance)
        {
            this.Name = name;
            this.Cardnumber = cardnumber;
            this.Balance = startbalance;

        }

        public string Name
        {
            get { return name; }
            set {  name = value; }
        }

        public int Cardnumber
        {
            get { return cardnumber; }
            set { cardnumber = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public virtual void DisplayUserInfo()
        {
            Console.WriteLine($"\nHello {name}! Welcome to Abo Dan Bank, your account balance is {balance}");
        }

        public void Deposit(double amount) // Void was chosen because of no value returning due to lack of inheritance.
        {
            Console.WriteLine();
            Console.WriteLine("Enter deposit amount: ");


            try // ask teacher for assistance in how to handle string exceptions
            {
               // double amount = Convert.ToDouble(Console.ReadLine());

                if (amount > 0)
                {
                    Balance += amount; // Balance from encapsulation
                    Console.WriteLine($"Deposited: {amount:C}, New Balance: {balance:C}");
                   


                }
                else if (amount <= 0)
                {
                    Console.Write($"Desired amount: {amount:C}, cannot be desposited");
                   
                }
                

            }

            catch (Exception e) // ask teacher for assistance in how to handle string exceptions
            {
                Console.WriteLine("Wrong Input, please type a number, reason for error:");
                Console.Write(e.Message);
                
            }


        }
        public void  Withdraw(double amount)
        {
            Console.WriteLine();
            Console.WriteLine("Enter withdrawal amount: ");


            try
            {
               
                if (amount > 0)
                {
                    if (amount <= balance)
                    {
                        Balance -= amount; // Balance from encapsulation
                        Console.WriteLine($"Withdrawn: {amount:C}, New Balance: {balance:C}");
                        
                    }
                    else // Denna else gäller för if loop övanför
                    {
                        Console.WriteLine("Insufficient money.");
                        
                    }
                }
                else // gäller för först If loop om x > 0
                {
                    Console.WriteLine(" Invalid Input please enter a number higher than zero");
                    
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong Input, please type a number, reason for error:");
                Console.Write(e.Message);
                
            }

        }

        public class PersonalAccount : bankaccountClass
        {
            public PersonalAccount(string name, int cardnumber, double startbalance) : base(name, cardnumber, startbalance)
            {
                
            }

            public override void DisplayUserInfo()
            {
                Console.WriteLine("\nPersonal Account");
                base.DisplayUserInfo();
            }
        }

        public class SavingAccount : bankaccountClass
        {
            public SavingAccount(string name, int cardnumber, double startbalance) : base(name, cardnumber, startbalance)
            {
                Console.WriteLine("Saving Account");
                base.DisplayUserInfo();
            }
        }



    }
}
