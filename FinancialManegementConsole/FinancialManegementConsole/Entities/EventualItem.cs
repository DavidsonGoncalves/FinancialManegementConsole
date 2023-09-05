using FinancialManegementConsole.Entities.Enums;

namespace FinancialManegementConsole.Entities
{
    internal class EventualItem : Item
    {
        public DateTime Date { get; set; }

        public EventualItem(DateTime date,Type_item type, string desctiption, Category category, double amount) : base( type, desctiption, category, amount)
        {
            Date = date;
        }

    }
}
