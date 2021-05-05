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
    }
}
