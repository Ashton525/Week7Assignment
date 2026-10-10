namespace InventoryMaintenance
{
    public partial class frmInventoryMaint : Form
    {
        public frmInventoryMaint()
        {
            InitializeComponent();
        }

        private List<InventoryItem> items = null!;

        // Ashton Cashier
        private void frmInventoryMaint_Load(object sender, EventArgs e)
        {
            items = InventoryDB.GetItems();
            LoadComboBox();
            FillItemListBox();
        }

        private void LoadComboBox()
        {
            cboFilterBy.DataSource = new string[] {
                "All", "Under $10", "$10 to $50", "Over $50"
            };
        }

        // Ashton Cashier
        private void FillItemListBox()
        {
            lstItems.Items.Clear();

            string filter = cboFilterBy.SelectedValue?.ToString() ?? "";
            IEnumerable<InventoryItem> filteredItems = null!;
            if ( filter == "All")
            {
                filteredItems = from item in items orderby item.Description select item;
            }
            else if (filter == "Under $10")
            {
                filteredItems = from item in items where item.Price < 10 orderby item.Description select item;
            }
            else if(filter == "$10 to $50")
            {
                filteredItems = from item in items where item.Price >= 10 && item.Price <= 50 orderby item.Description select item;
            }
            else if (filter == "Over $50")
            {
                filteredItems = from item in items where item.Price > 50 orderby item.Description select item;
            }


            // add items to the filteredItems collection based on FilterBy value

            // change code to loop the filteredItems collection
            foreach (InventoryItem item in filteredItems)
            {
                lstItems.Items.Add(item.GetDisplayText());
            }
        }

        // Ashton Cashier
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewItem newItemForm = new();
            InventoryItem item = newItemForm.GetNewItem();
            if (item != null)
            {
                items.Add(item);
                InventoryDB.SaveItems(items);
                FillItemListBox();
            }
        }

        // Ashton Cashier
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;

            if (i == -1)
            {
                MessageBox.Show("Please select an item to delete.", "No item selected");
            }
            else
            {
                //  InventoryItem item = items[i];
                string displayText = lstItems.Items[i].ToString()!;
                InventoryItem item = items. Where(x => x.GetDisplayText() == displayText).FirstOrDefault()!;        
                string message = $"Are you sure you want to delete {item.Description}?";
                DialogResult result =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    items.Remove(item);
                    InventoryDB.SaveItems(items);
                    FillItemListBox();
                }
            }
        }

        // Ashton Cashier
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Ashton Cashier
        private void cboFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillItemListBox();
        }
    }
}