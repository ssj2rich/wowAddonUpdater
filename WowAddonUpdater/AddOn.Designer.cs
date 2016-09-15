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
            this.SuspendLayout();
            // 
            // tbAddonName
            // 
            this.tbAddonName.Location = new System.Drawing.Point(4, 11);
            this.tbAddonName.Name = "tbAddonName";
            this.tbAddonName.Size = new System.Drawing.Size(142, 20);
            this.tbAddonName.TabIndex = 0;
            this.tbAddonName.Text = "Addon Name";
            // 
            // tbAddonUrl
            // 
            this.tbAddonUrl.Location = new System.Drawing.Point(176, 11);
            this.tbAddonUrl.Name = "tbAddonUrl";
            this.tbAddonUrl.Size = new System.Drawing.Size(457, 20);
            this.tbAddonUrl.TabIndex = 1;
            this.tbAddonUrl.Text = "Addon Url";
            // 
            // btnUpdateAddon
            // 
            this.btnUpdateAddon.Location = new System.Drawing.Point(640, 7);
            this.btnUpdateAddon.Name = "btnUpdateAddon";
            this.btnUpdateAddon.Size = new System.Drawing.Size(100, 23);
            this.btnUpdateAddon.TabIndex = 2;
            this.btnUpdateAddon.Text = "Update";
            this.btnUpdateAddon.UseVisualStyleBackColor = true;
            this.btnUpdateAddon.Click += new System.EventHandler(this.btnUpdateAddon_Click);
            // 
            // AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdateAddon);
            this.Controls.Add(this.tbAddonUrl);
            this.Controls.Add(this.tbAddonName);
            this.Name = "AddOn";
            this.Size = new System.Drawing.Size(743, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddonName;
        private System.Windows.Forms.TextBox tbAddonUrl;
        private System.Windows.Forms.Button btnUpdateAddon;
    }
}
