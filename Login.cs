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
    public partial class Login : Form
    {
        private OracleDB oracleDB = new OracleDB(); // Database connection
        private Home homeForm; // Reference to the Home form

        public Login(Home homeForm = null)
        {
            InitializeComponent();
            this.homeForm = homeForm; // Set the reference to the Home form
        }

        private void linkLblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Clear the content of this form (hide any panels or controls)
            this.Controls.Clear();

            // Create an instance of the SignUP form
            SignUP sign = new SignUP();

            // Set SignUP form as a child of this form
            sign.TopLevel = false;
            sign.Dock = DockStyle.Fill;

            // Add the SignUP form to this form's controls
            this.Controls.Add(sign);

            // Show the SignUP form
            sign.Show();
        }

        private bool CheckAdmin(string username)
        {
            try
            {
                // Query to check if the user is an admin
                string adminQuery = @"
            SELECT COUNT(*) FROM users 
            WHERE USERNAME = :Username AND ADMIN = 1 ";

                // Oracle parameters
                OracleParameter[] parameters = {
            new OracleParameter("Username", OracleDbType.Varchar2) { Value = username }
        };

                // Execute the query
                object result = oracleDB.ExecuteScalar(adminQuery, parameters);
                int isAdmin = Convert.ToInt32(result);

                // Return true if the user is an admin
                return isAdmin > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking admin status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(txtBoxUserName.Text) || string.IsNullOrEmpty(txtBoxPass.Text))
                {
                    MessageBox.Show("Please enter your username and passwoed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extract input data
                string username = txtBoxUserName.Text;
                string password = txtBoxPass.Text;

                // SQL query for checking username and password
                string selectQuery = @"
            SELECT COUNT(*) FROM users_cust 
            WHERE USERNAME = :Username AND PASSWORD = :Password";

                string adminQuery = @"
            SELECT COUNT(*) FROM users 
            WHERE USERNAME = :Username AND PASSWORD = :Password AND ADMIN = 1 OR EMP = 1 ";

                // Oracle parameters
                OracleParameter[] parameters = {
            new OracleParameter("Username", OracleDbType.Varchar2) { Value = username },
            new OracleParameter("Password", OracleDbType.Varchar2) { Value = password }
        };

                // Execute the query and check the result
                object result = oracleDB.ExecuteScalar(selectQuery, parameters);
                object adminResult = oracleDB.ExecuteScalar(adminQuery, parameters);
                int userExists = Convert.ToInt32(result);
                int adminExists = Convert.ToInt32(adminResult);

                if (userExists > 0)
                {
                    MessageBox.Show("User loged in successfully!", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Access the parent Home form and disable btnProfile
                    Home homeForm = Application.OpenForms.OfType<Home>().FirstOrDefault();
                    if (homeForm != null)
                    {
                        homeForm.DisableButton(); // Call the method to disable btnProfile
                    }

                    // Clear the content of this form (hide any panels or controls)
                    this.Controls.Clear();

                    // Create an instance of the ViewProducts form with an empty cart and username
                    List<CartItem> cartItems = new List<CartItem>();
                    ViewProducts viewproducts = new ViewProducts(cartItems, username);

                    // Set ViewProducts form as a child of this form
                    viewproducts.TopLevel = false;
                    viewproducts.Dock = DockStyle.Fill;

                    // Add the ViewProducts form to this form's controls
                    this.Controls.Add(viewproducts);

                    // Show the ViewProducts form
                    viewproducts.Show();
                }
                else if (adminExists > 0)
                {
                    // Check if the user is an admin
                    bool isAdmin = CheckAdmin(username);

                    // Hide the Home form
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Home) // Check for the Home form by type
                        {
                            form.Hide(); // Hide the Home form
                            break;
                        }
                    }

                    // Show the AdminScreen form and pass the admin status
                    AdminScreen adminScreen = new AdminScreen(isAdmin);
                    adminScreen.Show();
                }
                else
                {
                    MessageBox.Show("User name or password not corecctlly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBoxUserName_TextChanged(object sender, EventArgs e) { }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e) { }
    }
}