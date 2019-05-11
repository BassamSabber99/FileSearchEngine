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
    public partial class key_exist : Form
    {
        public key_exist(string[] arr)
        {
            InitializeComponent();
            for(int i = 0; i < arr.Length; i++)
            {
                category.Items.Add(arr[i]);
            }
            
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

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

            string val = category.SelectedItem.ToString();
            // MessageBox.Show(val);
            XmlDocument doc1 = new XmlDocument();
            doc1.Load("Categories.xml");
            XmlNodeList nl = doc1.GetElementsByTagName("Categories");
            string[] data;
            for (int i = 0; i < nl.Count; i++)
            {
                XmlNodeList child = nl[i].ChildNodes;
                if (child[0].InnerText.ToString() == val)
                {
                    data = new string[child.Count - 1];
                    for (int j = 0; j < child.Count - 1; j++)
                    {
                        data[j] = child[j + 1].InnerText.ToString();
                    }
                    break;
                }
            }


            dgvk.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("HistoryLog.xml");
            XmlNodeList nl2 = doc.GetElementsByTagName("Log");
            for(int i = 0; i < nl2.Count; i++)
            {
                XmlNodeList child2 = nl2[i].ChildNodes;
                //for(int j = 0; j < child2.Count; j++)
                //{
                    if(child2[0].InnerText.ToString() == val)
                    {

                        string filename = child2[2].Name;
                        string fnval = child2[2].InnerText.ToString();

                        string keyname = child2[1].Name;
                        string kval = child2[1].InnerText.ToString();

                        string linenum = child2[3].Name;
                        string linenumber ="";
                        for(int k = 3;k < child2.Count-1; k++)
                        {
                            linenumber += child2[k].InnerText.ToString()+',';
                        }
                        linenumber = linenumber.Remove(linenumber.Length - 1, 1);
                        string counter = child2[child2.Count - 1].Name;
                        string countval = child2[child2.Count - 1].InnerText.ToString();

                        if(dgvk.ColumnCount == 0)
                        {
                            dgvk.Columns.Add("keyname", keyname);
                            dgvk.Columns.Add("filename", filename);
                            dgvk.Columns.Add("counter", counter);
                            dgvk.Columns.Add("linenumber", linenum);
                            
                        }
                        dgvk.Rows.Add(new string[] { kval, fnval, countval , linenumber });

                    }
                }
            //}
            
        }

        private void dgvk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
