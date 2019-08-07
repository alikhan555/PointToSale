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

namespace point_to_sale
{
    public partial class notifications : Form
    {
        public notifications()
        {
            InitializeComponent();

            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string qry = "select * from products Where Quantity<30 ";
            SqlDataAdapter apd = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            apd.Fill(dt);
            dataGridView1.DataSource = dt;

            sql.Close();

            dataGridView1.Columns[0].Width= 70;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 75;
            dataGridView1.Columns[5].Width = 131;
            dataGridView1.Columns[6].Width = 75;
        }
    }
}
