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
    public partial class search_cat_file : Form
    {
        public search_cat_file()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("User.xml");
            Search search = new Search(doc);
            search.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            customemessage c;

            catlist.Items.Clear();
            
            if(filename.Text.Trim() == "")
            {
                c = new customemessage("Empty Field!!");
                c.ShowDialog();
                return;
            }
            string name = filename.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load("User.xml");
            XmlNodeList list = doc.GetElementsByTagName("File");
            string s = "";
            bool check = false;
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList child = list[i].ChildNodes;
                if (child[0].InnerText == name)
                {
                    check = true;
                    for (int j = 0; j < child.Count - 2; j++)
                    {
                        s += child[j + 2].InnerText + ",";

                    }
                    s = s.Remove(s.Length - 1, 1);

                }

            }
            if (!check)
            {
                c = new customemessage("File not Found!!");
                c.ShowDialog();
            }
            string[] word = s.Split(',');

            for (int i = 0; i < word.Length; i++)
            {
                catlist.Items.Add(word[i]);
            }
        }
    }
}
