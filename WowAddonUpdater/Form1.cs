using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowAddonUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string url = "";
            if (url.Contains("wowace"))
            {


                string addonSiteUrl = "https://www.wowace.com/addons/shadowed-unit-frames/"; //"https://mods.curse.com/addons/wow/shadowed-unit-frames";
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
                    client.DownloadFile(temp, tbSelectedFolder.Text + "\\" + fileName);
                }
            }
            else if(url.Contains(""))
            {
                string addonSiteUrl = "https://wow.curseforge.com/addons/big-wigs/"; //"https://mods.curse.com/addons/wow/shadowed-unit-frames";
                string addonSiteText = GetWebText(addonSiteUrl);
                string linkText = addonSiteText.Substring(addonSiteText.IndexOf("Recent files"), 400);
                linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + 9);
                string temp = linkText.Substring(0, linkText.IndexOf(">") - linkText.IndexOf("<a href=\"") - 2);
                addonSiteText = GetWebText("https://wow.curseforge.com" + temp);
                linkText = addonSiteText.Substring(addonSiteText.IndexOf("<dt>Filename</dt>"), 400);
                linkText = linkText.Substring(linkText.IndexOf("<a href=\"") + "<dt>Filename</dt>".Length);
                temp = linkText.Substring(0, linkText.IndexOf(">") - linkText.IndexOf("<a href=\"") - 2);
                string fileName = temp.Split('/')[temp.Split('/').Length - 1];

                using (var client = new WebClient())
                {
                    client.DownloadFile(temp, tbSelectedFolder.Text + "\\" + fileName);
                }

            }
           
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
            AddOn add1 = new AddOn();
            panel1.Controls.Add(add1);
        }
    }
}
