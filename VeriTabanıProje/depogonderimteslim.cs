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
    public partial class depogonderimteslim : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        private bool mouseDown;
        private Point lastLocation;
        public depogonderimteslim()
        {
            InitializeComponent();
        }
        void Getir()
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select gonderi.gonderi_id as 'Gönderi No',musteri.musteri_adsoyad,urun.urun_ad,gonderi.gonderim_tarihi as 'Gönderim Tarihi',satıs_adet 'Adet',gonderi.kargo_no as 'Kargo Numarası' from satis inner join gonderi on gonderi.gonderi_id=satis.satis_id inner join musteri on musteri.musteri_id=satis.musteri_id inner join urun on satis.urun_id=urun.urun_id  where gonderi.durum_id=1 ", baglanti);

            dAdapter.Fill(dTable);

            dataGridView1.DataSource = dTable;

            DataTable dTable2 = new DataTable();

            SqlDataAdapter dAdapter2 = new SqlDataAdapter("Select gonderi.gonderi_id as 'Gönderi No',musteri.musteri_adsoyad,urun.urun_ad,gonderi.gonderim_tarihi as 'Gönderim Tarihi',satıs_adet 'Adet',gonderi.kargo_no as 'Kargo Numarası',gonderi.teslim_tarihi as 'Teslim Tarihi' from satis inner join gonderi on gonderi.gonderi_id=satis.satis_id inner join musteri on musteri.musteri_id=satis.musteri_id inner join urun on satis.urun_id=urun.urun_id  where gonderi.durum_id=2 ", baglanti);
            dAdapter2.Fill(dTable2);
            dataGridView2.DataSource = dTable2;

        }
        private void depogonderimteslim_Load(object sender, EventArgs e)
        {
            Getir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            texturun.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textmusteri.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void onayla_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textid.Text))
            {
                MessageBox.Show("Boş alan bırakmayınız!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "update gonderi set durum_id=@durum,teslim_tarihi=getdate() where gonderi_id=@id";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@id", textid.Text);
                    komut.Parameters.AddWithValue("@durum", 2);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Getir();
                    //Temizle();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void depogonderimteslim_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void depogonderimteslim_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void depogonderimteslim_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
    }
}
