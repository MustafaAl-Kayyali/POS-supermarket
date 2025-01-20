using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class ProductsApproaching : Form
    {
        private OracleDB oracleDB = new OracleDB(); // Database connection

        public ProductsApproaching()
        {
            InitializeComponent();
            LoadProducts(); // Load products when the form is initialized
        }

        // Method to load products from the database
        private void LoadProducts()
        {
            try
            {
                // Query to fetch products from the ITEM table
                string query = "SELECT ITEM_NO, NAME, QTY, PRICE, DESCRIPTION FROM ITEM WHERE QTY < 10"; // Example: Fetch products with low stock
                DataTable dataTable = oracleDB.ExecuteQuery(query);

                // Bind the data to the DataGridView
                DataGridProducts.DataSource = dataTable;

                // Customize DataGridView columns
                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Customize DataGridView columns
        private void CustomizeDataGridView()
        {
            if (DataGridProducts.Columns.Count > 0)
            {
                DataGridProducts.Columns["ITEM_NO"].HeaderText = "Item No";
                DataGridProducts.Columns["NAME"].HeaderText = "Product Name";
                DataGridProducts.Columns["QTY"].HeaderText = "Quantity";
                DataGridProducts.Columns["PRICE"].HeaderText = "Price";
                DataGridProducts.Columns["DESCRIPTION"].HeaderText = "Description";

                // Set column widths
                DataGridProducts.Columns["ITEM_NO"].Width = 100;
                DataGridProducts.Columns["NAME"].Width = 200;
                DataGridProducts.Columns["QTY"].Width = 100;
                DataGridProducts.Columns["PRICE"].Width = 100;
                DataGridProducts.Columns["DESCRIPTION"].Width = 300;

                // Make the DataGridView read-only
                DataGridProducts.ReadOnly = true;
            }
        }

        // Event handler for the "Add Quantity" button
        private void btnAddQty_Click(object sender, EventArgs e)
        {
            if (DataGridProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to add quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = DataGridProducts.SelectedRows[0];

            // Get the product details
            int itemNo = Convert.ToInt32(selectedRow.Cells["ITEM_NO"].Value);
            string itemName = selectedRow.Cells["NAME"].Value.ToString();
            int currentQty = Convert.ToInt32(selectedRow.Cells["QTY"].Value);

            // Prompt the user to enter the new quantity
            string quantityInput = ShowInputDialog("Enter the quantity to add:", "Add Quantity", "0");

            if (quantityInput != null) // Check if the user clicked OK
            {
                if (!int.TryParse(quantityInput, out int newQty) || newQty <= 0)
                {
                    MessageBox.Show("Invalid quantity. Please enter a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update the quantity in the database
                UpdateQuantityInDatabase(itemNo, newQty);

                // Refresh the DataGridView to show the updated quantity
                LoadProducts();
            }
        }

        // Method to update the quantity in the database
        private void UpdateQuantityInDatabase(int itemNo, int newQty)
        {
            try
            {
                // Query to update the quantity
                string updateQuery = "UPDATE ITEM SET QTY = QTY + :NewQty WHERE ITEM_NO = :ItemNo";
                OracleParameter[] parameters = {
                    new OracleParameter("NewQty", newQty),
                    new OracleParameter("ItemNo", itemNo)
                };

                // Execute the query
                int rowsAffected = oracleDB.ExecuteNonQuery(updateQuery, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Quantity updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to show an input dialog
        private string ShowInputDialog(string prompt, string title, string defaultValue = "0")
        {
            // Create a form to act as the input dialog
            Form inputForm = new Form();
            inputForm.Text = title;
            inputForm.Size = new Size(300, 150);
            inputForm.StartPosition = FormStartPosition.CenterParent;

            // Add a label for the prompt
            Label lblPrompt = new Label();
            lblPrompt.Text = prompt;
            lblPrompt.Location = new Point(10, 10);
            lblPrompt.AutoSize = true;

            // Add a TextBox for the input
            TextBox txtInput = new TextBox();
            txtInput.Text = defaultValue;
            txtInput.Location = new Point(10, 40);
            txtInput.Size = new Size(260, 20);

            // Add OK and Cancel buttons
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(50, 80);

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(150, 80);

            // Add controls to the form
            inputForm.Controls.Add(lblPrompt);
            inputForm.Controls.Add(txtInput);
            inputForm.Controls.Add(btnOK);
            inputForm.Controls.Add(btnCancel);

            // Show the form and return the input value
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                return txtInput.Text;
            }

            return null; // Return null if the user cancels
        }
    }
}