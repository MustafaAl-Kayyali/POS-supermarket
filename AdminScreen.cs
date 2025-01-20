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
    public partial class AdminScreen : Form
    {
        private bool isAdmin; // Store the admin status

        public AdminScreen(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin; // Set the admin status
        }

        private void _ِAdminScreen_Load(object sender, EventArgs e)
        {
            // Hide the Administrator button if the user is not an admin
            if (!isAdmin)
            {
                btnAdministrator.Visible = false;
            }
        }

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadform(new Warehouse());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdministrator_Click(object sender, EventArgs e)
        {
            loadform(new frmAdminIsrator());
        }
        public Point mouseLocation;
        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
    }
}