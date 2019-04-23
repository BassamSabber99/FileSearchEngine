namespace FileSearchEngine
{
    partial class highlight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(highlight));
            this.back = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.keywords = new System.Windows.Forms.ComboBox();
            this.catname = new System.Windows.Forms.ComboBox();
            this.content = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.ActiveBorderThickness = 1;
            this.back.ActiveCornerRadius = 20;
            this.back.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.back.ActiveForecolor = System.Drawing.Color.Honeydew;
            this.back.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back.BackgroundImage")));
            this.back.ButtonText = "Back";
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Font = new System.Drawing.Font("Broadway", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.IdleBorderThickness = 1;
            this.back.IdleCornerRadius = 20;
            this.back.IdleFillColor = System.Drawing.Color.SeaGreen;
            this.back.IdleForecolor = System.Drawing.Color.White;
            this.back.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.back.Location = new System.Drawing.Point(16, 339);
            this.back.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(144, 35);
            this.back.TabIndex = 27;
            this.back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 39);
            this.panel1.TabIndex = 26;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, -9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 48);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Broadway", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(570, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "ـــ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(608, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 25);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // keywords
            // 
            this.keywords.FormattingEnabled = true;
            this.keywords.Location = new System.Drawing.Point(179, 125);
            this.keywords.Name = "keywords";
            this.keywords.Size = new System.Drawing.Size(174, 21);
            this.keywords.TabIndex = 28;
            this.keywords.SelectedIndexChanged += new System.EventHandler(this.keywords_SelectedIndexChanged);
            // 
            // catname
            // 
            this.catname.FormattingEnabled = true;
            this.catname.Location = new System.Drawing.Point(179, 79);
            this.catname.Name = "catname";
            this.catname.Size = new System.Drawing.Size(174, 21);
            this.catname.TabIndex = 29;
            this.catname.SelectedIndexChanged += new System.EventHandler(this.catname_SelectedIndexChanged);
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.content.Enabled = false;
            this.content.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.content.ForeColor = System.Drawing.Color.SeaGreen;
            this.content.Location = new System.Drawing.Point(83, 169);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(496, 160);
            this.content.TabIndex = 30;
            this.content.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Marker", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SeaGreen;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 31);
            this.label3.TabIndex = 31;
            this.label3.Text = "Files Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Marker", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 31);
            this.label2.TabIndex = 32;
            this.label2.Text = "Categories";
            // 
            // highlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(635, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.content);
            this.Controls.Add(this.catname);
            this.Controls.Add(this.keywords);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "highlight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "highlight";
            this.Load += new System.EventHandler(this.highlight_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox keywords;
        private System.Windows.Forms.ComboBox catname;
        private System.Windows.Forms.RichTextBox content;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}