namespace HospitalManagementSystemCSharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.patientRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCheckoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientRegistrationToolStripMenuItem,
            this.patientInformationToolStripMenuItem,
            this.checkoutToolStripMenuItem,
            this.roomInfoToolStripMenuItem,
            this.addStaffToolStripMenuItem,
            this.viewCheckoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 131);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 106);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // patientRegistrationToolStripMenuItem
            // 
            this.patientRegistrationToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientRegistrationToolStripMenuItem.Image = global::HospitalManagementSystemCSharp.Properties.Resources.form_icon_01;
            this.patientRegistrationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.patientRegistrationToolStripMenuItem.Name = "patientRegistrationToolStripMenuItem";
            this.patientRegistrationToolStripMenuItem.Size = new System.Drawing.Size(168, 102);
            this.patientRegistrationToolStripMenuItem.Text = "Patient Registration";
            this.patientRegistrationToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.patientRegistrationToolStripMenuItem.Click += new System.EventHandler(this.PatientRegistrationToolStripMenuItem_Click);
            // 
            // patientInformationToolStripMenuItem
            // 
            this.patientInformationToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientInformationToolStripMenuItem.Image = global::HospitalManagementSystemCSharp.Properties.Resources.patient_cards_2_512;
            this.patientInformationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.patientInformationToolStripMenuItem.Name = "patientInformationToolStripMenuItem";
            this.patientInformationToolStripMenuItem.Size = new System.Drawing.Size(162, 102);
            this.patientInformationToolStripMenuItem.Text = "Patient Information";
            this.patientInformationToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.patientInformationToolStripMenuItem.Click += new System.EventHandler(this.PatientInformationToolStripMenuItem_Click);
            // 
            // checkoutToolStripMenuItem
            // 
            this.checkoutToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutToolStripMenuItem.Image = global::HospitalManagementSystemCSharp.Properties.Resources.castio;
            this.checkoutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkoutToolStripMenuItem.Name = "checkoutToolStripMenuItem";
            this.checkoutToolStripMenuItem.Size = new System.Drawing.Size(92, 102);
            this.checkoutToolStripMenuItem.Text = "Checkout";
            this.checkoutToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.checkoutToolStripMenuItem.Click += new System.EventHandler(this.CheckoutToolStripMenuItem_Click);
            // 
            // roomInfoToolStripMenuItem
            // 
            this.roomInfoToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomInfoToolStripMenuItem.Image = global::HospitalManagementSystemCSharp.Properties.Resources._08_512;
            this.roomInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.roomInfoToolStripMenuItem.Name = "roomInfoToolStripMenuItem";
            this.roomInfoToolStripMenuItem.Size = new System.Drawing.Size(99, 102);
            this.roomInfoToolStripMenuItem.Text = "Room Info";
            this.roomInfoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roomInfoToolStripMenuItem.Click += new System.EventHandler(this.RoomInfoToolStripMenuItem_Click);
            // 
            // addStaffToolStripMenuItem
            // 
            this.addStaffToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStaffToolStripMenuItem.Image = global::HospitalManagementSystemCSharp.Properties.Resources.images__staff_;
            this.addStaffToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addStaffToolStripMenuItem.Name = "addStaffToolStripMenuItem";
            this.addStaffToolStripMenuItem.Size = new System.Drawing.Size(92, 102);
            this.addStaffToolStripMenuItem.Text = "Add Staff";
            this.addStaffToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addStaffToolStripMenuItem.Click += new System.EventHandler(this.AddStaffToolStripMenuItem_Click);
            // 
            // viewCheckoutToolStripMenuItem
            // 
            this.viewCheckoutToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewCheckoutToolStripMenuItem.Image = global::HospitalManagementSystemCSharp.Properties.Resources.chob;
            this.viewCheckoutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewCheckoutToolStripMenuItem.Name = "viewCheckoutToolStripMenuItem";
            this.viewCheckoutToolStripMenuItem.Size = new System.Drawing.Size(132, 102);
            this.viewCheckoutToolStripMenuItem.Text = "View Checkout";
            this.viewCheckoutToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.viewCheckoutToolStripMenuItem.Click += new System.EventHandler(this.ViewCheckoutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(323, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 166;
            this.pictureBox1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(754, 310);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home-HMS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem patientRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStaffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCheckoutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}