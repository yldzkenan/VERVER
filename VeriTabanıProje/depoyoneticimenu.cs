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
    
    public partial class depoyoneticimenu : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        private bool mouseDown;
        private Point lastLocation;
        public depoyoneticimenu()
        {
            InitializeComponent();
        }
        void PersonelGetir()
        {
            try
            {
                baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True");
                baglanti.Open();
                da = new SqlDataAdapter("Select personel_id as ID,personel_ad as AD,personel_soyad as Soyad,personel_tel as TEL, personel_mail as Mail," +
                    "personel_cinsiyet as Cinsiyet,personel_dogumTarihi as 'Doğum Tarihi',personel_tc as TC," +
                    "personel_girisTarihi as 'Giriş Tarih',personel_maas as Maaş,adres_id as Adres , departman.departman_ad from personel inner join departman on departman.departman_id=personel.departman_id where personel.departman_id in(select departman_id from departman where departman_ad='Depo')", baglanti);
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
        private void btnstokdurum_Click(object sender, EventArgs e)
        {
            depostokdurum dsd = new depostokdurum();
            dsd.Show();
        }

        private void buttonKargo_Click(object sender, EventArgs e)
        {
            depogonderim dg = new depogonderim();
            dg.Show();
        }

        private void buttonTeslim_Click(object sender, EventArgs e)
        {
            depogonderimteslim dgt = new depogonderimteslim();
            dgt.Show();
        }

        private void depoyoneticimenu_Load(object sender, EventArgs e)
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

                string sorgu2 = "Select count(gonderi_id) from gonderi";
                SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
                string b = Convert.ToString(komut2.ExecuteScalar());
                labelislem.Text = b;

                string sorgu3 = "Select count(satis_id) from satis";
                SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
                string c = Convert.ToString(komut3.ExecuteScalar());
                int bekleyen = Convert.ToInt32(c) - Convert.ToInt32(b);
                labelbekleyen.Text = bekleyen.ToString();
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            depomesaj dm = new depomesaj();
            dm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();
        }

        private void depoyoneticimenu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void depoyoneticimenu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void depoyoneticimenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
    }
}
