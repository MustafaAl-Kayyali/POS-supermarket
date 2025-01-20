using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class ViewProducts : Form
    {
        private OracleDB oracleDB = new OracleDB();
        private List<CartItem> cartItems;
        private string username; // Store the logged-in username

        public ViewProducts(List<CartItem> cartItems, string username)
        {
            InitializeComponent();
            this.cartItems = cartItems;
            this.username = username;
        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            CustomizeDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            string query = "SELECT NAME AS \"Name\", PRICE AS \"Price\", QTY AS \"Quantity\", DESCRIPTION AS \"Description\" FROM ITEM";

            try
            {
                DataTable dataTable = oracleDB.ExecuteQuery(query);
                DataGridViewProducts.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            if (DataGridViewProducts.Columns.Count > 0)
            {
                DataGridViewProducts.Columns["Name"].Width = 200;
                DataGridViewProducts.Columns["Price"].Width = 100;
                DataGridViewProducts.Columns["Quantity"].Width = 100;
                DataGridViewProducts.Columns["Description"].Width = 300;
                DataGridViewProducts.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DataGridViewProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
            }

            DataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewProducts.ReadOnly = true;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (DataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to add to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = DataGridViewProducts.SelectedRows[0];

            if (selectedRow.Cells["Name"].Value == null || selectedRow.Cells["Price"].Value == null || selectedRow.Cells["Quantity"].Value == null)
            {
                MessageBox.Show("Selected product has invalid data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string itemName = selectedRow.Cells["Name"].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int availableQuantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

            // Prompt the user to enter the quantity
            string quantityInput = ShowInputDialog("Enter Quantity:", "Quantity", "1");

            if (quantityInput != null) // Check if the user clicked OK
            {
                if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Invalid quantity. Please enter a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the requested quantity is available
                if (quantity > availableQuantity)
                {
                    MessageBox.Show($"Requested quantity exceeds available stock. Available quantity: {availableQuantity}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Start a transaction to ensure atomicity
                using (OracleConnection connection = oracleDB.GetConnection())
                {
                    connection.Open();
                    OracleTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Add item to cart
                        cartItems.Add(new CartItem { Name = itemName, Price = price, Quantity = quantity });

                        // Update the database to reduce the quantity
                        string updateQuery = "UPDATE ITEM SET QTY = QTY - :Quantity WHERE NAME = :Name";
                        OracleParameter[] parameters = {
                            new OracleParameter("Quantity", quantity),
                            new OracleParameter("Name", itemName)
                        };

                        oracleDB.ExecuteNonQuery(updateQuery, parameters, transaction);

                        // Commit the transaction
                        transaction.Commit();

                        // Notify the user that the item has been added
                        MessageBox.Show("Item added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show($"Error adding item to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string ShowInputDialog(string prompt, string title, string defaultValue = "1")
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

    public class CartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity; // Calculate total price for the item
    }
}