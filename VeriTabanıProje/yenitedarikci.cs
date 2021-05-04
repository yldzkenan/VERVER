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
    public partial class yenitedarikci : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANPC\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public yenitedarikci()
        {
            InitializeComponent();
        }

        private void yenitedarikci_Load(object sender, EventArgs e)
        {
            DataTable dTablee = new DataTable();

            SqlDataAdapter dAdapterr = new SqlDataAdapter("Select * from Tedarikci", baglanti);
            {
                dAdapterr.Fill(dTablee);
            }
            dataGridView1.DataSource = dTablee;

            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select * from Adres where adres_id in(select adres_id from Tedarikci)", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView2.DataSource = dTable;
            
            baglanti.Open();
            try
            {
                SqlCommand al = new SqlCommand("select max(tedarikci_id) as tedarikci from Tedarikci ", baglanti);
                SqlDataReader oku = al.ExecuteReader();
                if (!oku.HasRows)
                {
                    oku.Close();
                    baglanti.Close();
                }
                else
                {
                    while (oku.Read())
                    {
                        tedarikci_id.Text = (int.Parse(oku["tedarikci"].ToString()) + 1).ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglanti.Close();

            baglanti.Open();
            try
            {
                SqlCommand al = new SqlCommand("select max(adres_id) as adres from Adres ", baglanti);
                SqlDataReader oku = al.ExecuteReader();
                if (!oku.HasRows)
                {
                    oku.Close();
                    baglanti.Close();
                }
                else
                {
                    while (oku.Read())
                    {
                        adres_id.Text = (int.Parse(oku["adres"].ToString()) + 1).ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglanti.Close();
            // TODO: Bu kod satırı 'fabrikavtDataSet18.Tedarikci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tedarikci_ad.Text) == true || string.IsNullOrEmpty(tedarikci_tel.Text) == true
               || string.IsNullOrEmpty(tedarikci_mail.Text) == true || string.IsNullOrEmpty(il.Text) == true || string.IsNullOrEmpty(ilce.Text) == true
              || string.IsNullOrEmpty(mahalle.Text) == true || string.IsNullOrEmpty(sokak.Text) == true
              || string.IsNullOrEmpty(no.Text) == true)
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string kayitt = "insert into Adres(adres_id,il,ilce,mahalle,sokak,no,daire) values (@adres_id,@il,@ilce,@mahalle,@sokak,@no,@daire)";
                    SqlCommand komutt = new SqlCommand(kayitt, baglanti);
                    komutt.Parameters.AddWithValue("@adres_id", adres_id.Text);
                    komutt.Parameters.AddWithValue("@il", il.Text);
                    komutt.Parameters.AddWithValue("@ilce", ilce.Text);
                    komutt.Parameters.AddWithValue("@mahalle", mahalle.Text);
                    komutt.Parameters.AddWithValue("@sokak", sokak.Text);
                    komutt.Parameters.AddWithValue("@no", no.Text);
                    komutt.Parameters.AddWithValue("@daire", daire.Text);
                    komutt.ExecuteNonQuery();
                    baglanti.Close();
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string kayit = "insert into Tedarikci(tedarikci_id,tedarikci_adsoyad,tedarikci_tel,tedarikci_mail,adres_id) values (@tedarikci_id,@tedarikci_adsoyad,@tedarikci_tel,@tedarikci_mail,@adres_id)";
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@tedarikci_id", tedarikci_id.Text);
                    komut.Parameters.AddWithValue("@tedarikci_adsoyad", tedarikci_ad.Text);
                    komut.Parameters.AddWithValue("@tedarikci_tel", tedarikci_tel.Text);
                    komut.Parameters.AddWithValue("@tedarikci_mail", tedarikci_mail.Text);
                    komut.Parameters.AddWithValue("@adres_id", adres_id.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Tedarikçi Kaydı Başarılı !");

                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
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

        private void tedariki_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            satinsecim satinsecim = new satinsecim();
            satinsecim.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yenitedarikci yenitedarikci = new yenitedarikci();
            yenitedarikci.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            satinmesaj satinmesaj = new satinmesaj();
            satinmesaj.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();

        }

        private void musteriara_TextChanged(object sender, EventArgs e)
        {
            Ara("select * from Tedarikci where tedarikci_adsoyad like '" + tedarikciara.Text + "%'");
        }

        private void adresara_TextChanged(object sender, EventArgs e)
        {
            Araa("Select * from Adres where adres_id in(select adres_id from Tedarikci) and ilce like'" + adresara.Text + "%'");
        }
    }
}
