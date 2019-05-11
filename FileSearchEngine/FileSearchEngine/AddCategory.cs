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
    public partial class AddCategory : Form
    {
     
        public AddCategory()
        {
            InitializeComponent();
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            customemessage x , c,p;
            if (catname.Text.Trim()=="" || keywords.Text.Trim() == "")
            {
               c = new customemessage("Empty Field!!");
                c.ShowDialog();
                return;
            }

            

            string name = catname.Text.Trim();
            string[] a = new string[keywords.Lines.Length];
            for (int i = 0; i < keywords.Lines.Length; i++)
                a[i] = keywords.Lines[i].ToString();

            
            if (!File.Exists("Categories.xml"))
            {
                XmlWriter wr = XmlWriter.Create("Categories.xml");
                wr.WriteStartDocument();

                wr.WriteStartElement("Table");

                wr.WriteStartElement("Categories");



                wr.WriteStartElement("Name");
                wr.WriteString(name);
                wr.WriteEndElement();


                for (int i = 0; i < keywords.Lines.Length; i++)
                {
                    if (a[i].Trim() == "") continue;
                    wr.WriteStartElement("Keywords");
                    wr.WriteString(a[i]);
                    wr.WriteEndElement();
                }
                wr.WriteEndElement();
                wr.WriteEndElement();



                wr.WriteEndDocument();
                wr.Close();
                
            }
            else
            {
                XmlDocument doc0 = new XmlDocument();
                doc0.Load("Categories.xml");
                XmlNodeList list = doc0.GetElementsByTagName("Categories");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList child0 = list[i].ChildNodes;
                    if (catname.Text.Trim() == child0[0].InnerText)
                    {
                        p = new customemessage("Category Is Exist ");
                        p.Show();
                        return;
                    }
                }

                XmlDocument doc = new XmlDocument();
                XmlElement cate = doc.CreateElement("Categories");

                XmlElement node = doc.CreateElement("Name");
                node.InnerText = name;
                cate.AppendChild(node);



                for (int i = 0; i < keywords.Lines.Length; i++)
                {
                    if (a[i].Trim() == "") continue;
                    node = doc.CreateElement("Keywords");
                    node.InnerText = a[i];
                    cate.AppendChild(node);
                }

                doc.Load("Categories.xml");
                XmlElement root = doc.DocumentElement;
                root.AppendChild(cate);

                doc.Save("Categories.xml");
                
            }


            x = new customemessage("Category Added Successfully!");
            x.ShowDialog();

            keywords.Clear();
            catname.Text = "";
            catname.Focus();

        }

        private void back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
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
    }
}
