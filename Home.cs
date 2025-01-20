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
    public partial class Home : Form
    {
        // List to store cart items
        private List<CartItem> cartItems = new List<CartItem>();
        private string username; // Store the logged-in username

        public Home(string username)
        {
            InitializeComponent();
            this.username = username;
            loadform(new Login()); // Load the Login form initially (optional)
        }

        // Method to load forms into the main panel
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the application
        }

        private void btnHomeProduct_Click(object sender, EventArgs e)
        {
            // Pass the cartItems list and username to the ViewProducts form
            ViewProducts viewProductsForm = new ViewProducts(cartItems, username);
            loadform(viewProductsForm);
        }

        private void btnHomeCart_Click(object sender, EventArgs e)
        {
            // Pass the cartItems list and username to the Cart form
            Cart cartForm = new Cart(cartItems, username);

            // Refresh the Cart form with the latest cartItems list
            cartForm.UpdateCartData(cartItems);

            // Load the Cart form into the main panel
            loadform(cartForm);
        }
        
        public bool DisableButton()
        {
            btnProfile.Enabled = false; // Disable the profile button (example)
            return btnProfile.Enabled;
        }
        public Point mouseLocation;
        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation=new Point(-e.X,-e.Y);
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) 
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
    }
}