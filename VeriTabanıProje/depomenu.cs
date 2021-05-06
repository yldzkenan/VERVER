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
    public partial class depomenu : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public depomenu()
        {
            InitializeComponent();
        }

        private void btnstokdurum_Click(object sender, EventArgs e)
        {
            depostokdurum dsd = new depostokdurum();
            dsd.Show();
        }

        private void buttonKargo_Click(object sender, EventArgs e)
        {
            depogonderim dg = new depogonderim();
            dg.Show();
        }

        private void buttonTeslim_Click(object sender, EventArgs e)
        {
            depogonderimteslim dgt = new depogonderimteslim();
            dgt.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            kmc giris = new kmc();
            this.Hide();
            giris.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void depomenu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void depomenu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void depomenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
            
        }
    }
}
