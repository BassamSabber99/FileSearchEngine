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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Addfile_Click(object sender, EventArgs e)
        {
            
            XmlDocument doc = new XmlDocument();
            if (File.Exists("Categories.xml"))
            {
                doc.Load("Categories.xml");
                XmlNodeList nl = doc.GetElementsByTagName("Categories");
                string[] arr = new string[nl.Count];

                for (int i = 0; i < nl.Count; i++)
                {
                    XmlNodeList child = nl[i].ChildNodes;
                    arr[i] = child[0].InnerText;
                }
                AddFile add = new AddFile(arr);
                add.Show();
                this.Hide();
            }
            
        }

        private void AddCat_Click(object sender, EventArgs e)
        {
            AddCategory addcat = new AddCategory();
            addcat.Show();
            this.Hide();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("User.xml");
            Search search = new Search(doc);
            search.Show();
            this.Hide();
        }
    }
}
