namespace WowAddonUpdater
{
    partial class Form1
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbSelectedFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddAddon = new System.Windows.Forms.Button();
            this.cbUpdateOnStart = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(55, 502);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 32);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbSelectedFolder
            // 
            this.tbSelectedFolder.Location = new System.Drawing.Point(193, 36);
            this.tbSelectedFolder.Name = "tbSelectedFolder";
            this.tbSelectedFolder.Size = new System.Drawing.Size(358, 20);
            this.tbSelectedFolder.TabIndex = 1;
            this.tbSelectedFolder.Enter += new System.EventHandler(this.tbSelectedFolder_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder to store files";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(55, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 402);
            this.panel1.TabIndex = 3;
            // 
            // btnAddAddon
            // 
            this.btnAddAddon.Location = new System.Drawing.Point(811, 502);
            this.btnAddAddon.Name = "btnAddAddon";
            this.btnAddAddon.Size = new System.Drawing.Size(110, 32);
            this.btnAddAddon.TabIndex = 4;
            this.btnAddAddon.Text = "Add Addon";
            this.btnAddAddon.UseVisualStyleBackColor = true;
            this.btnAddAddon.Click += new System.EventHandler(this.btnAddAddon_Click);
            // 
            // cbUpdateOnStart
            // 
            this.cbUpdateOnStart.AutoSize = true;
            this.cbUpdateOnStart.Location = new System.Drawing.Point(594, 36);
            this.cbUpdateOnStart.Name = "cbUpdateOnStart";
            this.cbUpdateOnStart.Size = new System.Drawing.Size(113, 17);
            this.cbUpdateOnStart.TabIndex = 5;
            this.cbUpdateOnStart.Text = "Update On startup";
            this.cbUpdateOnStart.UseVisualStyleBackColor = true;
            this.cbUpdateOnStart.CheckedChanged += new System.EventHandler(this.cbUpdateOnStart_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 556);
            this.Controls.Add(this.cbUpdateOnStart);
            this.Controls.Add(this.btnAddAddon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSelectedFolder);
            this.Controls.Add(this.btnUpdate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tbSelectedFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddAddon;
        private System.Windows.Forms.CheckBox cbUpdateOnStart;
    }
}

