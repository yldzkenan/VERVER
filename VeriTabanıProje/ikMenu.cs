﻿using System;
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
    public partial class ikMenu : Form
    {
        public ikMenu()
        {
            InitializeComponent();
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

        private void btnGeri_Click(object sender, EventArgs e)
        {
           
            kmc giris = new kmc();
            giris.Show(); this.Hide();
        }

        private void ikMenu_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            kmc kmc = new kmc();
            kmc.Show();
            this.Hide();
        }
    }
}
