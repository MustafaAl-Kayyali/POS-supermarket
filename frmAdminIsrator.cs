using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Supermarket
{
    public partial class frmAdminIsrator : Form
    {
        private OracleDB oracleDB = new OracleDB();

        public frmAdminIsrator()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBoxID.Text) || string.IsNullOrEmpty(txtBoxUserName.Text) || string.IsNullOrEmpty(txtBoxPass.Text))
                {
                    MessageBox.Show("Please fill in all required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int empNo = int.Parse(txtBoxID.Text);
                string username = txtBoxUserName.Text;
                string password = txtBoxPass.Text;
                int isAdmin = CheckBoxAdmin.Checked ? 1 : 0;
                int isEmployee = 1;

                string insertQuery = "INSERT INTO USERS (EMP_NO, USERNAME, PASSWORD, ADMIN, EMP) VALUES (:EmpNo, :Username, :Password, :Admin, :Emp)";

                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("EmpNo", empNo),
                    new OracleParameter("Username", username),
                    new OracleParameter("Password", password),
                    new OracleParameter("Admin", isAdmin),
                    new OracleParameter("Emp", isEmployee)
                };

                int rowsAffected = oracleDB.ExecuteNonQuery(insertQuery, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Entered successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records were enterd!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Make sure you enerd the numeric values correctly!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}