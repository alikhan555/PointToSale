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
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void settings_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(Admin.conn);
            string query5 = "select * from info";
            sql.Open();
            SqlCommand cmd = new SqlCommand(query5, sql);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text = (dr["Name"].ToString()); textBox2.Text = (dr["Phone"].ToString());
                textBox3.Text = (dr["Mobile"].ToString()); textBox4.Text = (dr["Email"].ToString());
                textBox5.Text = (dr["Website"].ToString()); textBox6.Text = (dr["Address"].ToString());


            }



            sql.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string query5 = "Update info SET Name=' " + textBox1.Text + "'  ,  Phone=' " + textBox2.Text + "'  ,  Mobile=' " + textBox3.Text + "'  ,  Email=' " + textBox4.Text + "'  , Website=' " + textBox5.Text + "'  ,  Address=' " + textBox6.Text + "'   ";
            SqlCommand cmd = new SqlCommand(query5,sql);
            cmd.ExecuteNonQuery();


            sql.Close();

            MessageBox.Show("Successfully save your settings ");
            this.Refresh();


        }
    }
}
