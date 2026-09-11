using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
    {
        public frmInvMaint()
        {
            InitializeComponent();
        }

        // TODO: Declare here a private variable that can store a list of InvItem objects and intialize it to null.
        private List<InvItem> invItems = null;

        // Ashton Cashier
        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            // TODO: Load the list of inventory items from the database class (InvItemDB).
            // Hint: Call InvItemDB.GetItems() and assign the result to invItems.
            invItems = InvItemDB.GetItems();


            // This method call updates the list box with the items.
            FillItemListBox();
        }

        private void FillItemListBox()
        {
            lstItems.Items.Clear();
            // TODO: Code here that loads the list box with the items in the list.
            // Hint: Loop through each item in invItems and add it to lstItems.
            foreach (InvItem item in invItems)
            {
                lstItems.Items.Add(item.GetDisplayText());
            }

        }

        // Ashton Cashier
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Create an instance of the new item form (frmNewItem).
            // TODO: Call the form’s method to get the new item from the user.
            // TODO: If a new item was created (not null), add it to invItems,
            //       save the updated list using InvItemDB.SaveItems,
            //       and refresh the list box by calling FillItemListBox().
            frmNewItem newItemForm = new frmNewItem();
            InvItem newItem = newItemForm.GetNewItem();

            if (newItem != null)
            {
                invItems.Add(newItem);
                InvItemDB.SaveItems(invItems);
                FillItemListBox();
            }


        }

        // Ashton Cashier
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;
            if (i != -1)
            {
                // TODO: Add code here that displays a dialog box (Yes/No) to confirm the deletion
                //       Hint: Use MessageBox.Show with MessageBoxButtons.YesNo
                // TODO: If the user clicks "Yes":
                //          - Remove the selected item from invItems
                //          - Save the updated list with InvItemDB.SaveItems
                //          - Refresh the list box by calling FillItemListBox()
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this item?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    invItems.RemoveAt(i);
                    InvItemDB.SaveItems(invItems);
                    FillItemListBox();
                }


            }
        }

        // Ashton Cashier
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
