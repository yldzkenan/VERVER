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
    public partial class satinalma : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANPC\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public satinalma()
        {
            InitializeComponent();
        }

        private void satinalma_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                SqlCommand al = new SqlCommand("select satis_gelir as finans from Finans ", baglanti);
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
                        para.Text = (Double.Parse(oku["finans"].ToString())).ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglanti.Close();



            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select * from Hammadde", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView1.DataSource = dTable;         
        }

        private void mustericombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hamcombo.SelectedIndex == 0)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from hammadde where hammadde_id = 1", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                while (okuc.Read())
                {
                    stok.Text = okuc["hammadde_miktar"].ToString();
                    birimfiyat.Text = okuc["hammadde_brfiyat"].ToString();
                }
                baglanti.Close();
            }
            if (hamcombo.SelectedIndex == 1)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from hammadde where hammadde_id = 2", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                while (okuc.Read())
                {
                    stok.Text = okuc["hammadde_miktar"].ToString();
                    birimfiyat.Text = okuc["hammadde_brfiyat"].ToString();
                }
                baglanti.Close();
            }
            if (hamcombo.SelectedIndex == 2)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from hammadde where hammadde_id = 3", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                while (okuc.Read())
                {
                    stok.Text = okuc["hammadde_miktar"].ToString();
                    birimfiyat.Text = okuc["hammadde_brfiyat"].ToString();
                }
                baglanti.Close();
            }
        }

        private void hesapla_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(miktar.Text);
            double b = Double.Parse(birimfiyat.Text);
            toplamfiyat.Text = (a * b).ToString();
            hammadde_miktar.Text = (int.Parse(stok.Text) + int.Parse(miktar.Text)).ToString();
            kalanpara.Text = (int.Parse(para.Text) - int.Parse(toplamfiyat.Text)).ToString();

            
        }

        private void onayla_Click(object sender, EventArgs e)
        {
            Double b = Double.Parse(miktar.Text) * Double.Parse(birimfiyat.Text);
            Double c = Double.Parse(para.Text);
            double d = c - b;
            if (hamcombo.SelectedIndex == 0)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from Hammadde where hammadde_id = 1", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                string kayit = "update Hammadde set hammadde_miktar=@hammadde_miktar where hammadde_id=1";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                
                if (d > 0 )
                {
                    while (okuc.Read())
                    {
                        int a = int.Parse(miktar.Text) + int.Parse(stok.Text);
                        MessageBox.Show("Hammadde Alımı Başarıyla Kaydedildi", "Onaylandı !");
                        komut.Parameters.AddWithValue("@hammadde_miktar", a);
                        komut.ExecuteNonQuery();

                        dataGridView1.Refresh();
                    }
                    okuc.Close();
                }
                else
                {
                    MessageBox.Show("Bu İşlem İçin Yönetici Şifresi Gerekmektedir", "Yetersiz Bakiye !");

                }
            }
            baglanti.Close();
            if (hamcombo.SelectedIndex == 1)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from Hammadde where hammadde_id = 2", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                string kayit = "update Hammadde set hammadde_miktar=@hammadde_miktar where hammadde_id=2";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                if (d >0 )
                {
                    while (okuc.Read())
                    {
                    int a = int.Parse(miktar.Text) + int.Parse(stok.Text);
                    MessageBox.Show("Hammadde Alımı Başarıyla Kaydedildi", "Onaylandı !");
                    komut.Parameters.AddWithValue("@hammadde_miktar", a);
                    komut.ExecuteNonQuery();

                    dataGridView1.Refresh();
                     }
                okuc.Close();
                }
                else
                {
                    MessageBox.Show("Bu İşlem İçin Yönetici Şifresi Gerekmektedir", "Yetersiz Bakiye !");

                }
              
            }
            baglanti.Close();
            if (hamcombo.SelectedIndex == 2)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from Hammadde where hammadde_id = 3", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                string kayit = "update Hammadde set hammadde_miktar=@hammadde_miktar where hammadde_id=3";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                if (d > 0)
                {
                    while (okuc.Read())
                    {
                        int a = int.Parse(miktar.Text) + int.Parse(stok.Text);
                        MessageBox.Show("Hammadde Alımı Başarıyla Kaydedildi", "Onaylandı !");
                        komut.Parameters.AddWithValue("@hammadde_miktar", a);
                        komut.ExecuteNonQuery();

                        dataGridView1.Refresh();
                    }
                    okuc.Close();
                }
                else
                {
                    MessageBox.Show("Bu İşlem İçin Yönetici Şifresi Gerekmektedir", "Yetersiz Bakiye !");

                }
            }
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            satinalma satinalma = new satinalma();
            satinalma.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            satinsecim satinsecim = new satinsecim();
            satinsecim.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            satinmesaj satinmesaj = new satinmesaj();
            satinmesaj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            {
                if (this.WindowState == FormWindowState.Maximized)
                    this.WindowState = FormWindowState.Normal;

                else
                    this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
