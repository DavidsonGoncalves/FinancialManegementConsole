using FinancialManegementConsole.Entities.Enums;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FinancialManegementConsole.Entities
{
    internal class Account
    {
        
        public string Name { get; private set; }
        public double Balance { get; private set; }
        public bool Started { get; private set; }
        public List<Item> Items { get; private set; } = new List<Item>();
        private FilesData file = new FilesData();
        public Account(int id, string name, double balance)
        {
            
            Name = name;
            Balance = balance;
        }

        public void StartAccount()
        {
            string line;
            var sr = file.ReadFile();
            using(sr)
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] aux = line.Split(';');
                    Item item = new Item(DateTime.Parse(aux[0]), (Type_item)Enum.Parse(typeof(Type_item), aux[1]), aux[2], (Category)Enum.Parse(typeof(Category), aux[3]), double.Parse(aux[4]), Guid.Parse(aux[5]));
                    Items.Add(item);
                    UpdateBalance(item);
                }
            }
            Started = true;
            
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
                    
                    Items.Remove(item);

                    item.Amount = item.Amount * -1;
                    UpdateBalance(item); break;
                    
                }
            }
            
            file.RemoveItem(id.ToString());
           

        }

        public void ExportCSV()
        {
            file.CreateCsv();

        }
        
        public void UpdateBalance(Item item)
        {
            if (item.PostDate.Date <= DateTime.Now.Date)
            {
                {
                    Balance += (item.Type == 0) ? -item.Amount : item.Amount;
                }
            }
        }
    }
}
