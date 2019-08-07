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
    public partial class add_product : Form
    {
        public add_product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Information","Boxes are empty!");
            }

            else
            {
                Admin Admin = new Admin();
                string g = Admin.conn;
                SqlConnection sql = new SqlConnection(g);
                string qry = @"insert into products (Product_Id,Name,Price,Quantity,Category,Details)  VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                sql.Open();
                SqlCommand sd = new SqlCommand(qry, sql);
                sd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Your Product has been added successfully", "Added Product");
                this.Close();                    
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_product_Load(object sender, EventArgs e)
        {
            comboboxfil();
        }


        protected void comboboxfil()
        {
            
            string qury = "select (Name) from category ";
            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            SqlCommand sd4 = new SqlCommand(qury, sql);
            SqlDataReader dr = sd4.ExecuteReader();

            while (dr.Read())
            {
                string s = (dr["Name"].ToString());

                comboBox1.Items.Add(s);

            }
            sql.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            SqlConnection sql = new SqlConnection(Admin.conn);
            string query5 = "insert into category (Name) VALUES('" + textBox4.Text + "')";

            sql.Open();

            SqlCommand sd = new SqlCommand(query5, sql);
            sd.ExecuteNonQuery();

            sql.Close();

            MessageBox.Show("Category added Successfully","Cogratulations");

            this.Close();




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please Enter Information", "Boxes are empty!");
            }
            else
            {

                if (int.Parse(textBox6.Text) < 0) MessageBox.Show("Quentity cannot be negative");

                else 
                {

                    var date = DateTime.Now;

                    var dt = date.ToString("MM/dd/yyyy");


                    SqlConnection sql = new SqlConnection(Admin.conn);
                    string qry = @"insert into products  (Product_Id,Name,Price,Quantity,Category,Details,Date)  VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + dt + "')";
                    sql.Open();
                    SqlCommand sd = new SqlCommand(qry, sql);
                    sd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Your Product has been added successfully", "Added Product");
                    this.Close();

                    Admin_Dashboard ad = new Admin_Dashboard();
                    ad.Refresh();
                }

           //     Refresh();          //changing




            }
        }
    }
}
