
using System.Runtime.InteropServices;

namespace FinancialManegementConsole.Entities
{
    internal class Account
    {
        
        public string Name { get; private set; }
        public double Balance { get; private set; }
       
        public List<Item> Items { get; private set; } = new List<Item>();
        private FilesData file = new FilesData();
        public Account(int id, string name, double balance)
        {
            
            Name = name;
            Balance = balance;
        }

       public void AddItem(Item item)
        {
            Items.Add(item);
            UpdateBalance(item);
            file.SaveItem(item);
        }

     

        public void RemoveItem(string id)
        {
            
            foreach (var item in Items)
            {
                if(item.ID.ToString() == id)
                {
                    Items.Remove(item); break;
                }
            }
            
            file.RemoveItem(id.ToString());

        }
        
        public void UpdateBalance(Item item)
        {
            Balance += (item.Type == 0) ? -item.Amount : item.Amount;
        }

        
    }
}
