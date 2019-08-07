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
    public partial class Admin : Form
    {



        public Admin()
        {
            InitializeComponent();
            
        }

        public static string conn = @"Data Source=ABDULMUJEEB-PC\SQLEXPRESS;Initial Catalog=point2sale;Integrated Security=True";



        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }








        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }









   

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {



           






        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {


          




            








        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {


            if (text1.Text == "admin" && text2.Text == "admin")
            {
                Admin_Dashboard admindash = new Admin_Dashboard();
                this.Hide();
                admindash.Show();
            }

            

        



else if (text1.Text != "admin")
            {




                SqlConnection sql = new SqlConnection(conn);
                sql.Open();
                string query = "select * from EmployeeData where Name = '" + text1.Text + "' and Password='" + text2.Text + "' ";

                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows == true)
                {
                    this.Hide();

                    Employee_Dashboard dash = new Employee_Dashboard();
                    dash.Show();


                }



                else
                {

                    MessageBox.Show("Enter Correct username & Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   


                }








            }



            else
            {


                MessageBox.Show("Enter Correct username & Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }





        }
    }
}
