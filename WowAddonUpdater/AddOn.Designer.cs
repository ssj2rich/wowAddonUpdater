namespace WowAddonUpdater
{
    partial class AddOn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbAddonName = new System.Windows.Forms.TextBox();
            this.tbAddonUrl = new System.Windows.Forms.TextBox();
            this.btnUpdateAddon = new System.Windows.Forms.Button();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAddonName
            // 
            this.tbAddonName.Location = new System.Drawing.Point(47, 12);
            this.tbAddonName.Name = "tbAddonName";
            this.tbAddonName.Size = new System.Drawing.Size(142, 20);
            this.tbAddonName.TabIndex = 0;
            this.tbAddonName.Text = "Addon Name";
            // 
            // tbAddonUrl
            // 
            this.tbAddonUrl.Location = new System.Drawing.Point(219, 12);
            this.tbAddonUrl.Name = "tbAddonUrl";
            this.tbAddonUrl.Size = new System.Drawing.Size(457, 20);
            this.tbAddonUrl.TabIndex = 1;
            this.tbAddonUrl.Text = "Addon Url";
            // 
            // btnUpdateAddon
            // 
            this.btnUpdateAddon.Location = new System.Drawing.Point(683, 8);
            this.btnUpdateAddon.Name = "btnUpdateAddon";
            this.btnUpdateAddon.Size = new System.Drawing.Size(100, 23);
            this.btnUpdateAddon.TabIndex = 2;
            this.btnUpdateAddon.Text = "Add";
            this.btnUpdateAddon.UseVisualStyleBackColor = true;
            this.btnUpdateAddon.Click += new System.EventHandler(this.btnUpdateAddon_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.AccessibleDescription = "test";
            this.pbStatus.Image = global::WowAddonUpdater.Properties.Resources.sign_warning_icon;
            this.pbStatus.Location = new System.Drawing.Point(4, 3);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(37, 35);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 5;
            this.pbStatus.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WowAddonUpdater.Properties.Resources.close_map;
            this.pictureBox1.Location = new System.Drawing.Point(799, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(48, 41);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 6;
            // 
            // AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUpdateAddon);
            this.Controls.Add(this.tbAddonUrl);
            this.Controls.Add(this.tbAddonName);
            this.Name = "AddOn";
            this.Size = new System.Drawing.Size(846, 57);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbAddonName;
        public System.Windows.Forms.TextBox tbAddonUrl;
        public System.Windows.Forms.Button btnUpdateAddon;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pbStatus;
        public System.Windows.Forms.Label lblStatus;
    }
}
