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
    public partial class siparis : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANPC\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public siparis()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kmc kmc = new kmc();
            kmc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            siparis kayitlimüsteri = new siparis();
            kayitlimüsteri.Show();
            this.Close();
        }

        private void kayitlimüsteri_Load(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select * from Urun", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView1.DataSource = dTable;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                mustericombo.Items.Add(oku["musteri_adsoyad"]);
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komutt = new SqlCommand("select * from Urun", baglanti);
            SqlDataReader okuu = komutt.ExecuteReader();
            while (okuu.Read())
            {
                uruncombo.Items.Add(okuu["urun_ad"]);
            }
            baglanti.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            satışsecim secim = new satışsecim();
            secim.Show();
            this.Hide();
        }

        private void uruncombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uruncombo.SelectedIndex == 0)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from Urun where urun_id = 1", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                while (okuc.Read())
                {
                    stok.Text = okuc["urun_miktar"].ToString();
                    birimfiyat.Text = okuc["urun_brfiyat"].ToString();
                }
                baglanti.Close();
            }
            if (uruncombo.SelectedIndex == 1)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from Urun where urun_id = 2", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                while (okuc.Read())
                {
                    stok.Text = okuc["urun_miktar"].ToString();
                    birimfiyat.Text = okuc["urun_brfiyat"].ToString();
                }
                baglanti.Close();

            }
            if (uruncombo.SelectedIndex == 2)
            {
                baglanti.Open();
                SqlCommand cek = new SqlCommand("SELECT * from Urun where urun_id = 3", baglanti);
                SqlDataReader okuc = cek.ExecuteReader();
                while (okuc.Read())
                {
                    stok.Text = okuc["urun_miktar"].ToString();
                    birimfiyat.Text = okuc["urun_brfiyat"].ToString();
                }
                baglanti.Close();
            }
        }
        private void hesapla_Click_1(object sender, EventArgs e)
        {
            
           double a = Double.Parse(miktar.Text);
           double b = Double.Parse(birimfiyat.Text);
           toplamfiyat.Text =(a*b).ToString();
            urun_miktar.Text = (int.Parse(stok.Text) - int.Parse(miktar.Text)).ToString();
        }
    
                
        private void onayla_Click(object sender, EventArgs e)
        {       
                if (uruncombo.SelectedIndex == 0)
                {                                                         
                baglanti.Open();
                    SqlCommand cek = new SqlCommand("SELECT * from Urun where urun_id = 1", baglanti);
                    SqlDataReader okuc = cek.ExecuteReader();
                    string kayit = "update Urun set urun_miktar=@urun_miktar where urun_id=1";
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    while (okuc.Read())
                    {                      
                        int s = int.Parse(stok.Text);
                        int m = int.Parse(miktar.Text);                       
                        if (m <= s)
                        {
                        int a = s - m;
                            MessageBox.Show("Sipariş Başarıyla Kaydedildi", "Onaylandı !");                         
                            komut.Parameters.AddWithValue("@urun_miktar",a);
                            komut.ExecuteNonQuery();
                           
                        }
                        else
                        {
                            MessageBox.Show("Sipariş Miktarı, Stok Miktarından Fazla Olamaz !", "HATA !");
                            isteksoru isteksoru = new isteksoru();
                            isteksoru.Show();
                           
                        }
                     dataGridView1.Refresh();
                    }
                okuc.Close();
            }
                baglanti.Close();
                if (uruncombo.SelectedIndex == 1)
                {               
                baglanti.Open();
                    SqlCommand cek = new SqlCommand("SELECT * from Urun where urun_id = 2", baglanti);
                    SqlDataReader okuc = cek.ExecuteReader();              
                    string kayit = "update Urun set urun_miktar=@urun_miktar where urun_id=2";
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    while (okuc.Read())
                    {                       
                        int s = int.Parse(stok.Text);
                        int m = int.Parse(miktar.Text);
                    if (m <= s)
                    {
                        int a = s - m;
                        MessageBox.Show("Sipariş Başarıyla Kaydedildi", "Onaylandı !");
                        komut.Parameters.AddWithValue("@urun_miktar", a);
                        komut.ExecuteNonQuery();
                       
                    }
                    else
                    {
                        MessageBox.Show("Sipariş Miktarı, Stok Miktarından Fazla Olamaz !", "HATA !");
                        isteksoru isteksoru = new isteksoru();
                        isteksoru.Show();
                       
                    } 
                    dataGridView1.Refresh();
                }
                okuc.Close();
             }
                baglanti.Close();
                if (uruncombo.SelectedIndex == 2)
                {              
                    baglanti.Open();
                    SqlCommand cek = new SqlCommand("SELECT * from Urun where urun_id = 3", baglanti);
                    SqlDataReader okuc = cek.ExecuteReader();    
                     string kayit = "update Urun set urun_miktar=@urun_miktar where urun_id=3";                        
                        SqlCommand komut = new SqlCommand(kayit, baglanti);     
                    while (okuc.Read())
                    {                 
                    int s = int.Parse(stok.Text);
                    int m = int.Parse(miktar.Text);                   
                    if (m <= s)                      
                    {
                        int a = s - m;
                                                                        
                        komut.Parameters.AddWithValue("@urun_miktar", a);
                        MessageBox.Show("Sipariş Başarıyla Kaydedildi", "Onaylandı !");
                        komut.ExecuteNonQuery();
                        
                    }
                    else
                        {
                            MessageBox.Show("Sipariş Miktarı, Stok Miktarından Fazla Olamaz !", "HATA !");
                        isteksoru isteksoru = new isteksoru();
                        isteksoru.Show();
                      
                    }
                    }
                         dataGridView1.Refresh();    
                } 
                 baglanti.Close();
            //siparis kayitlimüsteri = new siparis();
            //kayitlimüsteri.Show();
            //this.Close();
        }
        private void birimfiyat_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void miktar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void kalanstok_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            satismesaj satismesaj = new satismesaj();
            satismesaj.Show();
        }
    }
}
         