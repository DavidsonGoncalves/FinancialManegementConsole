using FinancialManegementConsole.Entities;
using FinancialManegementConsole.Entities.Enums;

namespace FinancialManegementConsole 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(01, "account1", 0.00);

            account.AddItem(new Item(DateTime.Now, (Type_item)Enum.Parse(typeof(Type_item), "Income"),"First Iem Added", (Category)Enum.Parse(typeof(Category),"Salary"),2000.00));
            account.AddItem(new Item(DateTime.Now, (Type_item)Enum.Parse(typeof(Type_item), "Expense"), "Second Item Added", (Category)Enum.Parse(typeof(Category), "Food"), 100.00));
            account.AddItem(new Item(DateTime.Now, (Type_item)Enum.Parse(typeof(Type_item), "Expense"), "Third Item Added", (Category)Enum.Parse(typeof(Category), "Food"), 200.00));
            account.AddItem(new Item(DateTime.Now, (Type_item)Enum.Parse(typeof(Type_item), "Expense"), "Forth Item Added", (Category)Enum.Parse(typeof(Category), "Leisure"), 300.00));
            account.AddItem(new Item(DateTime.Now, (Type_item)Enum.Parse(typeof(Type_item), "Income"), "Fifth Item Added", (Category)Enum.Parse(typeof(Category), "EventualIncome"), 50.00));
            account.AddItem(new Item(DateTime.Now,  (Type_item)Enum.Parse(typeof(Type_item), "Expense"), "Sixth Item Added", (Category)Enum.Parse(typeof(Category), "Others"), 10.00));
                
            foreach(var item in account.Items)
            {
                Console.WriteLine(item.Id.ToString() + item.Type + item.Category.ToString() + item.Category.ToString()+item.Desctiption + item.Amount);
            }
            Console.ReadKey();
        }
    }
}