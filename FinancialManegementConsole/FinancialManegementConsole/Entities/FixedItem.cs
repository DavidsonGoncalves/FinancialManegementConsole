
using FinancialManegementConsole.Entities.Enums;

namespace FinancialManegementConsole.Entities
{
    internal class FixedItem : Item
    {
      

        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

        public FixedItem(DateTime initialDate, DateTime finalDate, Type_item type, string desctiption, Category category, double amount) : base(type, desctiption, category, amount)
        {
            InitialDate = finalDate;
            FinalDate = initialDate;
        }

    }
}
