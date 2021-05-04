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
    public partial class satinalmadeneme : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        public satinalmadeneme()
        {
            InitializeComponent();
        }
        void PersonelGetir()
        {
            try
            {
                baglanti = new SqlConnection("server =USER11\\SQLEXPRESS; Initial Catalog = fabrikavt; Integrated Security = SSPI");
                baglanti.Open();
                da = new SqlDataAdapter("Select * from alım", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;

                da2 = new SqlDataAdapter("Select * from hammadde", baglanti);
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
                komut.CommandText = "SELECT * FROM hammadde";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    hamcombo.Items.Add(dr["hammadde_ad"]);
                }
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        void ComboTedarik()
        {
            try
            {
                SqlConnection baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True";
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT * FROM tedarikci";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["tedarikci_adsoyad"]);
                }
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void satinalmadeneme_Load(object sender, EventArgs e)
        {
            PersonelGetir();
            ComboTedarik();
            Combo();

        }

        private void hamcombo_TextChanged(object sender, EventArgs e)
        {

        }

        private void hamcombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            string sorgu = "Select hammadde_miktar from hammadde where hammadde_ad=@ad";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", hamcombo.Text);
            string a = Convert.ToString(komut.ExecuteScalar());
            stok.Text = a;

            string sorgu2 = "Select hammadde_brfiyat from hammadde where hammadde_ad=@ad";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            komut2.Parameters.AddWithValue("@ad", hamcombo.Text);
            string b = Convert.ToString(komut2.ExecuteScalar());
            birimfiyat.Text = b;

            baglanti.Close();
        }

        private void miktar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(miktar.Text))
            {
                toplamfiyat.Text = "0";
                hammadde_miktar.Text = "0";
            }

            else
            {
                try
                {
                    double toplam = (Convert.ToDouble(birimfiyat.Text)) * (Convert.ToDouble(miktar.Text));
                    toplamfiyat.Text = Convert.ToString(toplam);


                    baglanti.Open();

                    string sorgu = "Select hammadde_miktar from hammadde where hammadde_ad=@ad";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@ad", hamcombo.Text);
                    string a = Convert.ToString(komut.ExecuteScalar());
                    double guncel = Convert.ToDouble(a) + Convert.ToDouble(miktar.Text);
                    if(guncel==null)
                    {
                        hammadde_miktar.Text = "0";
                    }
                    else
                    {
                        hammadde_miktar.Text = Convert.ToString(guncel);
                   
                    }
                    baglanti.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void onayla_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Boş alan bırakmayınız!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu4 = "select top 1 alim_id from alım order by alim_id desc";
                    SqlCommand cmd3 = new SqlCommand(sorgu4, baglanti);
                    int aid = 1;
                    if (cmd3.ExecuteScalar() != null)
                    {
                        aid = Convert.ToInt32(cmd3.ExecuteScalar());
                        aid = aid + 1;
                    }

                    string sorgu1 = "select tedarikci_id from tedarikci where tedarikci_adsoyad=@tad";
                    SqlCommand cmd = new SqlCommand(sorgu1, baglanti);
                    cmd.Parameters.AddWithValue("@tad", comboBox1.Text);
                    string a = Convert.ToString(cmd.ExecuteScalar());

                    string sorgu2 = "select hammadde_id from hammadde where hammadde_ad=@had";
                    SqlCommand cmd2 = new SqlCommand(sorgu2, baglanti);
                    cmd2.Parameters.AddWithValue("@had", hamcombo.Text);
                    string b = Convert.ToString(cmd2.ExecuteScalar());



                    string sorgu3 = "insert into alım values(@id,@hid,@tid,@aa,@af,@at)";
                    SqlCommand komut1 = new SqlCommand(sorgu3, baglanti);
                    komut1.Parameters.AddWithValue("@id", aid);
                    komut1.Parameters.AddWithValue("@hid", b);
                    komut1.Parameters.AddWithValue("@tid", a);
                    komut1.Parameters.AddWithValue("@aa", miktar.Text);
                    komut1.Parameters.AddWithValue("@af", toplamfiyat.Text);
                    komut1.Parameters.AddWithValue("@at", Convert.ToDateTime(dateTimePicker1.Text));
                    komut1.ExecuteNonQuery();

                    string sorgu9 = "update hammadde set hammadde_miktar=@hmiktar where hammadde_id=@haid";
                    SqlCommand komut2 = new SqlCommand(sorgu9, baglanti);
                    komut2.Parameters.AddWithValue("@hmiktar",hammadde_miktar.Text);
                    komut2.Parameters.AddWithValue("@haid", b);
                    komut2.ExecuteNonQuery();

                    baglanti.Close();
                    PersonelGetir();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
            PersonelGetir();
        }
    }
}
