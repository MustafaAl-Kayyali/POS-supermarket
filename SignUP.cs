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
    public partial class SignUP : Form
    {
        private OracleDB oracleDB = new OracleDB();

        public SignUP()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(txtBoxUserName.Text) || string.IsNullOrEmpty(txtBoxPassword.Text) ||
                    string.IsNullOrEmpty(txtBoxConfirmPassword.Text) || string.IsNullOrEmpty(txtBoxPhoneNum.Text) ||
                    string.IsNullOrEmpty(txtBoxEmail.Text))
                {
                    MessageBox.Show("Please Enter in all requierd informations!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if passwords match
                if (txtBoxPassword.Text != txtBoxConfirmPassword.Text)
                {
                    MessageBox.Show("Mismatched passwords!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extract input data
                string username = txtBoxUserName.Text;
                string password = txtBoxPassword.Text;
                string phoneNumber = txtBoxPhoneNum.Text;
                string email = txtBoxEmail.Text;
                string cust_no = "1";

                // SQL query for inserting data
                string insertQuery = @"
                    INSERT INTO users_cust (cust_no, USERNAME, PASSWORD, PHONE_NUMBER, EMAIL) 
                    VALUES (:cust_no, :Username, :Password, :PhoneNumber, :Email)";

                // Oracle parameters
                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("cust_no", OracleDbType.Varchar2) { Value = cust_no },
                    new OracleParameter("Username", OracleDbType.Varchar2) { Value = username },
                    new OracleParameter("Password", OracleDbType.Varchar2) { Value = password },
                    new OracleParameter("PhoneNumber", OracleDbType.Varchar2) { Value = phoneNumber },
                    new OracleParameter("Email", OracleDbType.Varchar2) { Value = email }
                };

                // Execute the query
                int rowsAffected = oracleDB.ExecuteNonQuery(insertQuery, parameters);

                // Check operation success
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User registered successfully!", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optionally clear input fields
                    txtBoxUserName.Text = string.Empty;
                    txtBoxPassword.Text = string.Empty;
                    txtBoxConfirmPassword.Text = string.Empty;
                    txtBoxPhoneNum.Text = string.Empty;
                    txtBoxEmail.Text = string.Empty;
                    
                }
                else
                {
                    MessageBox.Show("User will not be registered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Make sure you enter the values correctly!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Clear the content of this form (hide any panels or controls)
            this.Controls.Clear();

            // Create an instance of the Login form
            Login formLogin = new Login();

            // Set Login form as a child of this form
            formLogin.TopLevel = false;
            formLogin.Dock = DockStyle.Fill;

            // Add the Login form to this form's controls
            this.Controls.Add(formLogin);

            // Show the Login form
            formLogin.Show();
            
            
        }

        // Optional event handlers for UI inputs
        private void txtBoxUserName_TextChanged(object sender, EventArgs e) { }

        private void txtBoxPhoneNum_TextChanged(object sender, EventArgs e) { }

        private void txtBoxEmail_TextChanged(object sender, EventArgs e) { }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e) { }

        private void txtBoxConfirmPassword_TextChanged(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
    }
}
