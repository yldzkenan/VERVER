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
    public partial class ikPersonelislem : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public ikPersonelislem()
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
                baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=SSPI;MultipleActiveResultSets=True");
                baglanti.Open();
                /*use fabrikavt;
                Select personel_id as ID,personel_ad as AD,personel_soyad as Soyad,personel_tel as TEL, personel_mail as Mail,
                    personel_cinsiyet as Cinsiyet,personel_dogumTarihi as 'Doğum Tarihi',personel_tc as TC,
                    personel_girisTarihi as 'Giriş Tarih',personel_maas as Maaş,adres_id as Adres , departman.departman_ad from personel inner join departman on departman.departman_id = personel.departman_id where personel.departman_id in(select departman_id from departman where departman_ad != 'İnsan Kaynakları');*/
                da = new SqlDataAdapter("Select personel_id as ID,personel_ad as AD,personel_soyad as Soyad,personel_tel as TEL, personel_mail as Mail," +
                    "personel_cinsiyet as Cinsiyet,personel_dogumTarihi as 'Doğum Tarihi',personel_tc as TC," +
                    "personel_girisTarihi as 'Giriş Tarih',personel_maas as Maaş,adres_id as Adres , departman.departman_ad from personel inner join departman on departman.departman_id=personel.departman_id ", baglanti);
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
        void Temizle()
        {
            textAd.Text = null;
            textAdres.Text = null;
            textAra.Text = null;
            textdaire.Text = null;
            dateTimePickerDT.Text = null;
            dateTimePickerGT.Text = null;
            textdaire.Text = null;
            textId.Text = null;
            textil.Text = null;
            textilce.Text = null;
            textMail.Text = null;
            textTC.Text = null;
            textTel.Text = null;
            textsokak.Text = null;
            textMaas.Text = null;
            comboBox1.Text = null;
            combocinsiyet.Text = null;
            textmahalle.Text = null;
            textSoyad.Text = null;
            textno.Text = null;
        }
        public DataTable Ara(string ara)
        {
            try
            {
                DataTable tbl = new DataTable();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(ara, baglanti);
                adtr.Fill(tbl);
                dataGridView1.DataSource = tbl;
                baglanti.Close();
                return tbl;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                return null;
            }
        }
            private void ikPersonelislem_Load(object sender, EventArgs e)
            {
                Combo();
                PersonelGetir();
            }

        private void textAra_TextChanged(object sender, EventArgs e)
        {
            Ara("Select personel_id as ID,personel_ad as Ad,personel_soyad as Soyad,personel_tel as TEL, personel_mail as Mail," +
               "personel_cinsiyet as Cinsiyet,personel_dogumTarihi as 'Doğum Tarihi',personel_tc as TC," +
               "personel_girisTarihi as 'Giriş Tarih',personel_maas as Maaş,adres_id as Adres , departman.departman_ad from personel inner join departman on departman.departman_id=personel.departman_id where personel_ad like'" + textAra.Text + "%'");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            textId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textMail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            combocinsiyet.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePickerDT.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textTC.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePickerGT.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textMaas.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textAdres.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            try
            {
                string sorgu = "Select il from adres where adres_id=@id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", textAdres.Text);
                string a = Convert.ToString(komut.ExecuteScalar());
                textil.Text = a;

                string sorgu1 = "Select ilce from adres where adres_id=@id";
                SqlCommand komut1 = new SqlCommand(sorgu1, baglanti);
                komut1.Parameters.AddWithValue("@id", textAdres.Text);
                string b = Convert.ToString(komut1.ExecuteScalar());
                textilce.Text = b;

                string sorgu2 = "Select mahalle from adres where adres_id=@id";
                SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
                komut2.Parameters.AddWithValue("@id", textAdres.Text);
                string c = Convert.ToString(komut2.ExecuteScalar());
                textmahalle.Text = c;

                string sorgu3 = "Select sokak from adres where adres_id=@id";
                SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@id", textAdres.Text);
                string d = Convert.ToString(komut3.ExecuteScalar());
                textsokak.Text = d;

                string sorgu4 = "Select no from adres where adres_id=@id";
                SqlCommand komut4 = new SqlCommand(sorgu4, baglanti);
                komut4.Parameters.AddWithValue("@id", textAdres.Text);
                string f = Convert.ToString(komut4.ExecuteScalar());
                textno.Text = f;

                string sorgu5 = "Select daire from adres where adres_id=@id";
                SqlCommand komut5 = new SqlCommand(sorgu5, baglanti);
                komut5.Parameters.AddWithValue("@id", textAdres.Text);
                string g = Convert.ToString(komut5.ExecuteScalar());
                textdaire.Text = g;
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Departman belirtilmelidir. Boş alan bırakmayınız!");
            }
            else
            {
                try
                { 
                    baglanti.Open();
                    string sorgu4 = "select top 1 personel_id from personel order by personel_id desc";
                    SqlCommand cmd3 = new SqlCommand(sorgu4, baglanti);
                    int pid=1;
                    if(cmd3.ExecuteScalar()!=null)
                    {
                        pid = Convert.ToInt32(cmd3.ExecuteScalar());
                        pid = pid + 1;
                    }
                    
                    
                    string sorgu1 = "select departman_id from departman where departman_ad=@dep";
                    SqlCommand cmd = new SqlCommand(sorgu1, baglanti);
                    cmd.Parameters.AddWithValue("@dep", comboBox1.Text);
                    string a = Convert.ToString(cmd.ExecuteScalar());

                    string sorgu2 = "select top 1 adres_id from adres order by adres_id desc";
                    SqlCommand cmd2 = new SqlCommand(sorgu2, baglanti);
                    int adres = Convert.ToInt32(cmd2.ExecuteScalar());
                    adres = adres + 1;

                    string sorgu3 = "insert into adres values(@id,@il,@ilce,@mahalle,@sokak,@no,@daire)";
                    SqlCommand komut1 = new SqlCommand(sorgu3, baglanti);
                    komut1.Parameters.AddWithValue("@id", adres);
                    komut1.Parameters.AddWithValue("@il", textil.Text);
                    komut1.Parameters.AddWithValue("@ilce", textilce.Text);
                    komut1.Parameters.AddWithValue("@mahalle", textmahalle.Text);
                    komut1.Parameters.AddWithValue("@sokak", textsokak.Text);
                    komut1.Parameters.AddWithValue("@no", textno.Text);
                    komut1.Parameters.AddWithValue("@daire", textdaire.Text);
                    komut1.ExecuteNonQuery();



                    string sorgu = "insert into personel values(@id,@ad,@soyad,@tel,@mail,@cinsiyet,@dt,@tc,@gt,@maas,@adres,@dep)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@id", pid);
                    komut.Parameters.AddWithValue("@ad", textAd.Text);
                    komut.Parameters.AddWithValue("@soyad", textSoyad.Text);
                    komut.Parameters.AddWithValue("@tel", textTel.Text);
                    komut.Parameters.AddWithValue("@mail", textMail.Text);
                    komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
                    komut.Parameters.AddWithValue("@dt", Convert.ToDateTime(dateTimePickerDT.Text));
                    komut.Parameters.AddWithValue("@tc", textTC.Text);
                    komut.Parameters.AddWithValue("@gt", Convert.ToDateTime(dateTimePickerGT.Text));
                    komut.Parameters.AddWithValue("@maas",Convert.ToDouble(textMaas.Text));
                    komut.Parameters.AddWithValue("@adres", adres);
                    komut.Parameters.AddWithValue("@dep", a);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    PersonelGetir();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            try
            {
                baglanti.Open();
                string sorgu1 = "select departman_id from departman where departman_ad=@dep";
                SqlCommand cmd = new SqlCommand(sorgu1, baglanti);
                cmd.Parameters.AddWithValue("@dep", comboBox1.Text);
                string a = Convert.ToString(cmd.ExecuteScalar());

                string sorgu2 = "update adres set il=@il,ilce=@ilce,mahalle=@mahalle,sokak=@sokak,no=@no,daire=@daire where adres_id=@aid";
                SqlCommand komut1 = new SqlCommand(sorgu2, baglanti);
                komut1.Parameters.AddWithValue("@aid", Convert.ToInt32(textAdres.Text));
                komut1.Parameters.AddWithValue("@il", textil.Text);
                komut1.Parameters.AddWithValue("@ilce", textilce.Text);
                komut1.Parameters.AddWithValue("@mahalle", textmahalle.Text);
                komut1.Parameters.AddWithValue("@sokak", textsokak.Text);
                komut1.Parameters.AddWithValue("@no", Convert.ToInt32(textno.Text));
                komut1.Parameters.AddWithValue("@daire", textdaire.Text);
                komut1.ExecuteNonQuery();

                string sorgu = "update personel set personel_id=@id,personel_ad=@ad,personel_soyad=@soyad,personel_tel=@tel,personel_mail=@mail,personel_cinsiyet=@cinsiyet,personel_dogumTarihi=@dt," +
                    "personel_tc=@tc,personel_girisTarihi=@gt,personel_maas=@maas,departman_id=@dep where personel_id=@id";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", textId.Text);
                komut.Parameters.AddWithValue("@ad", textAd.Text);
                komut.Parameters.AddWithValue("@soyad", textSoyad.Text);
                komut.Parameters.AddWithValue("@tel", textTel.Text);
                komut.Parameters.AddWithValue("@mail", textMail.Text);
                komut.Parameters.AddWithValue("@cinsiyet", combocinsiyet.Text);
                komut.Parameters.AddWithValue("@dt", Convert.ToDateTime(dateTimePickerDT.Text));
                komut.Parameters.AddWithValue("@tc", textTC.Text);
                komut.Parameters.AddWithValue("@gt", Convert.ToDateTime(dateTimePickerGT.Text));
                komut.Parameters.AddWithValue("@maas", Convert.ToDouble(textMaas.Text));
                komut.Parameters.AddWithValue("@adres", textAdres.Text);
                komut.Parameters.AddWithValue("@dep", a);
                komut.ExecuteNonQuery();
                baglanti.Close();
                PersonelGetir();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n ID belirttiğinizden emin olun");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textId.Text) == false)
            {
                
                baglanti.Open();
                string sorgu1 = "select yonetici_id from departman where yonetici_id in(select personel_id from personel where personel_id=@p_id )";
                SqlCommand cmd = new SqlCommand(sorgu1, baglanti);
                cmd.Parameters.AddWithValue("@p_id", textId.Text);
                if(cmd.ExecuteScalar()!=null)
                {
                    MessageBox.Show("Bu kişi aktif bir yönetici olduğu için silemezsiniz! Lütfen önce yeni yönetici atayınız");
                    baglanti.Close();
                }
                else
                {
                    baglanti.Close();
                    try
                    {
                        string sorgu2 = "delete from kullanicilar where kullanici_id=@id";
                        komut = new SqlCommand(sorgu2, baglanti);
                        komut.Parameters.AddWithValue("@id", Convert.ToInt32(textId.Text));
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        string sorgu = "delete from personel where personel_id=@id";
                        komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@id", Convert.ToInt32(textId.Text));
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        
                        PersonelGetir();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }   
                
            }
            else
            {
                MessageBox.Show("Lütfen ID belirtiniz.");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            ikMenu geri = new ikMenu();
            geri.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ikmesaj ikmesaj = new ikmesaj();
            ikmesaj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();

        }

        private void label21_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
