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
    public partial class yenimüsteri : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANPC\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public yenimüsteri()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kullaniciAdi.Text) == true  || string.IsNullOrEmpty(kullaniciTelefon.Text) == true
                || string.IsNullOrEmpty(kullaniciEmail.Text) == true || string.IsNullOrEmpty(il.Text) == true || string.IsNullOrEmpty(ilce.Text) == true
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
                    string kayit = "insert into Musteri(musteri_id,musteri_adsoyad,musteri_tel,musteri_mail,adres_id) values (@musteri_id,@musteri_adsoyad,@musteri_tel,@musteri_mail,@adres_id)";
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@musteri_id", musteri_id.Text);
                    komut.Parameters.AddWithValue("@musteri_adsoyad", kullaniciAdi.Text);                
                    komut.Parameters.AddWithValue("@musteri_tel", kullaniciTelefon.Text);
                    komut.Parameters.AddWithValue("@musteri_mail", kullaniciEmail.Text);
                    komut.Parameters.AddWithValue("@adres_id", adres_id.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();                                    
                    MessageBox.Show("Müşteri Kaydı Başarılı !");
                    
                }
                catch (Exception hata)
                {
                   MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void yenimüsteri_Load(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select * from Musteri", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView1.DataSource = dTable;
            DataTable dTablee = new DataTable();

            SqlDataAdapter dAdapterr = new SqlDataAdapter("Select * from Adres", baglanti);
            {
                dAdapterr.Fill(dTablee);
            }
            dataGridView2.DataSource = dTablee;
            baglanti.Open();
            try
            {
                SqlCommand al = new SqlCommand("select max(musteri_id) as musteri from Musteri ", baglanti);             
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
                        musteri_id.Text = (int.Parse(oku["musteri"].ToString())+ 1).ToString();
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
           
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(kullaniciAdi.Text) == true || string.IsNullOrEmpty(kullaniciTelefon.Text) == true
            //   || string.IsNullOrEmpty(kullaniciEmail.Text) == true
            //   || string.IsNullOrEmpty(il.Text) == true || string.IsNullOrEmpty(ilce.Text) == true
            //   || string.IsNullOrEmpty(mahalle.Text) == true || string.IsNullOrEmpty(sokak.Text) == true
            //   || string.IsNullOrEmpty(no.Text) == true)
            //{
            //    MessageBox.Show("Bu Alanlar Boş Bırakılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    try
            //    {
            //        if (baglanti.State == ConnectionState.Closed)
            //            baglanti.Open();
            //        string kayit = "insert into Adres(adres_id,il,ilce,mahalle,sokak,no,daire) values (@adres_id,@il,@ilce,@mahalle,@sokak,@no,@daire)";
            //        SqlCommand komut = new SqlCommand(kayit, baglanti);
            //        komut.Parameters.AddWithValue("@adres_id", adres_id.Text);
            //        komut.Parameters.AddWithValue("@il", il.Text);
            //        komut.Parameters.AddWithValue("@ilce", ilce.Text);
            //        komut.Parameters.AddWithValue("@mahalle", mahalle.Text);                 
            //        komut.Parameters.AddWithValue("@sokak", sokak.Text);
            //        komut.Parameters.AddWithValue("@no", no.Text);
            //        komut.Parameters.AddWithValue("@daire", daire.Text);
            //        komut.ExecuteNonQuery();
            //        baglanti.Close();
            //        MessageBox.Show("Adres Kaydı Başarılı !");
            //    }
            //    catch (Exception hata)
            //    {
            //        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            //    }
            //}
        }

        private void label6_Click(object sender, EventArgs e)
        {
            satışsecim secim = new satışsecim();
            secim.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void musteriid_TextChanged(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand al = new SqlCommand("select Max(musteri_id) from Musteri", baglanti);
            //al.Parameters.Add("@musteri_id", SqlDbType.Int).Value = musteriid.Text;
            //int a = int.Parse(musteriid.Text);
            //int b = a + 1;
            //b = int.Parse(musteriid.Text);
            //baglanti.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

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

        private void musteriara_TextChanged(object sender, EventArgs e)
        {
            Ara("select * from musteri where musteri_adsoyad like '" + musteriara.Text + "%'");
        }

        private void adresara_TextChanged(object sender, EventArgs e)
        {
            Araa("Select * from Adres where adres_id in(select adres_id from Musteri) and ilce like'" + adresara.Text + "%'");
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            satismesaj satismesaj = new satismesaj();
            satismesaj.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yenimüsteri yenimüsteri = new yenimüsteri();
            yenimüsteri.Show();
            this.Hide();
        }
    }
}
