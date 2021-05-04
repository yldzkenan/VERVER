using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıProje
{
    public partial class satışsecim : Form
    {
        public satışsecim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siparis siparis = new siparis();
            siparis.Show();
            this.Hide();
        }

        private void secim_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            yenimüsteri yenimüsteri = new yenimüsteri();
            yenimüsteri.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            kmc kmc = new kmc();
            kmc.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
