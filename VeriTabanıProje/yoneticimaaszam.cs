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
    public partial class yoneticimaaszam : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public yoneticimaaszam()
        {
            InitializeComponent();
        }
        void PersonelGetir()
        {
            try
            {
                baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True");
                baglanti.Open();

                da = new SqlDataAdapter("Select personel_maas as Maaş,personel_id as ID,personel_ad as AD,personel_soyad as Soyad,departman.departman_ad,personel_tel as TEL, personel_mail as Mail," +
                    "personel_cinsiyet as Cinsiyet,personel_dogumTarihi as 'Doğum Tarihi',personel_tc as TC," +
                    "personel_girisTarihi as 'Giriş Tarih',adres_id as Adres  from personel inner join departman on departman.departman_id=personel.departman_id ", baglanti);
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
                    comboBox2.Items.Add(dr["departman_ad"]);
                }
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        void Temizle()
        {
            textzamoran.Text = null;
            textindirimoran.Text = null;
            textdepzam.Text = null;
            textdepindir.Text = null;
            textid.Text = null;
            textad.Text = null;
            textsoyad.Text = null;
            textsoyad.Text = null;
            textdep.Text = null;
            textmaas.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
        }
        private void yoneticimaaszam_Load(object sender, EventArgs e)
        {
            PersonelGetir();
            Combo();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textmaas.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textsoyad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textdep.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void buttonmaasduzenle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textmaas.Text))
            {
                MessageBox.Show("Maaş belirtiniz.");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "update personel set personel_maas=@maas where personel_id=@pid";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@maas", Convert.ToDouble(textmaas.Text));
                    komut.Parameters.AddWithValue("@pid", textid.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    PersonelGetir();
                    MessageBox.Show("Maaş düzenleme işlemi başarılı");      
                    Temizle();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }

        }

        private void buttonzamonay_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textzamoran.Text))
            {
                MessageBox.Show("Zammı belirtiniz.");
            }
            else
            {
                try
                {
                    double zam = Convert.ToDouble(textzamoran.Text);
                    baglanti.Open();
                    string sorgu = "update personel set personel_maas=personel_maas+(personel_maas*(@zam/100))";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@zam",zam);
                    komut.ExecuteNonQuery();
                    baglanti.Close();             
                    PersonelGetir();
                    MessageBox.Show("%" + Convert.ToString(zam) + " zam yapıldı");
                    Temizle();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void buttoninidronay_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textindirimoran.Text))
            {
                MessageBox.Show("Zammı belirtiniz.");
            }
            else
            {
                try
                {
                    double indir = Convert.ToDouble(textindirimoran.Text);
                    baglanti.Open();
                    string sorgu = "update personel set personel_maas=personel_maas-(personel_maas*(@indir/100))";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@indir", indir);
                    komut.ExecuteNonQuery();
                    baglanti.Close();                    
                    PersonelGetir();
                    MessageBox.Show("%" + Convert.ToString(indir) + " indirim yapıldı");
                    Temizle();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void buttondepzam_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textdepzam.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Departmanı ve zammı belirtiniz.");
            }
            else
            {
                try
                {
                    double depzam = Convert.ToDouble(textdepzam.Text);
                    baglanti.Open();
                    string sorgu = "update personel set personel_maas=personel_maas+(personel_maas*(@zam/100)) where departman_id in (select departman_id from departman where departman_ad=@dad)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@zam", depzam);
                    komut.Parameters.AddWithValue("@dad", comboBox1.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    PersonelGetir();
                    MessageBox.Show(comboBox1.Text + " departmanına " + "%" + Convert.ToString(depzam) + "zam yapıldı");
                    Temizle();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void buttondepindir_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textdepindir.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Departmanı ve zammı belirtiniz.");
            }
            else
            {
                try
                {
                    double depindir = Convert.ToDouble(textdepindir.Text);
                    baglanti.Open();
                    string sorgu = "update personel set personel_maas=personel_maas-(personel_maas*(@indir/100)) where departman_id in (select departman_id from departman where departman_ad=@dad)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@indir", depindir);
                    komut.Parameters.AddWithValue("@dad", comboBox2.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    PersonelGetir();
                    MessageBox.Show(comboBox1.Text + " departmanına " + "%" + Convert.ToString(depindir) + "indirim yapıldı");
                    Temizle();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
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
