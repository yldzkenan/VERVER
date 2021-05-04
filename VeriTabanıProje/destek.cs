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
    public partial class destek : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikadb;Integrated Security=True");
        public destek()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kmc kmc = new kmc();
            kmc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(adiniz.Text) == true || string.IsNullOrEmpty(soyadiniz.Text) == true || string.IsNullOrEmpty(emailiniz.Text) == true
                || string.IsNullOrEmpty(teliniz.Text) == true || string.IsNullOrEmpty(konunuz.Text) == true)
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string kayit = "insert into destek(adınız,soyadınız,email,telefonunuz,konunuz) values (@adınız,@soyadınız,@email,@telefon,@konu)";
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@adınız", adiniz.Text);
                    komut.Parameters.AddWithValue("@soyadınız", soyadiniz.Text);
                    komut.Parameters.AddWithValue("@email", emailiniz.Text);
                    komut.Parameters.AddWithValue("@telefon", teliniz.Text);
                    komut.Parameters.AddWithValue("@konu", konunuz.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Destek Talebiniz Başarıyla İletildi");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            kmc kmc = new kmc();
            kmc.Show();
            this.Hide();
        }
    }
}
