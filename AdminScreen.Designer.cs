namespace Supermarket
{
    partial class AdminScreen
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
            this.btnAdministrator = new Guna.UI2.WinForms.Guna2Button();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnWarehouse = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdminProfile = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.btnAdministrator);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnWarehouse);
            this.panel1.Controls.Add(this.btnAdminProfile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 704);
            this.panel1.TabIndex = 2;
            // 
            // btnAdministrator
            // 
            this.btnAdministrator.AutoRoundedCorners = true;
            this.btnAdministrator.BorderRadius = 18;
            this.btnAdministrator.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdministrator.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdministrator.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdministrator.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdministrator.FillColor = System.Drawing.Color.Green;
            this.btnAdministrator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdministrator.ForeColor = System.Drawing.Color.White;
            this.btnAdministrator.Location = new System.Drawing.Point(30, 324);
            this.btnAdministrator.Name = "btnAdministrator";
            this.btnAdministrator.Size = new System.Drawing.Size(128, 39);
            this.btnAdministrator.TabIndex = 4;
            this.btnAdministrator.Text = "AdminIstrator";
            this.btnAdministrator.Click += new System.EventHandler(this.btnAdministrator_Click);
            // 
            // btnReports
            // 
            this.btnReports.AutoRoundedCorners = true;
            this.btnReports.BorderRadius = 20;
            this.btnReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReports.FillColor = System.Drawing.Color.Green;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(30, 260);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(118, 42);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.AutoRoundedCorners = true;
            this.btnWarehouse.BorderRadius = 20;
            this.btnWarehouse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnWarehouse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnWarehouse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnWarehouse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnWarehouse.FillColor = System.Drawing.Color.Green;
            this.btnWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnWarehouse.Location = new System.Drawing.Point(30, 185);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(118, 42);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.Text = "Warehose";
            this.btnWarehouse.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // btnAdminProfile
            // 
            this.btnAdminProfile.BackColor = System.Drawing.Color.Green;
            this.btnAdminProfile.BackgroundImage = global::Supermarket.Properties.Resources.profile;
            this.btnAdminProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdminProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminProfile.ForeColor = System.Drawing.Color.Green;
            this.btnAdminProfile.Location = new System.Drawing.Point(49, 18);
            this.btnAdminProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdminProfile.Name = "btnAdminProfile";
            this.btnAdminProfile.Size = new System.Drawing.Size(65, 62);
            this.btnAdminProfile.TabIndex = 0;
            this.btnAdminProfile.UseVisualStyleBackColor = false;
            this.btnAdminProfile.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.White;
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(0, 58);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1178, 704);
            this.mainpanel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGreen;
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1178, 58);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FillColor = System.Drawing.Color.LightGray;
            this.btnExit.IconColor = System.Drawing.Color.DarkGreen;
            this.btnExit.Location = new System.Drawing.Point(1139, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExit.Size = new System.Drawing.Size(36, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AdminScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 762);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminScreen";
            this.Text = "AdminScreen";
            this.Load += new System.EventHandler(this._ِAdminScreen_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnWarehouse;
        private System.Windows.Forms.Button btnAdminProfile;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnAdministrator;
        private Guna.UI2.WinForms.Guna2Button btnReports;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
    }
}