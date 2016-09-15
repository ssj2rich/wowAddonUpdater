using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace WowAddonUpdater
{
    public partial class AddOn : UserControl
    {
        public event EventHandler LabelsTextChanged;

        public AddOn()
        {
            InitializeComponent();

        }

        public void updateName()
        {
            this.Name = tbAddonName.Text;
        }

        private void HandleLabelTextChanged(object sender, EventArgs e)
        {
            // we'll explain this in a minute
            this.OnLabelsTextChanged(EventArgs.Empty);
        }

        protected virtual void OnLabelsTextChanged(EventArgs e)
        {
            EventHandler handler = this.LabelsTextChanged;
            if (handler != null)
            {
                handler(this, e);
            }

        }
        private void btnUpdateAddon_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter();               
            if (!string.IsNullOrEmpty(tbAddonName.Text) && !string.IsNullOrEmpty(tbAddonUrl.Text) && !tbAddonUrl.Equals("Addon Url") && !tbAddonName.Equals("Addon Name"))
            {
                List<string> addons = new List<string>();
                if (File.Exists("addonInfo.ini"))
                {

                    StreamReader sr = new StreamReader("addonInfo.ini");
                    
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {

                        dynamic dy = JsonConvert.DeserializeObject(line);
                        if (dy.AddonName != null)
                        {
                            if (dy.AddonName != tbAddonName.Text)
                            {
                                addons.Add(line);
                            }
                        }
                    }
                    sr.Close();
                }

                addons.Add("{\"AddonName\" : \"" + tbAddonName.Text + "\" , \"AddonUrl\" : \"" + tbAddonUrl.Text + "\" }");
                File.Delete("addonInfo.ini");
                foreach (var item in addons)
                {
                    StreamWriter sw = new StreamWriter("addonInfo.ini", true);
                    sw.WriteLine(item);
                    sw.Close();
                }
                this.btnUpdateAddon.Text = "Update";
                this.Name = tbAddonName.Text;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter();               
            if (!string.IsNullOrEmpty(tbAddonName.Text) && !string.IsNullOrEmpty(tbAddonUrl.Text) && !tbAddonUrl.Equals("Addon Url") && !tbAddonName.Equals("Addon Name"))
            {
                List<string> addons = new List<string>();
                if (File.Exists("addonInfo.ini"))
                {

                    StreamReader sr = new StreamReader("addonInfo.ini");

                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {

                        dynamic dy = JsonConvert.DeserializeObject(line);
                        if (dy.AddonName != null)
                        {
                            if (dy.AddonName != tbAddonName.Text)
                            {
                                addons.Add(line);
                            }
                        }
                    }
                    sr.Close();
                }

                File.Delete("addonInfo.ini");
                foreach (var item in addons)
                {
                    StreamWriter sw = new StreamWriter("addonInfo.ini", true);
                    sw.WriteLine(item);
                    sw.Close();
                }

            }

            if (this.LabelsTextChanged != null)
            {
                this.LabelsTextChanged(this, e);
            }
        }
    }
}
