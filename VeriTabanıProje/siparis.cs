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
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public siparis()
        {
            InitializeComponent();
        }
        void Basla()
        {


            SqlCommand komutp = new SqlCommand();
            komutp.CommandText = "SELECT personel_ad, personel_soyad FROM Personel where departman_id = 1";
            komutp.Connection = baglanti;
            komutp.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komutp.ExecuteReader();
            while (dr.Read())
            {
                personelcombo.Items.Add(dr["personel_ad"]);
            }
            baglanti.Close();

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
            /*baglanti.Open();
            try
            {
                SqlCommand all = new SqlCommand("select max(satis_id) as satis from Satis ", baglanti);
                SqlDataReader okuuu = all.ExecuteReader();
                if (!okuuu.HasRows)
                {
                    okuuu.Close();
                    baglanti.Close();
                }
                else
                {
                    while (okuuu.Read())
                    {
                        satis_id.Text = (int.Parse(okuuu["satis"].ToString()) + 1).ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglanti.Close();*/


        }
        void Getir()
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select urun_ad as Ad, urun_brfiyat as 'Birim fiyat',urun_miktar as 'STOK',urun_aciklama as 'Açıklama' from Urun", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView1.DataSource = dTable;

            DataTable dTable2 = new DataTable();

            SqlDataAdapter dAdapter2 = new SqlDataAdapter("Select satis_id as 'Satış No', urun.urun_ad as Urun,musteri.musteri_adsoyad as Musteri, personel.personel_ad as 'Satışı yapan',satıs_adet as Adet, satıs_fiyat as Fiyat, satis_tarihi as Tarih from satis inner join urun on urun.urun_id=satis.urun_id inner join musteri on musteri.musteri_id=satis.musteri_id inner join personel on personel.personel_id=satis.personel_id order by satis_id desc", baglanti);
            {
                dAdapter2.Fill(dTable2);
            }
            dataGridView2.DataSource = dTable2;


            
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
            satis_id.Text = null;
            personelcombo.Text = null;
            mustericombo.Text = null;
            uruncombo.Text = null;
            stok.Text = null;
            miktar.Text = null;
            birimfiyat.Text = null;
            urun_miktar.Text = null;
            toplamfiyat.Text = null;
        }

        private void kayitlimüsteri_Load(object sender, EventArgs e)
        {
            Basla();
            Getir();
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

        }
        private void uruncombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            string sorgu = "Select urun_miktar from urun where urun_ad=@ad";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", uruncombo.Text);
            string a = Convert.ToString(komut.ExecuteScalar());
            stok.Text = a;

            string sorgu2 = "Select urun_brfiyat from Urun where urun_ad=@ad";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            komut2.Parameters.AddWithValue("@ad", uruncombo.Text);
            string b = Convert.ToString(komut2.ExecuteScalar());
            birimfiyat.Text = b;

            baglanti.Close();
        }
        private void miktar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(miktar.Text))
            {
                toplamfiyat.Text = "0";
                urun_miktar.Text = "0";
            }

            else
            {
                try
                {
                    double toplam = (Convert.ToDouble(birimfiyat.Text)) * (Convert.ToDouble(miktar.Text));
                    toplamfiyat.Text = Convert.ToString(toplam);


                    baglanti.Open();

                    string sorgu = "Select urun_miktar from urun where urun_ad=@ad";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@ad", uruncombo.Text);
                    string a = Convert.ToString(komut.ExecuteScalar());
                    double guncel = Convert.ToDouble(a) - Convert.ToDouble(miktar.Text);
                    if (guncel == null)
                    {
                        urun_miktar.Text = "0";
                    }
                    else
                    {
                        urun_miktar.Text = Convert.ToString(guncel);

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

            if (string.IsNullOrEmpty(uruncombo.Text) && string.IsNullOrEmpty(mustericombo.Text) && string.IsNullOrEmpty(personelcombo.Text))
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");
            }
            else
            {
                if (Convert.ToInt32(urun_miktar.Text) < 0)
                {
                    MessageBox.Show("YETERLİ STOK YOK");
                }
                else
                {
                    try
                    {
                        baglanti.Open();
                        string sorgu4 = "select top 1 satis_id from satis order by satis_id desc";
                        SqlCommand cmd3 = new SqlCommand(sorgu4, baglanti);
                        int sid = 1;
                        if (cmd3.ExecuteScalar() != null)
                        {
                            sid = Convert.ToInt32(cmd3.ExecuteScalar());
                            sid = sid + 1;
                        }


                        string sorgu1 = "select personel_id from personel where personel_ad=@pad";
                        SqlCommand cmd = new SqlCommand(sorgu1, baglanti);
                        cmd.Parameters.AddWithValue("@pad", personelcombo.Text);
                        string per = Convert.ToString(cmd.ExecuteScalar());


                        string sorgu2 = "select musteri_id from Musteri where musteri_adsoyad=@mad";
                        SqlCommand cmd2 = new SqlCommand(sorgu2, baglanti);
                        cmd2.Parameters.AddWithValue("@mad", mustericombo.Text);
                        string mus = Convert.ToString(cmd2.ExecuteScalar());



                        string sorgu9 = "select urun_id from Urun where urun_ad=@uad";
                        SqlCommand cmd9 = new SqlCommand(sorgu9, baglanti);
                        cmd9.Parameters.AddWithValue("@uad", uruncombo.Text);
                        string urun = Convert.ToString(cmd9.ExecuteScalar());



                        string sorgu3 = "insert into satis values (@satis_id,@urun_id,@musteri_id,@personel_id,@satis_adet,@satis_fiyat,@satis_tarihi)";

                        SqlCommand komut1 = new SqlCommand(sorgu3, baglanti);
                        komut1.Parameters.AddWithValue("@satis_id", sid);
                        komut1.Parameters.AddWithValue("@urun_id", urun);
                        komut1.Parameters.AddWithValue("@musteri_id", mus);
                        komut1.Parameters.AddWithValue("@personel_id", per);
                        komut1.Parameters.AddWithValue("@satis_adet", miktar.Text);
                        komut1.Parameters.AddWithValue("@satis_fiyat", toplamfiyat.Text);
                        komut1.Parameters.AddWithValue("@satis_tarihi", Convert.ToDateTime(dateTimePicker1.Text));
                        komut1.ExecuteNonQuery();

                        string sorgu10 = "update Urun set urun_miktar=@urun_miktar where urun_id=@urun_id";
                        SqlCommand komut2 = new SqlCommand(sorgu10, baglanti);
                        komut2.Parameters.AddWithValue("@urun_miktar", urun_miktar.Text);
                        komut2.Parameters.AddWithValue("@urun_id", urun);
                        komut2.ExecuteNonQuery();

                        baglanti.Close();
                        MessageBox.Show("Sipariş Onaylandı");
                        Getir();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
            }
    }
        private void birimfiyat_TextChanged(object sender, EventArgs e)
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
     

        private void personelcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
         