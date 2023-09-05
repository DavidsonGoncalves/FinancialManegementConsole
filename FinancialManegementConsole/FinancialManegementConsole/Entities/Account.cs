
namespace FinancialManegementConsole.Entities
{
    internal class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
        public Account(int id, string name, double balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }

       public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void RemoveItem(int id)
        {
            foreach (Item item in Items)
            {
                if (item.Id == id)
                {
                    Items.Remove(item);
                }
            }
        }
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
