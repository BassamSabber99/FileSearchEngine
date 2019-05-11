using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace FileSearchEngine
{
    public partial class AddFile : Form
    {
        public AddFile(string[] arr)
        {
            InitializeComponent();
            for (int i = 0; i < arr.Length; i++)
                catname.Items.Add(arr[i]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void filename_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void catname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            customemessage y , c , p;
            if (filename.Text.Trim() == "" || catname.Text.Trim() == "" || content.Text.Trim() == "")
            {
                c = new customemessage("Empty Field!!");
                c.ShowDialog();
                return;
            }

            

            FileStream fs = new FileStream(filename.Text.ToString().Trim() + ".txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string s;
            //sw.Write(content.Text);
            for (int i = 0; i < content.Lines.Length; i++)
            {
                s = content.Lines[i];
                sw.WriteLine(s);
            }
            sw.Close();
            string name = filename.Text;
            string[] arr = new string[catname.CheckedItems.Count];
            for (int j = 0; j < catname.CheckedItems.Count; j++)
            {
                arr[j] = catname.CheckedItems[j].ToString();
            }
            string path = "C:\\"+Environment.UserName.ToString()+"\\Projects\\Files Project\\FileSearchEngine\\FileSearchEngine\\bin\\Debug\\" + filename.Text + ".txt";

            if (arr.Length == 0) {
                customemessage cm = new customemessage("Empty Field!!");
                cm.ShowDialog();
                return;
            }


            if (!File.Exists("User.xml"))
            {
                XmlWriter wr = XmlWriter.Create("User.xml");
                wr.WriteStartDocument();

                wr.WriteStartElement("Table");

                wr.WriteStartElement("File");

                wr.WriteStartElement("FileName");
                wr.WriteString(name);
                wr.WriteEndElement();

                wr.WriteStartElement("Path"); 
                wr.WriteString(path);              
                wr.WriteEndElement();

                for (int x = 0; x < arr.Length; x++)
                {
                    wr.WriteStartElement("CategoryName");
                    wr.WriteString(arr[x]);
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
                doc0.Load("User.xml");
                XmlNodeList list = doc0.GetElementsByTagName("File");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList child0 = list[i].ChildNodes;
                    if (filename.Text.Trim() == child0[0].InnerText)
                    {
                        p = new customemessage("File Name Is Exist ");
                        p.Show();
                        return;
                    }
                }
                XmlDocument doc = new XmlDocument();
                XmlElement cate = doc.CreateElement("File");
                XmlElement node = doc.CreateElement("FileName");

                node.InnerText = name;
                cate.AppendChild(node);

                node = doc.CreateElement("Path");
                node.InnerText = path;
                
                

                cate.AppendChild(node);

                for (int x = 0; x < arr.Length; x++)
                {
                    node = doc.CreateElement("CategoryName");

                    node.InnerText = arr[x];
                    cate.AppendChild(node);
                }


                doc.Load("User.xml");
                XmlElement root = doc.DocumentElement;
                root.AppendChild(cate);

                doc.Save("User.xml");
            }


            XmlDocument doc2 = new XmlDocument();
            doc2.Load("Categories.xml");
            XmlNodeList nl = doc2.GetElementsByTagName("Categories");






            for (int i = 0; i < nl.Count; i++)
            {
                XmlNodeList child = nl[i].ChildNodes;
                bool bolean = false;
                for (int w = 0; w < arr.Length; w++)
                {
                    if (arr[w] == child[0].InnerText.ToString())
                    {
                        bolean = true;
                    }
                }


                //MessageBox.Show(child.Count.ToString());
                for (int x = 1; x < child.Count; x++)
                {
                    if (!bolean) continue;
                    //MessageBox.Show(filename.Text.ToString());
                    string file = filename.Text.ToString() + ".txt";
                    FileStream f = new FileStream(file, FileMode.Open);
                    StreamReader sr = new StreamReader(f);
                    int counter = 0, line = 1;
                    List<int> existingLine = new List<int>();

                    while (sr.Peek() != -1)
                    {

                        string sx = sr.ReadLine();
                        string[] words = sx.Split(' ');
                        bool q = false;
                        //if (sx.Contains(child[x].InnerText.ToString()))
                        for (int w = 0; w < words.Length; w++)
                        {

                            if (words[w] == child[x].InnerText.ToString())
                            {
                                counter++;
                                q = true;

                            }

                        }
                        if (q) existingLine.Add(line);
                        line++;


                    }
                    //MessageBox.Show(counter.ToString() + " ");

                    if (counter > 0)
                    {
                        if (!File.Exists("HistoryLog.xml"))
                        {
                            XmlWriter wr = XmlWriter.Create("HistoryLog.xml");
                            wr.WriteStartDocument();
                            wr.WriteStartElement("Table");
                            wr.WriteStartElement("Log");

                            wr.WriteStartElement("CategoryName");
                            wr.WriteString(child[0].InnerText.ToString());
                            wr.WriteEndElement();

                            wr.WriteStartElement("KeywordName");
                            wr.WriteString(child[x].InnerText.ToString());
                            wr.WriteEndElement();

                            wr.WriteStartElement("FileName");
                            wr.WriteString(filename.Text.ToString());
                            wr.WriteEndElement();

                            for (int q = 0; q < existingLine.Count; q++)
                            {
                                wr.WriteStartElement("LineNumber");
                                wr.WriteString(existingLine[q].ToString());
                                wr.WriteEndElement();
                            }

                            wr.WriteStartElement("Counter");
                            wr.WriteString(counter.ToString());
                            wr.WriteEndElement();

                            wr.WriteEndElement();
                            wr.WriteEndElement();
                            wr.WriteEndDocument();
                            wr.Close();
                        }
                        else
                        {

                            XmlDocument doc = new XmlDocument();
                            XmlElement cate = doc.CreateElement("Log");
                            XmlElement node = doc.CreateElement("CategoryName");

                            node.InnerText = child[0].InnerText.ToString();
                            cate.AppendChild(node);


                            node = doc.CreateElement("KeywordName");
                            node.InnerText = child[x].InnerText.ToString();
                            cate.AppendChild(node);


                            node = doc.CreateElement("FileName");
                            node.InnerText = filename.Text.ToString();
                            cate.AppendChild(node);

                            for (int q = 0; q < existingLine.Count; q++)
                            {
                                node = doc.CreateElement("LineNumber");
                                node.InnerText = existingLine[q].ToString();
                                cate.AppendChild(node);
                            }

                            node = doc.CreateElement("Counter");
                            node.InnerText = counter.ToString();
                            cate.AppendChild(node);


                            doc.Load("HistoryLog.xml");
                            XmlElement root = doc.DocumentElement;
                            root.AppendChild(cate);

                            doc.Save("HistoryLog.xml");
                        
                        }
                    }

                    sr.Close();
                }

            }




            y = new customemessage("File Added Successfully!");
            y.ShowDialog();
            filename.Text = "";
            filename.Focus();
            content.Text = "";
            for(int z = 0;z < catname.Items.Count;z++)
            catname.SetItemChecked(z, false);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
    }
}
