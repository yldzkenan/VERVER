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
    public partial class ikyoneticimenu : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public ikyoneticimenu()
        {
            InitializeComponent();
        }
        void PersonelGetir()
        {
            try
            {
                baglanti = new SqlConnection("Data Source=CANPC\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True");
                baglanti.Open();
                /*use fabrikavt;
                Select personel_id as ID,personel_ad as AD,personel_soyad as Soyad,personel_tel as TEL, personel_mail as Mail,
                    personel_cinsiyet as Cinsiyet,personel_dogumTarihi as 'Doğum Tarihi',personel_tc as TC,
                    personel_girisTarihi as 'Giriş Tarih',personel_maas as Maaş,adres_id as Adres , departman.departman_ad from personel inner join departman on departman.departman_id = personel.departman_id where personel.departman_id in(select departman_id from departman where departman_ad != 'İnsan Kaynakları');*/
                da = new SqlDataAdapter("Select personel_id as ID,personel_ad as AD,personel_soyad as Soyad,personel_tel as TEL, personel_mail as Mail," +
                    "personel_cinsiyet as Cinsiyet,personel_dogumTarihi as 'Doğum Tarihi',personel_tc as TC," +
                    "personel_girisTarihi as 'Giriş Tarih',personel_maas as Maaş,adres_id as Adres , departman.departman_ad from personel inner join departman on departman.departman_id=personel.departman_id where personel.departman_id in(select departman_id from departman where departman_ad='İnsan Kaynakları')", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void ikyoneticimenu_Load(object sender, EventArgs e)
        {
            PersonelGetir();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            try
            {
                baglanti.Open();
                string sorgu = "Select count(personel_id) from personel";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                string a = Convert.ToString(komut.ExecuteScalar());
                labelkayitlipersonel.Text = a;

                string sorgu2 = "Select count(departman_id) from departman";
                SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
                string b = Convert.ToString(komut2.ExecuteScalar());
                labeldepartmansayisi.Text = b;
                baglanti.Close();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ikMenu ikislem = new ikMenu();
            this.Hide();
            ikislem.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ikmesaj ikmesaj = new ikmesaj();
            ikmesaj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();
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
