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
    public partial class satinsifre : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True");
        public satinsifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            if (string.IsNullOrEmpty(kullanici_ad.Text) == true || string.IsNullOrEmpty(kullanici_sifre.Text) == true)
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand al = new SqlCommand("select * from Kullanicilar where kullanici_ad=@kullanici_ad and kullanici_sifre=@kullanici_sifre", baglanti);
                    al.Parameters.Add("@kullanici_ad", SqlDbType.VarChar, 50).Value = kullanici_ad.Text;
                    al.Parameters.Add("@kullanici_sifre", SqlDbType.VarChar, 50).Value = kullanici_sifre.Text;

                    SqlDataReader oku = al.ExecuteReader();
                    if (!oku.HasRows)
                    {

                        MessageBox.Show("Böyle Bir Kullanıcı Yok.", "GİRİŞ BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        while (oku.Read())
                        {
                            string ad = (oku["kullanici_ad"].ToString());
                            string sifre = (oku["kullanici_sifre"].ToString());
                            if (ad == kullanici_ad.Text && sifre == kullanici_sifre.Text)
                            {
                                satinsecim satinsecim = new satinsecim();
                                satinsecim.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre", "GİRİŞ BAŞARISIZ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            satinyoneticisifre satinyoneticisifre = new satinyoneticisifre();
            satinyoneticisifre.Show(); this.Hide();
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
    }
}
