using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class AddProduct : Form
    {
        private OracleDB oracleDB = new OracleDB();

        public AddProduct()
        {
            InitializeComponent();
        }

        private void btnSaveProductInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(txtBoxProductNum.Text) || string.IsNullOrEmpty(txtBoxProductName.Text) ||
                    string.IsNullOrEmpty(txtBoxQty.Text) || string.IsNullOrEmpty(txtBoxPrice.Text) ||
                    string.IsNullOrEmpty(txtBoxCost.Text) || string.IsNullOrEmpty(txtBoxExpiryDate.Text) ||
                    string.IsNullOrEmpty(txtBoxProductDescription.Text))
                {
                    MessageBox.Show("Please fill in all required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure measurement is selected
                if (string.IsNullOrEmpty(txtBoxProducrMeasurment.Text))
                {
                    MessageBox.Show("Please select a unit of measurement for the product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extract input data
                int itemNo = int.Parse(txtBoxProductNum.Text);
                string name = txtBoxProductName.Text;
                int qty = int.Parse(txtBoxQty.Text);
                decimal cost = decimal.Parse(txtBoxCost.Text);
                DateTime expiryDate = DateTime.Parse(txtBoxExpiryDate.Text);
                decimal price = decimal.Parse(txtBoxPrice.Text);
                string description = txtBoxProductDescription.Text;
                string measurement = txtBoxProducrMeasurment.Text;

                // SQL query for inserting data (without IMG column)
                string insertQuery = @"
                    INSERT INTO ITEM (ITEM_NO, NAME, QTY, COST, EXPIRD_DATE, MEASURMENT, PRICE, DESCRIPTION) 
                    VALUES (:ItemNo, :Name, :Qty, :Cost, :ExpiryDate, :Measurement, :Price, :Description)";

                // Oracle parameters (without IMG parameter)
                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("ItemNo", OracleDbType.Int32) { Value = itemNo },
                    new OracleParameter("Name", OracleDbType.Varchar2) { Value = name },
                    new OracleParameter("Qty", OracleDbType.Int32) { Value = qty },
                    new OracleParameter("Cost", OracleDbType.Decimal) { Value = cost },
                    new OracleParameter("ExpiryDate", OracleDbType.Date) { Value = expiryDate },
                    new OracleParameter("Measurement", OracleDbType.Varchar2) { Value = measurement },
                    new OracleParameter("Price", OracleDbType.Decimal) { Value = price },
                    new OracleParameter("Description", OracleDbType.Varchar2) { Value = description }
                };

                // Execute the query
                int rowsAffected = oracleDB.ExecuteNonQuery(insertQuery, parameters);

                // Check operation success
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Product not inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Make sure you entered the numeric value!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProductMeasurment_Click(object sender, EventArgs e)
        {
            using (Measurement frmMeasurement = new Measurement())
            {
                if (frmMeasurement.ShowDialog() == DialogResult.OK)
                {
                    string measurement = frmMeasurement.GetSelectedMeasurement();
                    if (!string.IsNullOrEmpty(measurement))
                    {
                        txtBoxProducrMeasurment.Text = measurement;
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Add custom painting logic here
        }

        private void btnCancelAddProduct_Click(object sender, EventArgs e)
        {
            txtBoxProductNum.Clear();
            txtBoxProductName.Clear();
            txtBoxQty.Clear();
            txtBoxPrice.Clear();
            txtBoxCost.Clear();
            txtBoxExpiryDate.Clear();
            txtBoxProductDescription.Clear();
            txtBoxProducrMeasurment.Clear();
        }
    }
}