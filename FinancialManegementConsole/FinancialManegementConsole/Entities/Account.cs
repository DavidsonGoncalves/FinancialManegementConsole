
using System.Runtime.InteropServices;

namespace FinancialManegementConsole.Entities
{
    internal class Account
    {
        
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public List<Item> Items { get; private set; } = new List<Item>();
        public Account(int id, string name, double balance)
        {
            
            Name = name;
            Balance = balance;
        }

       public void AddItem(Item item)
        {
            Items.Add(item);
            UpdateBalance(item);
        }

     

        /*public void RemoveItem(int id)
        {
            foreach (Item item in Items)
            {
                if (item.Id == id)
                {
                    Items.Remove(item);
                }
            }
        }
        */
        public void UpdateBalance(Item item)
        {
                if(item.Type == 0)
                {
                    Balance = Balance - item.Amount;
                }
                else
                {
                    Balance = Balance + item.Amount;
                }
        }

        
    }
}
