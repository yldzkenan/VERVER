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
    public partial class yoneticimaasveri : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public yoneticimaasveri()
        {
            InitializeComponent();
        }

        void Combo()
        {
            try
            {
                SqlConnection baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True";
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT * FROM departman";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["departman_ad"]);
                }
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        void PersonelGetir()
        {
            try
            {
                baglanti = new SqlConnection("server =USER11\\SQLEXPRESS; Initial Catalog = fabrikavt; Integrated Security = SSPI");
                baglanti.Open();
                da = new SqlDataAdapter("Select top 1 personel_ad,personel_soyad,personel_maas,personel_tc,personel_cinsiyet,departman.departman_ad,personel_girisTarihi from personel inner join departman on departman.departman_id=personel.departman_id order by personel_maas asc", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView2.DataSource = tablo;

                da = new SqlDataAdapter("Select top 1 personel_ad,personel_soyad,personel_maas,personel_tc,personel_cinsiyet,departman.departman_ad,personel_girisTarihi from personel inner join departman on departman.departman_id=personel.departman_id order by personel_maas desc", baglanti);
                DataTable tablo2 = new DataTable();
                da.Fill(tablo2);
                dataGridView1.DataSource = tablo2;
                baglanti.Close();
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void yoneticimaasveri_Load(object sender, EventArgs e)
        {
            PersonelGetir();
            Combo();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sorgu = "Select sum(personel_maas) from personel where departman_id=(select departman_id from departman where departman_ad=@dad)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@dad", comboBox1.Text);
                string a = Convert.ToString(komut.ExecuteScalar());
                textmaas.Text = a;

                string sorgu1 = "Select count(personel_id) from personel where departman_id=(select departman_id from departman where departman_ad=@dad)";
                SqlCommand komut1 = new SqlCommand(sorgu1, baglanti);
                komut1.Parameters.AddWithValue("@dad", comboBox1.Text);
                string b = Convert.ToString(komut1.ExecuteScalar());
                textpersonel.Text = b;

                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            yonetim yntm = new yonetim();
            this.Hide();
            yntm.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
