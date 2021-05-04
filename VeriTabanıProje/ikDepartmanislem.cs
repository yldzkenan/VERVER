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
    public partial class ikDepartmanislem : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public ikDepartmanislem()
        {
            InitializeComponent();
        }
        public DataTable Ara(string ara)
        {
            try
            {
                DataTable tbl = new DataTable();
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(ara, baglanti);
                adtr.Fill(tbl);
                dataGridView2.DataSource = tbl;
                baglanti.Close();
                return tbl;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                return null;
            }
        }
        void PersonelGetir()
        {
            try
            {
                baglanti = new SqlConnection("server =CANPC\\SQLEXPRESS; Initial Catalog = fabrikavt; Integrated Security = SSPI");
                baglanti.Open();
                da = new SqlDataAdapter("Select personel_id as 'Personel id',personel_ad as 'Personel ad',personel_soyad 'Personel soyad' from personel", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView2.DataSource = tablo;
                baglanti.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        void Getir()
        {
            try
            {
                baglanti = new SqlConnection("server =CANPC\\SQLEXPRESS; Initial Catalog = fabrikavt; Integrated Security = SSPI");
                baglanti.Open();
                da = new SqlDataAdapter("Select * from departman", baglanti);
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
            textDepid.Text = null;
            textYonetici.Text = null;
            textDepad.Text = null;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            else
            {
                baglanti.Open();
                if (string.IsNullOrEmpty(textYonetici.Text)==false)
                {
                    
                    string sorgu6 = "select yonetici_id from departman where yonetici_id=@yid";
                    SqlCommand cmd6 = new SqlCommand(sorgu6, baglanti);
                    cmd6.Parameters.AddWithValue("@yid", textYonetici.Text);
                    string perid = Convert.ToString(cmd6.ExecuteScalar());

                    if (perid == textYonetici.Text)
                    {
                        MessageBox.Show("Bu kişi zaten bir departmanı yönetiyor");
                    }

                    else
                    {
                        try
                        {
                            string sorgu4 = "select top 1 departman_id from departman order by departman_id desc";
                            SqlCommand cmd3 = new SqlCommand(sorgu4, baglanti);
                            int did = 1;
                            if (cmd3.ExecuteScalar() != null)
                            {
                                did = Convert.ToInt32(cmd3.ExecuteScalar());
                                did = did + 1;
                            }

                            string sorgu = "insert into departman values(@departman_id,@departman_ad,@yonetici_id)";
                            komut = new SqlCommand(sorgu, baglanti);
                            komut.Parameters.AddWithValue("@departman_id", did);
                            komut.Parameters.AddWithValue("@departman_ad", textDepad.Text);
                            komut.Parameters.AddWithValue("@yonetici_id", textYonetici.Text);

                            komut.ExecuteNonQuery();
                            Getir();
                        }
                        catch (Exception excep)
                        {
                            MessageBox.Show(excep.Message);
                            baglanti.Close();
                        }
                        baglanti.Close();
                    }
                    

                }
                else
                {

                    try
                    {
                        string sorgu4 = "select top 1 departman_id from departman order by departman_id desc";
                        SqlCommand cmd3 = new SqlCommand(sorgu4, baglanti);
                        int did = 1;
                        if (cmd3.ExecuteScalar() != null)
                        {
                            did = Convert.ToInt32(cmd3.ExecuteScalar());
                            did = did + 1;
                        }

                        string sorgu = "insert into departman(departman_id,departman_ad) values(@departman_id,@departman_ad)";
                        komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@departman_id", did);
                        komut.Parameters.AddWithValue("@departman_ad", textDepad.Text);

                        komut.ExecuteNonQuery();
                        Getir();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                        baglanti.Close();
                    }
                    baglanti.Close();
                }
                

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            if (string.IsNullOrEmpty(textDepid.Text))
            {
                MessageBox.Show("Departman adını belirtiniz.");
            }
            else
            {
                try
                {
                    string sorgu = "delete from departman where departman_id=@departman_id";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@departman_id", Convert.ToInt32(textDepid.Text));
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Getir();
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
            if (string.IsNullOrEmpty(textDepad.Text) || string.IsNullOrEmpty(textDepid.Text) || string.IsNullOrEmpty(textYonetici.Text) || string.IsNullOrWhiteSpace(textYonetici.Text))
            {
                MessageBox.Show("Boş alan bırakılamaz");
            }
            else
            {
                baglanti.Open();
                string sorgu6 = "select yonetici_id from departman where yonetici_id=@yid";
                SqlCommand cmd6 = new SqlCommand(sorgu6, baglanti);
                cmd6.Parameters.AddWithValue("@yid", textYonetici.Text);
                string perid = Convert.ToString(cmd6.ExecuteScalar());

                string sorgu7 = "select departman_ad from departman where departman_id=@departid";
                SqlCommand cmd7 = new SqlCommand(sorgu7, baglanti);
                cmd7.Parameters.AddWithValue("@departid", textDepid.Text);
                string depad = Convert.ToString(cmd7.ExecuteScalar());

                if (textDepad.Text != depad)
                {
                    MessageBox.Show("Departman adını güncelleyemezsiniz");
                }

                else if (perid == textYonetici.Text)
                {
                    MessageBox.Show("Bu kişi zaten bir departmanı yönetiyor");
                }

                else
                {
                    try
                    {
                        string sorgu = "update departman set departman_id=@departman_id,departman_ad=@departman_ad,yonetici_id=@yonetici_id where departman_id=@departman_id";
                        komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@departman_id", Convert.ToInt32(textDepid.Text));
                        komut.Parameters.AddWithValue("@departman_ad", textDepad.Text);
                        komut.Parameters.AddWithValue("@yonetici_id", textYonetici.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        Getir();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textDepid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textDepad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textYonetici.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textYonetici.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void ikDepartmanislem_Load(object sender, EventArgs e)
        {
            PersonelGetir();
            Getir();
        }

        private void textAra_TextChanged(object sender, EventArgs e)
        {
            Ara("Select personel_id as 'Personel id',personel_ad as 'Personel ad',personel_soyad 'Personel soyad' from personel where personel_ad like'" + textAra.Text + "%'");
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            istek istek = new istek();
            istek.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ikMenu ikMenu = new ikMenu();
            ikMenu.Show();
            this.Hide();
        }
    }
}
