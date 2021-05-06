using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace VeriTabanıProje
{

    public partial class depostokdurum : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        private bool mouseDown;
        private Point lastLocation;
        public depostokdurum()
        {
            InitializeComponent();
        }
        void Getir()
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select urun_ad as 'Ürün Adı',urun_miktar as 'STOK',urun_aciklama as 'Açıklama' from Urun", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView1.DataSource = dTable;

            DataTable dTable2 = new DataTable();

            SqlDataAdapter dAdapter2 = new SqlDataAdapter("Select hammadde_ad as 'Hammadde Adı',hammadde_miktar as 'STOK',hammadde_aciklama as 'Açıklama' from hammadde ", baglanti);
            {
                dAdapter2.Fill(dTable2);
            }
            dataGridView2.DataSource = dTable2;



        }
        private void depostokdurum_Load(object sender, EventArgs e)
        {
            Getir();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void depostokdurum_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void depostokdurum_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void depostokdurum_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }

        }
    }
}
