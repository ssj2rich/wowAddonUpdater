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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbSelectedFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddAddon = new System.Windows.Forms.Button();
            this.cbUpdateOnStart = new System.Windows.Forms.CheckBox();
            this.cbCloseOnFinish = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Image = global::WowAddonUpdater.Properties.Resources.Update;
            this.btnUpdate.Location = new System.Drawing.Point(55, 502);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 38);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.MouseEnter += new System.EventHandler(this.btnUpdate_MouseHover);
            this.btnUpdate.MouseLeave += new System.EventHandler(this.btnUpdate_MouseLeave);
            // 
            // tbSelectedFolder
            // 
            this.tbSelectedFolder.Location = new System.Drawing.Point(193, 35);
            this.tbSelectedFolder.Name = "tbSelectedFolder";
            this.tbSelectedFolder.Size = new System.Drawing.Size(358, 20);
            this.tbSelectedFolder.TabIndex = 1;
            this.tbSelectedFolder.TextChanged += new System.EventHandler(this.tbSelectedFolder_TextChanged);
            this.tbSelectedFolder.Enter += new System.EventHandler(this.tbSelectedFolder_Enter);
            this.tbSelectedFolder.Leave += new System.EventHandler(this.tbSelectedFolder_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(52, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
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
            this.btnAddAddon.BackColor = System.Drawing.Color.Transparent;
            this.btnAddAddon.FlatAppearance.BorderSize = 0;
            this.btnAddAddon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAddon.Image = global::WowAddonUpdater.Properties.Resources.add;
            this.btnAddAddon.Location = new System.Drawing.Point(771, 502);
            this.btnAddAddon.Name = "btnAddAddon";
            this.btnAddAddon.Size = new System.Drawing.Size(150, 38);
            this.btnAddAddon.TabIndex = 4;
            this.btnAddAddon.UseVisualStyleBackColor = false;
            this.btnAddAddon.Click += new System.EventHandler(this.btnAddAddon_Click);
            this.btnAddAddon.MouseEnter += new System.EventHandler(this.btnAddAddon_MouseEnter);
            this.btnAddAddon.MouseLeave += new System.EventHandler(this.btnAddAddon_MouseLeave);
            // 
            // cbUpdateOnStart
            // 
            this.cbUpdateOnStart.AutoSize = true;
            this.cbUpdateOnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUpdateOnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbUpdateOnStart.Location = new System.Drawing.Point(594, 35);
            this.cbUpdateOnStart.Name = "cbUpdateOnStart";
            this.cbUpdateOnStart.Size = new System.Drawing.Size(144, 21);
            this.cbUpdateOnStart.TabIndex = 5;
            this.cbUpdateOnStart.Text = "Update On startup";
            this.cbUpdateOnStart.UseVisualStyleBackColor = true;
            this.cbUpdateOnStart.CheckedChanged += new System.EventHandler(this.cbUpdateOnStart_CheckedChanged);
            // 
            // cbCloseOnFinish
            // 
            this.cbCloseOnFinish.AutoSize = true;
            this.cbCloseOnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCloseOnFinish.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbCloseOnFinish.Location = new System.Drawing.Point(780, 35);
            this.cbCloseOnFinish.Name = "cbCloseOnFinish";
            this.cbCloseOnFinish.Size = new System.Drawing.Size(141, 21);
            this.cbCloseOnFinish.TabIndex = 6;
            this.cbCloseOnFinish.Text = "Close When Done";
            this.cbCloseOnFinish.UseVisualStyleBackColor = true;
            this.cbCloseOnFinish.CheckedChanged += new System.EventHandler(this.cbCloseOnFinish_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(996, 556);
            this.Controls.Add(this.cbCloseOnFinish);
            this.Controls.Add(this.cbUpdateOnStart);
            this.Controls.Add(this.btnAddAddon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSelectedFolder);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Wow Addon Updater";
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
        private System.Windows.Forms.CheckBox cbCloseOnFinish;
    }
}

