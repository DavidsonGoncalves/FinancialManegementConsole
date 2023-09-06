using FinancialManegementConsole.Entities.Enums;

namespace FinancialManegementConsole.Entities
{
    internal class Item
    {
        public Guid Id { get; private set; }
        public Type_item Type { get; set; }
        public string Desctiption { get; set; }
        public Category Category { get; set; }
        public double Amount { get; set; }
        public DateTime PostDate { get; set; }


        public Item(DateTime postDate, Type_item type, string desctiption, Category category, double amount)
        {
            Type = type;
            Desctiption = desctiption;
            Category = category;
            Amount = amount;
            Id = Guid.NewGuid();
            PostDate = postDate;
        }
    }
}
