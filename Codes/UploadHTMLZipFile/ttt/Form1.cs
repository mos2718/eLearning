using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShowImages
{
    public partial class Form1 : Form
    {
        int i = 0;
        string[] ImageNames = new string[] { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg", "7.jpg", "8.jpg" };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            i++;
            if (i >= 8) i = 0;
            // images 位於 debug 子目錄中 
            pictureBox1.Image = Image.FromFile(ImageNames[i]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }
    }
}