using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace VeriTabanıProje
{
    public partial class kullaniciekle : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlCommand komut3;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        public kullaniciekle()
        {
            InitializeComponent();
        }
        void PersonelGetir()
        {
            try
            {
                baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True");
                baglanti.Open();     
                da = new SqlDataAdapter("Select personel_id as ID,personel_ad as Ad,personel_soyad as Soyad, departman.departman_ad as 'Departman' ,personel_tel as TEL, personel_mail as Mail," +
                    "personel_cinsiyet as Cinsiyet from personel inner join departman on departman.departman_id=personel.departman_id ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;

                da2 = new SqlDataAdapter("Select kullanici_id,kullanici_ad,kullanici_sifre, yetki.yetki_ad,personel.departman_id from kullanicilar inner join yetki on kullanicilar.yetki_id=yetki.yetki_id inner join personel on kullanicilar.kullanici_id=personel.personel_id",baglanti);
                DataTable tablo2 = new DataTable();
                da2.Fill(tablo2);
                dataGridView2.DataSource = tablo2;
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        void Combo()
        {
            try
            {
                SqlConnection baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True";
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT * FROM yetki";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["yetki_ad"]);
                }
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void kullaniciekle_Load(object sender, EventArgs e)
        {
            Combo();
            PersonelGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textId.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textkAd.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textkSifre.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            textId.Text = null;
            textkAd.Text = null;
            textkSifre.Text = null;
            comboBox1.Text = null;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textId.Text))
            {
                MessageBox.Show("Lütfen Kişiyi seçiniz seçiniz");
            }
            else
            {
                baglanti.Open();
                string sorgu = "select kullanici_id from kullanicilar where kullanici_id=@kid";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kid", textId.Text);
                string perid = Convert.ToString(cmd.ExecuteScalar());

                if (perid == textId.Text)
                {
                    MessageBox.Show("Bu kişi zaten bir şifreye sahip!");
                }

                else
                {
                    try
                    {
                        string sorgu3 = "select yetki_id from yetki where yetki_ad=@yad";
                        SqlCommand cmd3 = new SqlCommand(sorgu3, baglanti);
                        cmd3.Parameters.AddWithValue("@yad", comboBox1.Text);
                        string yetki = Convert.ToString(cmd3.ExecuteScalar());


                        string sorgu2 = "insert into kullanicilar values(@kulid,@kulad,@kulsifre,@yetki)";
                        komut = new SqlCommand(sorgu2, baglanti);
                        komut.Parameters.AddWithValue("@kulid", textId.Text);
                        komut.Parameters.AddWithValue("@kulad", textkAd.Text);
                        komut.Parameters.AddWithValue("@kulsifre", textkSifre.Text);
                        komut.Parameters.AddWithValue("@yetki",Convert.ToInt32(yetki));
                        komut.ExecuteNonQuery();
                        PersonelGetir();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                        baglanti.Close();
                    }
                }
                baglanti.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textId.Text))
            {
                MessageBox.Show("ID belirtiniz.");
            }
            else
            {
                try
                {
                    string sorgu = "delete from kullanicilar where kullanici_id=@kid";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@kid", Convert.ToInt32(textId.Text));
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    PersonelGetir();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textId.Text) || string.IsNullOrEmpty(textkAd.Text) || string.IsNullOrEmpty(textkSifre.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Boş alan bırakılamaz");
            }
            else
            {
                try
                {
                    baglanti.Open();

                    string sorgu3 = "select yetki_id from yetki where yetki_ad=@yad";
                    SqlCommand cmd3 = new SqlCommand(sorgu3, baglanti);
                    cmd3.Parameters.AddWithValue("@yad", comboBox1.Text);
                    string yetki = Convert.ToString(cmd3.ExecuteScalar());

                    string sorgu = "update kullanicilar set kullanici_ad=@kad,kullanici_sifre=@ksif,yetki_id=@yetki where kullanici_id=@kid";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@kid", Convert.ToInt32(textId.Text));
                    komut.Parameters.AddWithValue("@kad", textkAd.Text);
                    komut.Parameters.AddWithValue("@ksif", textkSifre.Text);
                    komut.Parameters.AddWithValue("@yetki",Convert.ToInt32(yetki));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    PersonelGetir();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            try
            {
                baglanti.Open();

                string sorgu = "update kullanicilar set yetki_id=1";
                komut3 = new SqlCommand(sorgu, baglanti);
                komut3.ExecuteNonQuery();

                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT * FROM departman";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    string sorgu4 = "update kullanicilar set yetki_id=2 where kullanici_id=@kid";
                    SqlCommand cmd4 = new SqlCommand(sorgu4, baglanti);
                    cmd4.Parameters.AddWithValue("@kid", dr["yonetici_id"]);
                    cmd4.ExecuteNonQuery();
                }

                SqlCommand komut2 = new SqlCommand();
                komut2.CommandText = "SELECT * FROM personel where departman_id in(select departman_id from departman where departman_ad='Bilgi İşlem')";
                komut2.Connection = baglanti;
                komut2.CommandType = CommandType.Text;

                SqlDataReader dr2;
                dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    string sorgu4 = "update kullanicilar set yetki_id=3 where kullanici_id=@perid";
                    SqlCommand cmd4 = new SqlCommand(sorgu4, baglanti);
                    cmd4.Parameters.AddWithValue("@perid", dr2["personel_id"]);
                    cmd4.ExecuteNonQuery();
                }

                baglanti.Close();
                PersonelGetir();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ikmesaj ikmesaj = new ikmesaj();
            ikmesaj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ikMenu ikMenu = new ikMenu();
            ikMenu.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
