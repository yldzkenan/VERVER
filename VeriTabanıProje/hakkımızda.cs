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
    public partial class hakkımızda : Form
    {
        public hakkımızda()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
       

        }

        private void hakkımızda_Load(object sender, EventArgs e)
        {
         
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            kmc kmc = new kmc();
            kmc.Show();
            this.Hide();
        }
    }
}
