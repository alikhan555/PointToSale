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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();

            datacat();


        }


        public void datacat()
        {


            SqlConnection sql = new SqlConnection(Admin.conn);
            string qry = "select * from category";
            sql.Open();

            SqlDataAdapter dd = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            dd.Fill(dt);
            dataGridView1.DataSource = dt;

            sql.Close();

        }









        private void Category_Load(object sender, EventArgs e)
        {

           



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();



        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text=="")
            {
                MessageBox.Show("plz enter some valid information");
            }



            else{
                SqlConnection sql = new SqlConnection(Admin.conn);
                string qry = "insert into category (Name) VALUES(' " + textBox1.Text + " ') ";
                sql.Open();
                SqlCommand cs = new SqlCommand(qry, sql);
                cs.ExecuteNonQuery();

                sql.Close();

                
                this.Close();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text=="")
            {
                button1.Enabled = false;
                
            }


            else{

                SqlConnection sql = new SqlConnection(Admin.conn);
                string qry = "DELETE FROM Category WHERE Id=' " + textBox2.Text + "   ' ";
                string qry23 = "DELETE FROM products WHERE Category=' " + textBox1.Text + "   ' ";
                sql.Open();
                SqlCommand cs = new SqlCommand(qry, sql);

                cs.ExecuteNonQuery();



                sql.Close();


                sql.Open();

                SqlCommand cs23 = new SqlCommand(qry23, sql);

                cs23.ExecuteNonQuery();

                sql.Close();
                MessageBox.Show("Record Deleted Successfully");
                this.Close();


            }








        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text =  dataGridView1.SelectedRows[0].Cells[1].Value.ToString()    ;




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
