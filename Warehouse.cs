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
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }
       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Clear the content of Form4 (hide any panels or controls)
            this.Controls.Clear();

            // Create an instance of Form2
            Products products1 = new Products();

            // Set Form2 as a child of Form4
            products1.TopLevel = false;
            products1.Dock = DockStyle.Fill;

            // Add Form2 to Form4's controls
            this.Controls.Add(products1);

            // Show Form2
            products1.Show();
        }

        private void btnProductsApproaching_Click(object sender, EventArgs e)
        {
            // Clear the content of Form4 (hide any panels or controls)
            this.Controls.Clear();

            // Create an instance of Form2
            ProductsApproaching productsApproaching = new ProductsApproaching();

            // Set Form2 as a child of Form4
            productsApproaching.TopLevel = false;
            productsApproaching.Dock = DockStyle.Fill;

            // Add Form2 to Form4's controls
            this.Controls.Add(productsApproaching);

            // Show Form2
            productsApproaching.Show();
        }
    }
}
