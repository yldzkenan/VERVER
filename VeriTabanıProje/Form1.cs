using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace VeriTabanıProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void button1_Click(object sender, EventArgs e)

        {
            ceosifre ceosifre = new ceosifre();
            ceosifre.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            müsteri müsteri = new müsteri();
            müsteri.Show();
            this.Hide();
        }

        private void yöneticigiris_Click(object sender, EventArgs e)
        {
            yöneticisifre yöneticisifre = new yöneticisifre();
            yöneticisifre.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "azer.mp3";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            //deneme
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "";
        }
    }
}
