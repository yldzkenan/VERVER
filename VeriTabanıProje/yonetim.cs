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
    public partial class yonetim : Form
    {
        public yonetim()
        {
            InitializeComponent();
        }

        private void yonetim_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            yoneticimaaszam ymz = new yoneticimaaszam();
            this.Hide();
            ymz.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            yoneticimaasveri ymv = new yoneticimaasveri();
            this.Hide();
            ymv.Show();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            ikPersonelislem ikper = new ikPersonelislem();
            ikper.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ikDepartmanislem ikdep = new ikDepartmanislem();
            ikdep.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            kmc baslangic = new kmc();
            this.Hide();
            baslangic.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
