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
                    updateAddon(tbSelectedFolder.Text);
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
                    if (item.Contains("UpdateOnStartup"))
                    {
                        string isUpdateString = dy.UpdateOnStartup;
                        cbUpdateOnStart.Checked = Convert.ToBoolean(isUpdateString);
                    }
                    if (item.Contains("ZipFileLocation"))
                    {
                        tbSelectedFolder.Text = ((string)dy.ZipFileLocation).Replace('/', '\\');
                    }
                    if (item.Contains("CloseWhenDone"))
                    {
                        string isCloseWhenDone = dy.CloseWhenDone;
                        cbCloseOnFinish.Checked = Convert.ToBoolean(isCloseWhenDone);
                    }

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
                locationY = add1.Location.Y + 65;
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

        private void updateAddon(string selectedFolder)
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
                    //con.lblStatus.Text = "Updating addon";
                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Updating addon"));
                    string url = dy.AddonUrl;
                    if (url.Contains("wowace"))
                    {


                        //string addonSiteUrl = url;//"https://www.wowace.com/addons/shadowed-unit-frames/"; //"https://mods.curse.com/addons/wow/shadowed-unit-frames";
                        //string addonSiteText = GetWebText(addonSiteUrl);
                        //string linkText = addonSiteText.Substring(addonSiteText.IndexOf("Recent files"), 400);
                        //linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + 9);
                        //string temp = linkText.Substring(0, linkText.IndexOf(">") - 2);
                        ////user-action-download
                        //addonSiteText = GetWebText("https://www.wowace.com" + temp);
                        //linkText = addonSiteText.Substring(addonSiteText.IndexOf("user-action-download"), 400);
                        //temp = linkText.Substring(linkText.IndexOf("<a href=\"") + 9, linkText.IndexOf(">Download") - linkText.IndexOf("<a href=\"") - 10);
                        //string fileName = temp.Split('/')[temp.Split('/').Length - 1];

                        string addonSiteUrl = url;//"https://www.wowace.com/addons/shadowed-unit-frames/"; //"https://mods.curse.com/addons/wow/shadowed-unit-frames";
                        string addonSiteText = GetWebText(addonSiteUrl + "/files");
                        string linkText = addonSiteText.Substring(addonSiteText.ToLower().IndexOf("project-file-download-button"), addonSiteText.Length - 10 - addonSiteText.ToLower().IndexOf("project-file-download-button"));
                        linkText = linkText.Substring(linkText.IndexOf("href=\"") + 6);
                        string temp = linkText.Substring(0, linkText.IndexOf("\" title"));
                        string fileName = temp.Remove(0, "/projects/".Length).Split('/')[0];
                        temp = "https://www.wowace.com" + temp;
                        //linkText = addonSiteText.Substring(addonSiteText.IndexOf("<dt>Filename</dt>"), 400);
                        // linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + "<a href=\"".Length);
                        //temp = linkText.Substring(0, linkText.IndexOf(">") - linkText.IndexOf("<a href=\"") - 2);
                        //\"overflow-tip\" href=\"
                        string version = addonSiteText.Substring(addonSiteText.ToLower().IndexOf("\"overflow-tip\" href=\""), addonSiteText.Length - 10 - addonSiteText.ToLower().IndexOf("\"overflow-tip\" href=\""));
                        version = version.Substring(version.IndexOf(">"), 100);
                        version = version.Substring(0, version.IndexOf("<"));
                        version = version.Replace('>', '-');
                        version += ".zip";
                        fileName += version;

                        using (var client = new WebClient())
                        {

                            if (string.IsNullOrEmpty(selectedFolder))
                            {
                                con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Download folder was not found using exe folder"));
                                if (!File.Exists(Directory.GetCurrentDirectory() + "\\" + fileName))
                                {
                                    string oldFileName = fileName.Split('-')[0];
                                    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), oldFileName + "*");
                                    if (files.Length > 0)
                                    {// found old file, move to old file dir
                                        if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\old"))
                                        {
                                            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\old");
                                        }
                                        foreach (var singleFile in files)
                                        {
                                            File.Move(singleFile, Directory.GetCurrentDirectory() + "\\old\\" + Path.GetFileName(singleFile));
                                        }


                                    }
                                    else
                                    {
                                        oldFileName = fileName.Split('_')[0];
                                        files = Directory.GetFiles(Directory.GetCurrentDirectory(), oldFileName + "*");
                                        if (files.Length > 0)
                                        {// found old file, move to old file dir
                                            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\old"))
                                            {
                                                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\old");
                                            }
                                            foreach (var singleFile in files)
                                            {
                                                File.Move(singleFile, Directory.GetCurrentDirectory() + "\\old\\" + Path.GetFileName(singleFile));
                                            }

                                        }
                                    }

                                    client.DownloadFile(temp, Directory.GetCurrentDirectory() + "\\" + fileName);

                                    //mark as downloaded
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Downloaded new file : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.tick_64;
                                }
                                else
                                {// old file, dont update
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Current file is up to date : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.icon_like;
                                }
                            }
                            else
                            {
                                con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Downloading  : " + selectedFolder + "\\" + fileName));

                                if (!File.Exists(selectedFolder + "\\" + fileName))
                                {

                                    string oldFileName = fileName.Split('-')[0];
                                    string[] files = Directory.GetFiles(selectedFolder, oldFileName + "*");
                                    if (files.Length > 0)
                                    {// found old file, move to old file dir
                                        if (!Directory.Exists(selectedFolder + "\\old"))
                                        {
                                            Directory.CreateDirectory(selectedFolder + "\\old");
                                        }
                                        foreach (var singleFile in files)
                                        {
                                            File.Move(singleFile, selectedFolder + "\\old\\" + Path.GetFileName(singleFile));
                                        }

                                    }
                                    else
                                    {
                                        oldFileName = fileName.Split('_')[0];
                                        files = Directory.GetFiles(selectedFolder, oldFileName + "*");
                                        if (files.Length > 0)
                                        {// found old file, move to old file dir
                                            if (!Directory.Exists(selectedFolder + "\\old"))
                                            {
                                                Directory.CreateDirectory(selectedFolder + "\\old");
                                            }
                                            foreach (var singleFile in files)
                                            {
                                                File.Move(singleFile, selectedFolder + "\\old\\" + Path.GetFileName(singleFile));
                                            }

                                        }
                                    }

                                    client.DownloadFile(temp, selectedFolder + "\\" + fileName);

                                    //mark as downloaded
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Downloaded new file : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.tick_64;
                                }
                                else
                                {// old file, dont update
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Current file is up to date : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.icon_like;
                                }

                            }

                        }
                    }
                    else if (url.Contains(""))
                    {
                        string addonSiteUrl = url;//"https://wow.curseforge.com/addons/big-wigs/"; //"https://mods.curse.com/addons/wow/shadowed-unit-frames";
                        string addonSiteText = GetWebText(addonSiteUrl + "/files");
                        string linkText = addonSiteText.Substring(addonSiteText.ToLower().IndexOf("project-file-download-button"), addonSiteText.Length - 10 - addonSiteText.ToLower().IndexOf("project-file-download-button"));
                        linkText = linkText.Substring(linkText.IndexOf("href=\"") + 6);
                        string temp = linkText.Substring(0, linkText.IndexOf("\" title"));
                        string fileName = temp.Remove(0, "/projects/".Length).Split('/')[0];
                        temp = "https://wow.curseforge.com" + temp;
                        //linkText = addonSiteText.Substring(addonSiteText.IndexOf("<dt>Filename</dt>"), 400);
                       // linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + "<a href=\"".Length);
                        //temp = linkText.Substring(0, linkText.IndexOf(">") - linkText.IndexOf("<a href=\"") - 2);
                        //\"overflow-tip\" href=\"
                        string version = addonSiteText.Substring(addonSiteText.ToLower().IndexOf("\"overflow-tip\" href=\""), addonSiteText.Length - 10 - addonSiteText.ToLower().IndexOf("\"overflow-tip\" href=\""));
                        version = version.Substring(version.IndexOf(">"), 100);
                        version = version.Substring(0, version.IndexOf("<"));
                        version = version.Replace('>', '-');
                        version += ".zip";
                        fileName += version;
                        using (var client = new WebClient())
                        {

                            if (string.IsNullOrEmpty(selectedFolder))
                            {
                                

                                con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Download folder was not found using exe folder"));
                                if (!File.Exists(Directory.GetCurrentDirectory() + "\\" + fileName))
                                {
                                    string oldFileName = fileName.Split('-')[0];
                                    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), oldFileName + "*");
                                    if (files.Length > 0)
                                    {// found old file, move to old file dir
                                        if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\old"))
                                        {
                                            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\old");
                                        }
                                        foreach (var singleFile in files)
                                        {
                                            File.Move(singleFile, Directory.GetCurrentDirectory() + "\\old\\" + Path.GetFileName(singleFile));
                                        }


                                    }
                                    else
                                    {
                                        oldFileName = fileName.Split('_')[0];
                                        files = Directory.GetFiles(Directory.GetCurrentDirectory(), oldFileName + "*");
                                        if (files.Length > 0)
                                        {// found old file, move to old file dir
                                            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\old"))
                                            {
                                                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\old");
                                            }
                                            foreach (var singleFile in files)
                                            {
                                                File.Move(singleFile, Directory.GetCurrentDirectory() + "\\old\\" + Path.GetFileName(singleFile));
                                            }

                                        }
                                    }

                                    client.DownloadFile(temp, Directory.GetCurrentDirectory() + "\\" + fileName);
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Downloaded new file : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.tick_64;
                                }
                                else
                                {
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Current file is up to date : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.icon_like;
                                }
                            }
                            else
                            {
                                con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Downloading  : " + selectedFolder + "\\" + fileName));
                                if (!File.Exists(selectedFolder + "\\" + fileName))
                                {
                                    string oldFileName = fileName.Split('-')[0];
                                    string[] files = Directory.GetFiles(selectedFolder, oldFileName + "*");
                                    if (files.Length > 0)
                                    {// found old file, move to old file dir
                                        if (!Directory.Exists(selectedFolder + "\\old"))
                                        {
                                            Directory.CreateDirectory(selectedFolder + "\\old");
                                        }
                                        foreach (var singleFile in files)
                                        {
                                            File.Move(singleFile, selectedFolder + "\\old\\" + Path.GetFileName(singleFile));
                                        }

                                    }
                                    else
                                    {
                                        oldFileName = fileName.Split('_')[0];
                                        files = Directory.GetFiles(selectedFolder, oldFileName + "*");
                                        if (files.Length > 0)
                                        {// found old file, move to old file dir
                                            if (!Directory.Exists(selectedFolder + "\\old"))
                                            {
                                                Directory.CreateDirectory(selectedFolder + "\\old");
                                            }
                                            foreach (var singleFile in files)
                                            {
                                                File.Move(singleFile, selectedFolder + "\\old\\" + Path.GetFileName(singleFile));
                                            }

                                        }
                                    }
                                    client.DownloadFile(temp, selectedFolder + "\\" + fileName);

                                    //mark as downloaded
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Downloaded new file : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.tick_64;
                                }
                                else
                                {// old file, dont update
                                    con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Current file is up to date : " + fileName));
                                    con.pbStatus.Image = WowAddonUpdater.Properties.Resources.icon_like;
                                }

                            }

                            //client.DownloadFile(temp, selectedFolder + "\\" + fileName);
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
                        con.lblStatus.Invoke((Action)(() => con.lblStatus.Text = "Error downloading : " + ex.Message));
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            if (cbCloseOnFinish.Checked)
            {
                Application.Exit();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new Thread(delegate()
            {
                updateAddon(tbSelectedFolder.Text);
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



        private void updateSaveDir()
        {
            List<string> settings = new List<string>();
            if (File.Exists("settings.ini"))
            {
                StreamReader sr = new StreamReader("settings.ini");
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("ZipFileLocation"))
                    {
                        settings.Add(line);
                    }


                }
                sr.Close();


            }

            settings.Add("{\"ZipFileLocation\" : \"" + Path.GetFullPath(tbSelectedFolder.Text).Replace('\\', '/') + "\"  }");
            File.Delete("settings.ini");
            foreach (var item in settings)
            {
                StreamWriter sw = new StreamWriter("settings.ini", true);
                sw.WriteLine(item);
                sw.Close();
            }
        }

        private void tbSelectedFolder_Enter(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbSelectedFolder.Text = folderBrowserDialog1.SelectedPath;
                updateSaveDir();

            }
        }

        private void btnAddAddon_Click(object sender, EventArgs e)
        {
            int tempValue = panel1.VerticalScroll.Value;
            panel1.VerticalScroll.Value = 0;

            AddOn add1 = new AddOn();
            add1.Location = new Point(0, locationY);
            add1.btnUpdateAddon.Text = "Add";
            add1.lblStatus.Text = "Please enter an addon name and addon url";
            panel1.Controls.Add(add1);


            locationY = (panel1.Controls.Count * 65);
            panel1.VerticalScroll.Value = tempValue;
            add1.LabelsTextChanged += add1_LabelsTextChanged;
            add1.updateName();
        }

        private void cbUpdateOnStart_CheckedChanged(object sender, EventArgs e)
        {
            List<string> settings = new List<string>();
            if (File.Exists("settings.ini"))
            {
                StreamReader sr = new StreamReader("settings.ini");
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("UpdateOnStartup"))
                    {
                        settings.Add(line);
                    }


                }
                sr.Close();


            }

            settings.Add("{\"UpdateOnStartup\" : \"" + cbUpdateOnStart.Checked + "\"  }");
            File.Delete("settings.ini");
            foreach (var item in settings)
            {
                StreamWriter sw = new StreamWriter("settings.ini", true);
                sw.WriteLine(item);
                sw.Close();
            }

        }

        private void tbSelectedFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSelectedFolder_Leave(object sender, EventArgs e)
        {
            updateSaveDir();
        }

        private void cbCloseOnFinish_CheckedChanged(object sender, EventArgs e)
        {
            List<string> settings = new List<string>();
            if (File.Exists("settings.ini"))
            {
                StreamReader sr = new StreamReader("settings.ini");
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("CloseWhenDone"))
                    {
                        settings.Add(line);
                    }


                }
                sr.Close();


            }

            settings.Add("{\"CloseWhenDone\" : \"" + cbCloseOnFinish.Checked + "\"  }");
            File.Delete("settings.ini");
            foreach (var item in settings)
            {
                StreamWriter sw = new StreamWriter("settings.ini", true);
                sw.WriteLine(item);
                sw.Close();
            }
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.Image = WowAddonUpdater.Properties.Resources.updatePressed;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.Image = WowAddonUpdater.Properties.Resources.Update;
        }

        private void btnAddAddon_MouseEnter(object sender, EventArgs e)
        {
            btnAddAddon.Image = WowAddonUpdater.Properties.Resources.addPressed;
        }

        private void btnAddAddon_MouseLeave(object sender, EventArgs e)
        {
            btnAddAddon.Image = WowAddonUpdater.Properties.Resources.add;
        }


    }
}
