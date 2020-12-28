using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Media;

namespace KBC_Game
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SoundPlayer j = new SoundPlayer(@Application.StartupPath + @"\Data\Music\begin.wav");




        private void button1_Click(object sender, EventArgs e)
        {
            j.Stop();
            j = new SoundPlayer(@Application.StartupPath + @"\Data\Music\BEGIN1.wav");
            j.Play();
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();

            this.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            j.Play();

        }
    }
}
