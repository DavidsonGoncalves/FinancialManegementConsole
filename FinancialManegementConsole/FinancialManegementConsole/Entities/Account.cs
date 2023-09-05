﻿
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
        public void UpdateBalance()
        {
          foreach(Item item in Items)
            {
                if(item.Type == 0)
                {
                    Balance -= item.Amount;
                }
                else
                {
                    Balance += item.Amount;
                }
            }
        }

        
    }
}
