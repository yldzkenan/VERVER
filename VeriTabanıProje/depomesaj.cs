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
using System.Collections;

namespace VeriTabanıProje
{
    public partial class depomesaj : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=USER11\\SQLEXPRESS;Initial Catalog=fabrikavt;Integrated Security=True;MultipleActiveResultSets=True;");
        public depomesaj()
        {
            InitializeComponent();
        }

        private void depomesaj_Load(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();

            SqlDataAdapter dAdapter = new SqlDataAdapter("SELECT departman_ad,ileti FROM Istek WHERE departman_id=(select departman_id from departman where departman_ad='Depo')", baglanti);
            {
                dAdapter.Fill(dTable);
            }
            dataGridView1.DataSource = dTable;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
