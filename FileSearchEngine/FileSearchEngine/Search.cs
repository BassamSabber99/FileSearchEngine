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
    public partial class Search : Form
    {
        public Search(XmlDocument d)
        {
            InitializeComponent();
            dgv.Rows.Clear();
            XmlNodeList list = d.GetElementsByTagName("File");
            if (list.Count == 0)
            {
                MessageBox.Show("NO DATA TO SHOW");
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList child = list[i].ChildNodes;

                string filename = child[0].Name;
                string nval = child[0].InnerText;

                string path = child[1].Name;
                string pval = child[1].InnerText;

                string cat = child[2].Name;
                int count = 2;
                string cval = "";
                for (int c = 0; c < child.Count - 2; c++)
                {

                    cval += child[count].InnerText + ",";
                    count++;
                }
                cval = cval.Remove(cval.Length - 1, 1);



                if (dgv.ColumnCount == 0)
                {

                    dgv.Columns.Add("filename", filename);
                    dgv.Columns.Add("path", path);
                    dgv.Columns.Add("catname", cat);
                }

                dgv.Rows.Add(new string[] { nval, pval, cval });

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void Addfile_Click(object sender, EventArgs e)
        {
            search_cat_file search = new search_cat_file();
            search.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            search_key_cat search = new search_key_cat();
            search.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

            string[] arr;
            XmlDocument doc = new XmlDocument();
            doc.Load("Categories.xml");
            XmlNodeList nl = doc.GetElementsByTagName("Categories");
            arr = new string[nl.Count];
            for(int i = 0; i < nl.Count; i++)
            {
                XmlNodeList child = nl[i].ChildNodes;
                arr[i] = child[0].InnerText.ToString();
            } 
            key_exist k = new key_exist(arr);
            k.Show();
            this.Hide();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            highlight h = new highlight();
            this.Hide();
            h.Show();
        }
    }
}
