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
    public partial class depogonderim : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public depogonderim()
        {
            InitializeComponent();
        }
        void Getir()
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select satis_id as 'Satış No', urun.urun_ad as Urun,musteri.musteri_adsoyad as Musteri, personel.personel_ad as 'Satışı yapan',satıs_adet as Adet, satıs_fiyat as Fiyat, satis_tarihi as Tarih from satis inner join urun on urun.urun_id=satis.urun_id inner join musteri on musteri.musteri_id=satis.musteri_id inner join personel on personel.personel_id=satis.personel_id where satis_id not in(select gonderi_id from gonderi) order by satis_id desc", baglanti);
            
            dAdapter.Fill(dTable);
            
            dataGridView1.DataSource = dTable;

            DataTable dTable2 = new DataTable();

            SqlDataAdapter dAdapter2 = new SqlDataAdapter("Select gonderi.gonderi_id as 'Gönderi No',musteri.musteri_adsoyad,urun.urun_ad,gonderi.gonderim_tarihi as 'Gönderim Tarihi',satıs_adet 'Adet',gonderi.kargo_no as 'Kargo Numarası' from satis inner join gonderi on gonderi.gonderi_id=satis.satis_id inner join musteri on musteri.musteri_id=satis.musteri_id inner join urun on satis.urun_id=urun.urun_id  where gonderi.durum_id=1 ", baglanti);
            dAdapter2.Fill(dTable2);
            dataGridView2.DataSource = dTable2;

        }
        void Temizle()
        {
            textid.Text = null;
            texturun.Text = null;
            textmusteri.Text = null;
            textkargono.Text = null;
        }
        private void depogonderim_Load(object sender, EventArgs e)
        {
            Getir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            texturun.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textmusteri.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void onayla_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textid.Text)|| string.IsNullOrEmpty(texturun.Text) || string.IsNullOrEmpty(textmusteri.Text) || string.IsNullOrEmpty(textkargono.Text))
            {
                MessageBox.Show("Boş alan bırakmayınız!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "insert into gonderi(gonderi_id,durum_id,kargo_no,gonderim_tarihi) values(@id,@durum,@kargo,getdate())";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@id", textid.Text);
                    komut.Parameters.AddWithValue("@durum", 1);
                    komut.Parameters.AddWithValue("@kargo", textkargono.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Getir();
                    Temizle();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }

            }  
        }
    }
}
