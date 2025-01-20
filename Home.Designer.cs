namespace Supermarket
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHomeCart = new Guna.UI2.WinForms.Guna2Button();
            this.btnHomeProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.btnHomeCart);
            this.panel1.Controls.Add(this.btnHomeProduct);
            this.panel1.Controls.Add(this.btnProfile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 680);
            this.panel1.TabIndex = 0;
            // 
            // btnHomeCart
            // 
            this.btnHomeCart.AutoRoundedCorners = true;
            this.btnHomeCart.BorderRadius = 20;
            this.btnHomeCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHomeCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHomeCart.FillColor = System.Drawing.Color.Green;
            this.btnHomeCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHomeCart.ForeColor = System.Drawing.Color.White;
            this.btnHomeCart.Location = new System.Drawing.Point(30, 237);
            this.btnHomeCart.Name = "btnHomeCart";
            this.btnHomeCart.Size = new System.Drawing.Size(118, 42);
            this.btnHomeCart.TabIndex = 2;
            this.btnHomeCart.Text = "Cart";
            this.btnHomeCart.Click += new System.EventHandler(this.btnHomeCart_Click);
            // 
            // btnHomeProduct
            // 
            this.btnHomeProduct.AutoRoundedCorners = true;
            this.btnHomeProduct.BorderRadius = 20;
            this.btnHomeProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHomeProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHomeProduct.FillColor = System.Drawing.Color.Green;
            this.btnHomeProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHomeProduct.ForeColor = System.Drawing.Color.White;
            this.btnHomeProduct.Location = new System.Drawing.Point(30, 167);
            this.btnHomeProduct.Name = "btnHomeProduct";
            this.btnHomeProduct.Size = new System.Drawing.Size(118, 42);
            this.btnHomeProduct.TabIndex = 1;
            this.btnHomeProduct.Text = "Product";
            this.btnHomeProduct.Click += new System.EventHandler(this.btnHomeProduct_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Green;
            this.btnProfile.BackgroundImage = global::Supermarket.Properties.Resources.profile;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.ForeColor = System.Drawing.Color.Green;
            this.btnProfile.Location = new System.Drawing.Point(49, 18);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(65, 62);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGreen;
            this.flowLayoutPanel1.Controls.Add(this.guna2ControlBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1268, 58);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.LightGray;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.DarkGreen;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1220, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(0, 58);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1268, 680);
            this.mainpanel.TabIndex = 1;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 738);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Button btnProfile;
        private Guna.UI2.WinForms.Guna2Button btnHomeCart;
        private Guna.UI2.WinForms.Guna2Button btnHomeProduct;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}