using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class Cart : Form
    {
        private List<CartItem> cartItems;
        private string username; // Store the logged-in username

        public Cart(List<CartItem> cartItems, string username)
        {
            InitializeComponent();
            this.cartItems = cartItems;
            this.username = username;

            // Initialize DataGridView columns
            InitializeDataGridViewColumns();

            // Load cart data
            LoadCartData();

            // Update the total price label
            UpdateTotalPrice();
        }

        private void InitializeDataGridViewColumns()
        {
            // Clear existing columns (if any)
            DataGridViewCart.Columns.Clear();

            // Add columns to the DataGridView
            DataGridViewCart.Columns.Add("Name", "Name");
            DataGridViewCart.Columns.Add("Price", "Price");
            DataGridViewCart.Columns.Add("Quantity", "Quantity");
            DataGridViewCart.Columns.Add("Total", "Total");

            // Customize column properties
            DataGridViewCart.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCart.Columns["Price"].DefaultCellStyle.Format = "C2";
            DataGridViewCart.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCart.Columns["Total"].DefaultCellStyle.Format = "C2";
        }

        public void UpdateCartData(List<CartItem> updatedCartItems)
        {
            this.cartItems = updatedCartItems; // Update the cartItems list
            LoadCartData(); // Reload the DataGridView
            UpdateTotalPrice(); // Update the total price label
        }

        private void LoadCartData()
        {
            // Clear existing rows
            DataGridViewCart.Rows.Clear();

            // Add rows to the DataGridView
            foreach (var item in cartItems)
            {
                DataGridViewCart.Rows.Add(item.Name, item.Price, item.Quantity, item.Total);
            }
        }

        private void UpdateTotalPrice()
        {
            // Calculate the total price of all items in the cart
            decimal totalPrice = 0;
            foreach (var item in cartItems)
            {
                totalPrice += item.Total;
            }

            // Update the total price label
            lblTotalPrice.Text = $"Total Price: {totalPrice:C2}";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DataGridViewCart.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = DataGridViewCart.SelectedRows[0];

                // Get the name and quantity of the selected product
                string itemName = selectedRow.Cells["Name"].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

                // Remove the selected product from the cart
                cartItems.RemoveAll(item => item.Name == itemName);

                // Return the quantity to the database
                ReturnQuantityToDatabase(itemName, quantity);

                // Reload the cart data
                LoadCartData();

                // Update the total price label
                UpdateTotalPrice();

                MessageBox.Show("Item removed from cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("The cart is already empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Return quantities of all items to the database
            foreach (var item in cartItems)
            {
                ReturnQuantityToDatabase(item.Name, item.Quantity);
            }

            // Clear the entire cart
            cartItems.Clear();

            // Reload the cart data
            LoadCartData();

            // Update the total price label
            UpdateTotalPrice();

            MessageBox.Show("Cart cleared successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Add items before purchasing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update item quantities in the database and save the sales record
            UpdateItemQuantities();
            SaveSalesRecord();

            // Clear the cart after purchase
            cartItems.Clear();
            LoadCartData();

            // Update the total price label
            UpdateTotalPrice();

            MessageBox.Show("Purchase completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateItemQuantities()
        {
            OracleDB oracleDB = new OracleDB();

            foreach (var item in cartItems)
            {
                string updateQuery = "UPDATE ITEM SET QTY = QTY - :Quantity WHERE NAME = :Name";
                OracleParameter[] parameters = {
                    new OracleParameter("Quantity", item.Quantity),
                    new OracleParameter("Name", item.Name)
                };

                oracleDB.ExecuteNonQuery(updateQuery, parameters);
            }
        }

        private void ReturnQuantityToDatabase(string itemName, int quantity)
        {
            OracleDB oracleDB = new OracleDB();

            string updateQuery = "UPDATE ITEM SET QTY = QTY + :Quantity WHERE NAME = :Name";
            OracleParameter[] parameters = {
                new OracleParameter("Quantity", quantity),
                new OracleParameter("Name", itemName)
            };

            oracleDB.ExecuteNonQuery(updateQuery, parameters);
        }

        private void SaveSalesRecord()
        {
            string salesFilePath = $"sales_record_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(salesFilePath))
                {
                    writer.WriteLine("Sales Record");
                    writer.WriteLine("-----------------------------");
                    writer.WriteLine($"Date: {DateTime.Now}");
                    writer.WriteLine($"Username: {username}");
                    writer.WriteLine("Items Purchased:");
                    foreach (var item in cartItems)
                    {
                        writer.WriteLine($"{item.Name} - {item.Quantity} x {item.Price:C2} = {item.Total:C2}");
                    }
                }

                MessageBox.Show($"Sales record saved: {salesFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving sales record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}