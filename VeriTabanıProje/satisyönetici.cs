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
using System.Collections;

namespace VeriTabanıProje
{
    public partial class satisyönetici : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public satisyönetici()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            kmc kmc = new kmc();
            kmc.Show();
            this.Hide();
        }

        private void satisyönetici_Load(object sender, EventArgs e)
        {
            DataTable dTableeee = new DataTable();

            SqlDataAdapter dAdapterrrr = new SqlDataAdapter("Select * from Urun", baglanti);
            {
                dAdapterrrr.Fill(dTableeee);
            }
            dataGridView3.DataSource = dTableeee;


            DataTable dTableee = new DataTable();

            SqlDataAdapter dAdapterrr = new SqlDataAdapter("Select * from Musteri", baglanti);
            {
                dAdapterrr.Fill(dTableee);
            }
            dataGridView1.DataSource = dTableee;


            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select * from Adres where adres_id in(select adres_id from Musteri)", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView2.DataSource = dTable;
            DataTable dTablee = new DataTable();

            SqlDataAdapter dAdapterr = new SqlDataAdapter("Select * From Personel where departman_id =1 ",baglanti);
            {
                dAdapterr.Fill(dTablee);
            }
            dataGridView4.DataSource = dTablee;
            

        }
        public DataTable Ara(string ara)
        {
            try
            {
                DataTable tbl = new DataTable();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(ara, baglanti);
                adtr.Fill(tbl);
                dataGridView1.DataSource = tbl;
                baglanti.Close();
                return tbl;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                return null;
            }
        }
        public DataTable Araa(string araa)
        {
            try
            {
                DataTable tbl = new DataTable();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(araa, baglanti);
                adtr.Fill(tbl);
                dataGridView2.DataSource = tbl;
                baglanti.Close();
                return tbl;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                return null;
            }
        }
        public DataTable Araaa(string araaa)
        {
            try
            {
                DataTable tbl = new DataTable();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(araaa, baglanti);
                adtr.Fill(tbl);
                dataGridView3.DataSource = tbl;
                baglanti.Close();
                return tbl;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                return null;
            }
        }
        public DataTable Araaaa(string araaaa)
        {
            try
            {
                DataTable tbl = new DataTable();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(araaaa, baglanti);
                adtr.Fill(tbl);
                dataGridView4.DataSource = tbl;
                baglanti.Close();
                return tbl;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                return null;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Ara("select * from musteri where musteri_adsoyad like '" + textBox1.Text + "%'");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Araa("Select * from Adres where adres_id in(select adres_id from Musteri) and ilce like'" + textBox2.Text + "%'");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Araaaa("select * from personel where departman_id =1 and personel_ad like '" + textBox4.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siparis siparis = new siparis();
            siparis.Show();         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();           
        }
        
       
        private void button3_Click(object sender, EventArgs e)
        {
            yenimüsteri yenimüsteri = new yenimüsteri();
            yenimüsteri.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Araaaa("select * from Urun where urun_ad like '" + textBox4.Text + "%'");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            satismesaj satismesaj = new satismesaj();
            satismesaj.Show();
        }
    }
}
