using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowAddonUpdater
{
    public partial class Form1 : Form
    {
        public int locationY = 0;
        public int lastAddedControlLocation = 0;
        public Form1()
        {
            InitializeComponent();

            loadAddons();

            if (cbUpdateOnStart.Checked)
            {
                new Thread(delegate()
                {
                    updateAddon();
                }).Start();
            }
        }

        public void loadAddons()
        {
            List<string> settings = new List<string>();
            if (File.Exists("settings.ini"))
            {
                StreamReader sr = new StreamReader("settings.ini");
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    settings.Add(line);


                }
                sr.Close();

                foreach (var item in settings)
                {
                    dynamic dy = JsonConvert.DeserializeObject(item);
                    string isUpdateString = dy.UpdateOnStartup;
                    cbUpdateOnStart.Checked = Convert.ToBoolean(isUpdateString);
                }
            }

            panel1.Controls.Clear();
            locationY = 0;
            List<string> addons = new List<string>();
            if (File.Exists("addonInfo.ini"))
            {

                StreamReader sr = new StreamReader("addonInfo.ini");

                string line = "";

                while ((line = sr.ReadLine()) != null)
                {



                    addons.Add(line);


                }
                sr.Close();
            }
            foreach (var item in addons)
            {
                AddOn add1 = new AddOn();
                add1.Location = new Point(0, locationY);
                dynamic dy = JsonConvert.DeserializeObject(item);
                add1.tbAddonName.Text = dy.AddonName;
                add1.tbAddonUrl.Text = dy.AddonUrl;
                add1.btnUpdateAddon.Text = "Update";
                panel1.Controls.Add(add1);
                locationY = add1.Location.Y + 55;
                add1.LabelsTextChanged += add1_LabelsTextChanged;
                add1.updateName();
            }
        }

        void add1_LabelsTextChanged(object sender, EventArgs e)
        {
            loadAddons();
        }

        //void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    loadAddons();
        //}

        private void updateAddon()
        {

            List<string> addons = new List<string>();
            if (File.Exists("addonInfo.ini"))
            {

                StreamReader sr = new StreamReader("addonInfo.ini");

                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    addons.Add(line);
                }
                sr.Close();
            }
            foreach (var item in addons)
            {
                try
                {


                    dynamic dy = JsonConvert.DeserializeObject(item);


                    var res = panel1.Controls.Find((string)dy.AddonName, true);
                    var con = (AddOn)res[0];
                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.Updating;

                    string url = dy.AddonUrl;
                    if (url.Contains("wowace"))
                    {


                        string addonSiteUrl = url;//"https://www.wowace.com/addons/shadowed-unit-frames/"; //"https://mods.curse.com/addons/wow/shadowed-unit-frames";
                        string addonSiteText = GetWebText(addonSiteUrl);
                        string linkText = addonSiteText.Substring(addonSiteText.IndexOf("Recent files"), 400);
                        linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + 9);
                        string temp = linkText.Substring(0, linkText.IndexOf(">") - linkText.IndexOf("<a href=\"") - 2);
                        //user-action-download
                        addonSiteText = GetWebText("https://www.wowace.com" + temp);
                        linkText = addonSiteText.Substring(addonSiteText.IndexOf("user-action-download"), 400);
                        temp = linkText.Substring(linkText.IndexOf("<a href=\"") + 9, linkText.IndexOf(">Download") - linkText.IndexOf("<a href=\"") - 10);
                        string fileName = temp.Split('/')[temp.Split('/').Length - 1];

                        using (var client = new WebClient())
                        {

                            if (string.IsNullOrEmpty(tbSelectedFolder.Text))
                            {
                                if (!File.Exists(Directory.GetCurrentDirectory() + "\\" + fileName))
                                {
                                    client.DownloadFile(temp, Directory.GetCurrentDirectory() + "\\" + fileName);

                                    //mark as downloaded
                                }
                                else
                                {// old file, dont update

                                }
                                con.pbStatus.Image = WowAddonUpdater.Properties.Resources.tick_64;
                            }
                            else
                            {

                            }
                            client.DownloadFile(temp, tbSelectedFolder.Text + "\\" + fileName);
                        }
                    }
                    else if (url.Contains(""))
                    {
                        string addonSiteUrl = url;//"https://wow.curseforge.com/addons/big-wigs/"; //"https://mods.curse.com/addons/wow/shadowed-unit-frames";
                        string addonSiteText = GetWebText(addonSiteUrl);
                        string linkText = addonSiteText.Substring(addonSiteText.IndexOf("Recent files"), 400);
                        linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + 9);
                        string temp = linkText.Substring(0, linkText.IndexOf(">") - linkText.IndexOf("<a href=\"") - 2);
                        addonSiteText = GetWebText("https://wow.curseforge.com" + temp);
                        linkText = addonSiteText.Substring(addonSiteText.IndexOf("<dt>Filename</dt>"), 400);
                        linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + "<a href=\"".Length);
                        temp = linkText.Substring(0, linkText.IndexOf(">") - linkText.IndexOf("<a href=\"") - 2);
                        string fileName = temp.Split('/')[temp.Split('/').Length - 1];

                        using (var client = new WebClient())
                        {

                            if (string.IsNullOrEmpty(tbSelectedFolder.Text))
                            {

                                client.DownloadFile(temp, Directory.GetCurrentDirectory() + "\\" + fileName);
                            }
                            else
                            {

                            }
                            con.pbStatus.Image = WowAddonUpdater.Properties.Resources.tick_64;
                            client.DownloadFile(temp, tbSelectedFolder.Text + "\\" + fileName);
                        }

                    }
                }
                catch (Exception ex)
                {
                    try
                    {

                    
                    dynamic dy = JsonConvert.DeserializeObject(item);
                    var res = panel1.Controls.Find((string)dy.AddonName, true);
                    var con = (AddOn)res[0];
                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.sign_warning_icon;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new Thread(delegate()
            {
                updateAddon();
            }).Start();

        }

        private static string GetWebText(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.162 Safari/535.19";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string htmlText = reader.ReadToEnd();
            return htmlText;
        }





        private void tbSelectedFolder_Enter(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbSelectedFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnAddAddon_Click(object sender, EventArgs e)
        {
            int tempValue = panel1.VerticalScroll.Value;
            panel1.VerticalScroll.Value = 0;

            AddOn add1 = new AddOn();
            add1.Location = new Point(0, locationY);
            add1.btnUpdateAddon.Text = "Add";
            panel1.Controls.Add(add1);


            locationY = (panel1.Controls.Count * 55);
            panel1.VerticalScroll.Value = tempValue;
            add1.LabelsTextChanged += add1_LabelsTextChanged;
            add1.updateName();
        }

        private void cbUpdateOnStart_CheckedChanged(object sender, EventArgs e)
        {
            //UpdateOnStartup
            string setting = ("{\"UpdateOnStartup\" : \"" + cbUpdateOnStart.Checked + "\"  }");
            File.Delete("settings.ini");

            StreamWriter sw = new StreamWriter("settings.ini", true);
            sw.WriteLine(setting);
            sw.Close();
        }


    }
}
