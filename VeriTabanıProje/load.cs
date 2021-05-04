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
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }
        
        private void load_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayac == 100)
            {
                timer1.Stop();
                MessageBox.Show("Süreniz Doldu !", "BİTTİ !", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                this.Close();
                Application.Exit();
               
            }
            cubuk.Value = sayac;
            sayac++;


        }
    }
}   
