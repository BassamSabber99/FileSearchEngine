using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace FileSearchEngine
{
    public partial class highlight : Form
    {
        public highlight()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();

            doc.Load("User.xml");
            XmlNodeList nl = doc.GetElementsByTagName("File");
            string[] catnames = new string[nl.Count];
            for (int i = 0; i < nl.Count; i++)
            {
                XmlNodeList child = nl[i].ChildNodes;
                catnames[i] = child[0].InnerText.ToString();

            }
            for (int i = 0; i < catnames.Length; i++)
                catname.Items.Add(catnames[i]);
        }

        private void back_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("User.xml");
            Search main = new Search(doc);
            main.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void highlight_Load(object sender, EventArgs e)
        {

        }

        private void keywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            content.Clear();
            string value1 = catname.SelectedItem.ToString();
            FileStream fs = new FileStream(value1 + ".txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                content.AppendText(line + '\n');
            }
            sr.Close();
            string value = keywords.SelectedItem.ToString();

            XmlDocument doc = new XmlDocument();

            doc.Load("Categories.xml");
            XmlNodeList nl = doc.GetElementsByTagName("Categories");
            string[] getkeys = null;

            for (int i = 0; i < nl.Count; i++)
            {

                bool done = false;
                XmlNodeList child = nl[i].ChildNodes;
                if (child[0].InnerText.ToString() == value)
                {
                    done = true;
                    getkeys = new string[child.Count - 1];
                    for (int x = 0; x < child.Count - 1; x++)
                        getkeys[x] = child[x + 1].InnerText.ToString();
                    break;
                }
                if (done) break;
            }
            for (int w = 0; w < getkeys.Length; w++)
            {
                int idx = 0;
                while (idx < content.Text.LastIndexOf(getkeys[w]))
                {
                    content.Find(getkeys[w].ToLower(), idx, content.TextLength, RichTextBoxFinds.None);
                    content.SelectionBackColor = Color.Yellow;
                    idx = content.Text.IndexOf(getkeys[w], idx) + 1;
                }
            }
        }

        private void catname_SelectedIndexChanged(object sender, EventArgs e)
        {
            keywords.Items.Clear();
            content.Clear();
            string value = catname.SelectedItem.ToString();

            XmlDocument doc = new XmlDocument();

            doc.Load("User.xml");
            XmlNodeList nl = doc.GetElementsByTagName("File");
            string[] getcats = null;

            for (int i = 0; i < nl.Count; i++)
            {
                bool done = false;
                XmlNodeList child = nl[i].ChildNodes;
                if (child[0].InnerText.ToString() == value)
                {
                    done = true;
                    getcats = new string[child.Count - 2];
                    for (int x = 0; x < child.Count - 2; x++)
                        getcats[x] = child[x + 2].InnerText.ToString();
                    break;
                }
                if (done) break;

            }
            for (int w = 0; w < getcats.Length; w++)
                keywords.Items.Add(getcats[w]);

            FileStream fs = new FileStream(value + ".txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                content.AppendText(line + '\n');
            }
            sr.Close();
        }
    }
}
