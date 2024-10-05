using ATMwithOOP;
using System.Security.Cryptography.X509Certificates;
using static ATMwithOOP.bankaccountClass;

public class Program
{
    public static void Main(string[] args)
    {


        PersonalAccount personalAccount = new PersonalAccount("Busher Personal", 2682424, 1000);
        SavingAccount savingAccount = new SavingAccount("Busher Saving", 123456, 2000);// Initializing personal account with attributes
        personalAccount.DisplayUserInfo();

        ATMScreen menu = new ATMScreen(personalAccount, savingAccount); //Refrencing the bank account object to the class so it can be used in the methods.
        menu.ShowScreen(); //object with account1 initiated.



    }

}
