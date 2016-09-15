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
        //StreamWriter sw = new StreamWriter("addonInfo.ini", true);
        public AddOn()
        {
            InitializeComponent();
        }

        private void btnUpdateAddon_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter();               
            if (!string.IsNullOrEmpty(tbAddonName.Text) && string.IsNullOrEmpty(tbAddonUrl.Text))
            {
                StreamReader sr = new StreamReader("addonInfo.ini");
                List<string> addons = new List<string>();
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
                addons.Add("{AddonName = \"" + tbAddonName.Text + "\" AddonUrl = \"" + tbAddonUrl.Text + "\" }");
            }
        }
    }
}
