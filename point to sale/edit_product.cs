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
    public partial class edit_product : Form
    {
        public edit_product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {






        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_product_Load(object sender, EventArgs e)
        {


            textBox1.Text = Admin_Dashboard.val;

            SqlConnection sql = new SqlConnection(Admin.conn);
            string query = "select * from products WHERE Product_Id= ' " + textBox1.Text + " ' ";

            sql.Open();

            SqlCommand sd3 = new SqlCommand(query, sql);
            SqlDataReader dr = sd3.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = (dr["Name"].ToString());
                textBox3.Text = (dr["Price"].ToString());
                comboBox1.Text = (dr["Category"].ToString());
                textBox5.Text = (dr["Details"].ToString());
                textBox6.Text = (dr["Quantity"].ToString());
            }


            sql.Close();

            combofil();



        }



        public void combofil()
        {
            
            SqlConnection sql = new SqlConnection(Admin.conn);
            string qury3 = "select * from category";
            sql.Open();

            SqlCommand sd5 = new SqlCommand(qury3, sql);
            SqlDataReader dr2 = sd5.ExecuteReader();

            while (dr2.Read())
            {
                string dg = (dr2["Name"].ToString());
                comboBox1.Items.Add(dg);

            }

            sql.Close();

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {




            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Information", "Boxes are empty!");
            }


            else
            {


                if (int.Parse(textBox6.Text) < 0) MessageBox.Show("Quentity cannot be negative");


                else
                {
                    SqlConnection sql = new SqlConnection(Admin.conn);
                    string query = "UPDATE products SET Name='" + textBox2.Text + "',Price='" + textBox3.Text + "',Quantity='" + textBox6.Text + "',Category='" + comboBox1.Text + "',Details='" + textBox5.Text + "'WHERE Product_Id='" + textBox1.Text + "'";

                    sql.Open();

                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();

                    MessageBox.Show("Your Product has been Updated", "Congratulations");

                    this.Close();


                }

            }





        }
    }

}
