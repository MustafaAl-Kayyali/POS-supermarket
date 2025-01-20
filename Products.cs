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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (this.ProductPanel.Controls.Count > 0)
                this.ProductPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.ProductPanel.Controls.Add(f);
            this.ProductPanel.Tag = f;
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Clear the content of Form4 (hide any panels or controls)
            this.Controls.Clear();

            // Create an instance of Form2
            Warehouse frmWarehouse = new Warehouse();

            // Set Form2 as a child of Form4
            frmWarehouse.TopLevel = false;
            frmWarehouse.Dock = DockStyle.Fill;

            // Add Form2 to Form4's controls
            this.Controls.Add(frmWarehouse);

            // Show Form2
            frmWarehouse.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadform(new AddProduct());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
        }
    }
}
