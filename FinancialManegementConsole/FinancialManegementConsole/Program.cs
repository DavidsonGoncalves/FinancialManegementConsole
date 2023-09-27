using FinancialManegementConsole.Entities;
using FinancialManegementConsole.Entities.Enums;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace FinancialManegementConsole 
{
    internal class Program
    {
       static Account account = new Account(01, "account1", 0.00);
        static void Main(string[] args)
        {
            if (!account.Started)
            {
                account.StartAccount();
            }
            AccountConsole();
            
            
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:

                    Console.Clear();
                    Console.Write("What Type of the item? (Expense / Income): ");
                    string type = Console.ReadLine();
                    
                    Console.Write("Enter with the Date to post the item: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter with the Category Item: ");
                    string category = Console.ReadLine();

                    Console.Write("Enter with the value: ");
                    double amount = double.Parse(Console.ReadLine());

                    Console.Write("Add some description: ");
                    
                    string description = Console.ReadLine();
                    description = (description == "") ? "NULL" : description;
                    
                       
                    
                    Console.Write("Is a recurret item? (s/n)");
                    string op = Console.ReadLine();
                    if (op =="s")
                    {
                      
                        Console.Write("Enter with the months to repete: ");
                        int qtdMonths = int.Parse(Console.ReadLine());
                        for (int i = 0; i<qtdMonths;i++)
                        {
                            account.AddItem(new Item(date, (Type_item)Enum.Parse(typeof(Type_item), type), description, (Category)Enum.Parse(typeof(Category), category), amount, Guid.NewGuid()));
                            date = date.AddMonths(1);
                           
                        }
                    }
                    else
                    {
                       account.AddItem(new Item(date, (Type_item)Enum.Parse(typeof(Type_item), type), description, (Category)Enum.Parse(typeof(Category), category), amount, Guid.NewGuid()));
                    }
                    break;

                case 2:
                    Console.Write("Enter with the id item to remove: ");
                    var id = Console.ReadLine();
                    account.RemoveItem(id);
                    break;

                case 3:
                    ListItems();
                    break;
            }
            Main(args);

           
            

            static void AccountConsole()
            {
                
                Console.WriteLine("----------- ACCOUNT -----------");
                Console.WriteLine($"Name: {account.Name}");
                Console.WriteLine($"Balance: {account.Balance.ToString("F2",CultureInfo.InvariantCulture)}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("");
                Console.WriteLine("------------- MENU -------------");
                Console.WriteLine("Options:");
                Console.WriteLine("1- Add Item");
                Console.WriteLine("2- Remove Item");
                Console.WriteLine("3- ListItem");
            }

            static void ListItems()
            {
                foreach (var item in account.Items)
                {
                    //Console.WriteLine(item.PostDate.ToString() + item.ID.ToString() +" "+ item.Type + " " + item.Category.ToString() + " " + item.Category.ToString() + " " + item.Desctiption + " " + item.Amount);
                    Console.WriteLine(item);
                }
            }

        }
    }
}