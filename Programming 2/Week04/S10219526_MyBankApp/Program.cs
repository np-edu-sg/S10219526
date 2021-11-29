using System;
using System.Collections.Generic;
using System.IO;

namespace S10219526_MyBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = ReadFile();
            while (true)
            {
                Console.WriteLine();
                var input = DisplayMenu();
                Console.WriteLine();
                
                if (input == "0")
                {
                    Console.WriteLine("--------");
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine("--------");
                    break;
                }
                

                switch (input)
                {
                    case "1":
                        DisplayAll(accounts);
                        break;
                    case "2":
                    {
                        Console.Write("Enter the Account Number: ");
                        var accNo = Console.ReadLine();
                        var acc = Search(accounts, accNo);
                        if (acc is null)
                        {
                            Console.WriteLine("Unable to find account number. Please try again.");
                            break;
                        }

                        double amount;
                        while (true)
                        {
                            Console.Write("Amount to deposit: ");
                            if (double.TryParse(Console.ReadLine(), out amount)) break;
                            Console.WriteLine("Invalid amount");
                        }

                        acc.Deposit(amount);
                        Console.WriteLine($"{amount:C} deposited successfully");
                        Console.WriteLine(acc);

                        break;
                    }
                    case "3":
                    {
                        Console.Write("Enter the Account Number: ");
                        var accNo = Console.ReadLine();
                        var acc = Search(accounts, accNo);
                        if (acc is null)
                        {
                            Console.WriteLine("Invalid account number");
                            break;
                        }

                        double amount;
                        while (true)
                        {
                            Console.Write("Amount to withdraw: ");
                            if (double.TryParse(Console.ReadLine(), out amount)) break;
                            Console.WriteLine("Invalid amount");
                        }

                        if (!acc.Withdraw(amount)) Console.WriteLine("Insufficient funds");
                        else
                        {
                            Console.WriteLine($"{amount:C} withdrawn successfully");
                            Console.WriteLine(acc);
                        }

                        break;
                    }
                    case "4":
                    {
                        Console.WriteLine(SavingsAccount.InterestHeader);
                        foreach (var account in accounts)
                        {
                            Console.WriteLine(account.ToStringWithInterest());
                        }

                        break;
                    }
                }
            }
        }

        public static SavingsAccount Search(List<SavingsAccount> sList, string accNo)
        {
            foreach (var account in sList)
            {
                if (account.AccNo == accNo) return account;
            }

            return null;
        }

        public static void DisplayAll(List<SavingsAccount> sList)
        {
            foreach (var account in sList)
            {
                Console.WriteLine(account);
            }
        }

        public static string DisplayMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("[1] Display all accounts");
            Console.WriteLine("[2] Deposit");
            Console.WriteLine("[3] Withdraw");
            Console.WriteLine("[4] Display details");
            Console.WriteLine("[0] Exit");
            Console.Write("Enter option: ");
            return Console.ReadLine();
        }

        public static List<SavingsAccount> ReadFile()
        {
            var accounts = new List<SavingsAccount>();
            foreach (var accountString in File.ReadAllLines("./assets/savings_account.csv")[1..])
            {
                var split = accountString.Split(",");
                accounts.Add(new SavingsAccount(split[0], split[1], double.Parse(split[2]), double.Parse(split[3])));
            }

            return accounts;
        }
    }
}