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
    public partial class uretim : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public uretim()
        {
            InitializeComponent();
        }
        void Basla()
        {

            baglanti.Open();
            SqlCommand komutt = new SqlCommand("select * from Urun", baglanti);
            SqlDataReader okuu = komutt.ExecuteReader();
            while (okuu.Read())
            {
                combourun.Items.Add(okuu["urun_ad"]);
            }
            baglanti.Close();

        }
        void Getir()
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select urun_ad as 'Ürün Adı',urun_miktar as 'Ürün Miktar',hammadde.hammadde_ad as 'Hammaddesi',urun.hammadde_miktar as 'Gereken Hammadde Miktarı',hammadde_aciklama as 'Açıklama' from Urun inner join hammadde on hammadde.hammadde_id=urun.hammadde_id", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView1.DataSource = dTable;

            DataTable dTable2 = new DataTable();

            SqlDataAdapter dAdapter2 = new SqlDataAdapter("select hammadde_ad as 'Hammadde Ad',hammadde_miktar as 'Hammadde Stok',hammadde_aciklama as 'Açıklama' from hammadde", baglanti);
            {
                dAdapter2.Fill(dTable2);
            }
            dataGridView2.DataSource = dTable2;

            DataTable dTable3 = new DataTable();

            SqlDataAdapter dAdapter3 = new SqlDataAdapter("select uretim_id as 'Uretim Numarası',urun.urun_ad as 'Ürün Adı',uretim_adet as 'Üretim Adedi',uretim_tarihi as 'Üretim Tarihi' from uretim inner join urun on urun.urun_id=uretim.urun_id order by uretim_id desc", baglanti);
            {
                dAdapter3.Fill(dTable3);
            }
            dataGridView3.DataSource = dTable3;
        }
        void Temizle()
        {
            combourun.Text = null;
            textgerekliham.Text = null;
            texthammadde.Text = null;
            textmiktar.Text = null;     
            texttoplamham.Text = null;
            
        }

        private void uretim_Load(object sender, EventArgs e)
        {
            Basla();
            Getir();
        }

        private void combourun_SelectedValueChanged(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            string sorgu = "Select hammadde_ad from hammadde where hammadde_id=(select hammadde_id from urun where urun_ad=@ad)";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", combourun.Text);
            string a = Convert.ToString(komut.ExecuteScalar());
            texthammadde.Text = a;

            string sorgu2 = "Select hammadde_miktar from Urun where urun_ad=@ad";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            komut2.Parameters.AddWithValue("@ad", combourun.Text);
            string b = Convert.ToString(komut2.ExecuteScalar());
            textgerekliham.Text = b;

            string sorgu3 = "Select  hammadde_miktar from hammadde where hammadde_id=(select hammadde_id from urun where urun_ad=@ad)";
            SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@ad", combourun.Text);
            string c = Convert.ToString(komut3.ExecuteScalar());
            stok.Text = c;



            baglanti.Close();
        }

        private void textmiktar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combourun.Text))
            {
                MessageBox.Show("Ürün seçiniz!");
            }
            else
            {
                if (string.IsNullOrEmpty(textmiktar.Text)==false)
                {
                    double hammadde = Convert.ToDouble(textgerekliham.Text) * Convert.ToDouble(textmiktar.Text);
                    texttoplamham.Text = Convert.ToString(hammadde);

                }
                else
                {

                    texttoplamham.Text = null;
                }
            }
            
        }

        private void onayla_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            if (string.IsNullOrEmpty(combourun.Text) || string.IsNullOrEmpty(textmiktar.Text))
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");
            }
            else
            {
                if (Convert.ToInt32(stok.Text) < Convert.ToInt32(texttoplamham.Text))
                {
                    MessageBox.Show("YETERLİ STOK YOK");
                }
                else
                {
                    try
                    {
                        baglanti.Open();
                        string sorgu4 = "select top 1 uretim_id from uretim order by uretim_id desc";
                        SqlCommand cmd3 = new SqlCommand(sorgu4, baglanti);
                        int uid = 1;
                        if (cmd3.ExecuteScalar() != null)
                        {
                            uid = Convert.ToInt32(cmd3.ExecuteScalar());
                            uid = uid + 1;
                        }


                        string sorgu9 = "select urun_id from Urun where urun_ad=@uad";
                        SqlCommand cmd9 = new SqlCommand(sorgu9, baglanti);
                        cmd9.Parameters.AddWithValue("@uad", combourun.Text);
                        string urun = Convert.ToString(cmd9.ExecuteScalar());



                        string sorgu3 = "insert into uretim values (@uretim_id,@urun_id,@uretim_adet,getdate())";

                        SqlCommand komut1 = new SqlCommand(sorgu3, baglanti);
                        komut1.Parameters.AddWithValue("@uretim_id", uid);
                        komut1.Parameters.AddWithValue("@urun_id", urun);
                        komut1.Parameters.AddWithValue("@uretim_adet", textmiktar.Text);
                        komut1.ExecuteNonQuery();

                        string sorgu10 = "update Urun set urun_miktar=(urun_miktar+@urun_miktar) where urun_id=@urun_id";
                        SqlCommand komut2 = new SqlCommand(sorgu10, baglanti);
                        komut2.Parameters.AddWithValue("@urun_miktar", textmiktar.Text);
                        komut2.Parameters.AddWithValue("@urun_id", urun);
                        komut2.ExecuteNonQuery();

                        string sorgu11 = "update hammadde set hammadde_miktar=(hammadde_miktar-@hammadde_miktar) where hammadde_id=(select hammadde_id from urun where urun_id=@urun_id)";
                        SqlCommand komut3 = new SqlCommand(sorgu11, baglanti);
                        komut3.Parameters.AddWithValue("@hammadde_miktar", texttoplamham.Text);
                        komut3.Parameters.AddWithValue("@urun_id", urun);
                        komut3.ExecuteNonQuery();

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

        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
