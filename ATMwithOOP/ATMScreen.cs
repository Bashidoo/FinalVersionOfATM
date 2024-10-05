using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ATMwithOOP
{
    public class ATMScreen
    {
        private bankaccountClass accountobJ1; // creating variable of the objects so it can be used inside the methods
       private bankaccountClass accountobJ2; // creating variable of the objects so it can be used inside the methods

        public ATMScreen(bankaccountClass account1, bankaccountClass account2)
        {
            accountobJ1 = account1;
            accountobJ2 = account2;
        }

        public void ShowScreen()
        {
            bool exit = false; // Variable to control the loop

            // Console.WriteLine("Entering the loop...");  Debugging line to check if the loop is reached

            while (!exit)
            {

                // Console.WriteLine("\nLoop is running...");  Debugging line to see if the loop runs multiple times
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadKey();  // Debugging line to check the choice
                

                switch (choice.KeyChar)
                {
                    case '1':
                        
                        HandleCheckBalance();

                        break;
                    case '2':

                        HandleDepositV2();
                           /* 
                             
                            
                                                  Console.Write("\nEnter the amount to deposit: ");
                                                  if (double.TryParse(Console.ReadLine(), out double depositAmount))
                                                  {
                                                      accountobJ1.Deposit(depositAmount);  // Use the Deposit method to add money
                                                   }
                                                 else
                                                     {
                                                     Console.WriteLine("Invalid input. Please enter a valid number.");
                                                     }
                       */
                        break;
                    case '3':

                        HandleWithdraw();
                       /* 
                                                   Console.Write("\nEnter the amount to withdraw: ");
                                                   if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                                                   {
                                                   accountobJ1.Withdraw(withdrawAmount);  // Use the Withdraw method to deduct money
                                                   }
                                                   else
                                                   {
                                                     Console.WriteLine("Invalid input. Please enter a valid number.");
                                                   }
                       */
                        break;
                    case '4':
                        LoadingScreen();
                        exit = true; // Exits the loop
                        Console.WriteLine("Exiting the program...");
                        break;
                    case (char)13:
                        Console.WriteLine("You pressed ENTER.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            

        }



        private void HandleCheckBalance()
        {
            Console.WriteLine("\nEnter Account Number: ");
            string? senderCardInput = Console.ReadLine();

            if (int.TryParse(senderCardInput, out int senderCardNumber))
            {

                bankaccountClass senderAccount = FindAccountByCardNumber(senderCardNumber);

                if (senderAccount != null)
                {
                    senderAccount.DisplayUserInfo();

                }
                else
                {
                    Console.WriteLine("Enter a valid Reciever card Number, one that exists.");
                }

            }
        }



        private void HandleDepositV2()
        {
            Console.WriteLine("\nEnter the sender Card number: ");

            string? senderCardInput = Console.ReadLine();

            if (int.TryParse(senderCardInput, out int senderCardNumber))
            {

                bankaccountClass senderAccount = FindAccountByCardNumber(senderCardNumber);

                if (senderAccount != null)
                {
                    Console.WriteLine("Enter the reciever Card Number: ");
                    string? recieverCardInput = Console.ReadLine();

                    if (int.TryParse(recieverCardInput, out int recieverCardNumber))
                    {
                        bankaccountClass recieverAccount = FindAccountByCardNumber(recieverCardNumber);

                        if (recieverAccount != null)
                        {
                            Console.WriteLine("Enter the amount to transfer: ");

                            string? amountInput = Console.ReadLine();
                            if (double.TryParse(amountInput, out double amount) && amount > 0)
                            {
                                LoadingScreen();
                                recieverAccount.Withdraw(amount);
                                senderAccount.Deposit(amount);


                            }
                            else
                            {
                                Console.WriteLine("Invalid amount entered. Enter a viable input. ");
                            }


                        }
                        else
                        {
                            Console.WriteLine("Enter a valid Reciever card Number, one that exists.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Sender card Number, one that exists.");
                    }
                }

            }
        }


        private void HandleWithdraw()
        {
            Console.WriteLine("\nEnter Account number");
            string? senderCardInput = Console.ReadLine();
            if (int.TryParse(senderCardInput, out int recieverCardNumber))
            {
                bankaccountClass recieveraccount = FindAccountByCardNumber(recieverCardNumber);

                if (recieveraccount != null)
                {
                    Console.WriteLine("Enter amount to be withdrawn from account");
                    string amountInput = Console.ReadLine();

                    if (double.TryParse(amountInput, out double amount) && amount > 0)
                    {
                        LoadingScreen();
                        recieveraccount.Withdraw(amount);

                    }
                    else
                    {
                        Console.WriteLine("Invalid amount entered. Enter a viable input.");
                    }

                }
                else
                {
                    Console.WriteLine("Enter a valid Reciever card Number, one that exists.");
                }
            }

        }

     

        private bankaccountClass FindAccountByCardNumber(int cardNumber) // Method to find the object.
        {
            if (accountobJ1.Cardnumber == cardNumber)
                return accountobJ1;
           if (accountobJ2.Cardnumber == cardNumber)
               return accountobJ2;
            
            
            return null;       
        }




        public static void LoadingScreen()
        {
            Console.WriteLine();
            int ticks = 20;
            for (int i = 0; i < ticks; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);

            }
            Console.Clear();
        }
    }
}
