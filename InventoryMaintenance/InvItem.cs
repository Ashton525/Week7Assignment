using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    // This class shows encapsulation because it keeps all the data about
    // one item (ItemNo, Description, Price) and the method that uses that
    // data (GetDisplayText) together in one place. Other classes have to
    // go through the properties to get or change the data instead of
    // touching it directly.
    public class InvItem
    {
        public int ItemNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Ashton Cashier
        // Default constructor - creates an InvItem object with default
        // values (ItemNo = 0, Description = "", Price = 0).
        public InvItem()
        {
            ItemNo = 0;
            Description = "";
            Price = 0;
        }

        // Ashton Cashier
        // Parameterized constructor - creates an InvItem object using the
        // item number, description, and price supplied by the caller.
        public InvItem(int itemNo, string description, decimal price)
        {
            ItemNo = itemNo;
            Description = description;
            Price = price;
        }

        // Ashton Cashier
        public string GetDisplayText()
        {
            return ItemNo + "    " + Description + " (" + Price.ToString("c") + ")";
        }
    }
}
