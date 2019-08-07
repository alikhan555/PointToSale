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
using System.IO;

namespace point_to_sale
{
    public partial class employee : Form
    {



        SqlConnection con = new SqlConnection(Admin.conn);


        string index = "";
        SqlCommand command;
        public employee()
        {
            InitializeComponent();
            refresh();

            //dataGridView1.AutoResizeColumns();           


            




            /*

            try
            {
                conn.Open();
                string query = "SELECT * FROM EmployeeData";
                SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
                SDA.SelectCommand.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                viewemployee.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Admin_Dashboard admin = new Admin_Dashboard();
            admin.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            try
            {
                con.Open();
                string query = "SELECT  EmployeeId,Name,FatherName,Gender,Address,ContactNo,DateOfBirth FROM EmployeeData";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                
                button2.Enabled = false;
                button3.Enabled = false;

                emIdLabel.Text = "N/A";
                nameLabel.Text = "N/A";
                GenderLabel.Text = "N/A";
                pictureBox2.Image = null;

                dataGridView1.Columns[0].Width = 78;
                dataGridView1.Columns[1].Width = 135;
                dataGridView1.Columns[2].Width = 135;
                dataGridView1.Columns[3].Width = 65;
                dataGridView1.Columns[4].Width = 235;
                dataGridView1.Columns[5].Width = 102;
                dataGridView1.Columns[6].Width = 81;
                
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AddNewEmployee ade = new AddNewEmployee();
            ade.ShowDialog();
            refresh();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            index = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


            if (index != "")
            {
                button2.Enabled = true;
                button3.Enabled = true;

                try
                {

                    con.Open();
                    string query = "SELECT * FROM EmployeeData WHERE EmployeeId='" + index + "'";
                    command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    emIdLabel.Text = reader[0].ToString();
                    nameLabel.Text = reader[1].ToString();
                    GenderLabel.Text = reader[3].ToString();


                    byte[] img = (byte[])(reader[4]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox2.Image = Image.FromStream(ms);
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            EditEmployeDatacs eed = new EditEmployeDatacs(index);
            eed.ShowDialog();
            refresh();                 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE EmployeeData WHERE EmployeeId='" + index + "'";

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this employee's record?", "Delete Record", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();

                    command = new SqlCommand(query, con);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been removed successfully");
                    refresh();
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }           
            }
            catch (Exception ex)
            {
                con.Close();            
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string combocol = "";

            if (searchtext.Text!="" || searchcol.Text!="")
            {
                switch (searchcol.Text)
                {
                    case "Employee Id":
                        {
                            combocol = "EmployeeId";
                            break;
                        }
                    case "Name":
                        {
                            combocol = "Name";
                            break;
                        }
                    case "Father's Name":
                        {
                            combocol = "FatherName";
                            break;
                        }
                    case "Gender":
                        {
                            combocol = "Gender";
                            break;
                        }
                    case "Address":
                        {
                            combocol = "Address";
                            break;
                        }
                    case "Contact No.":
                        {
                            combocol = "ContactNo";
                            break;
                        }
                    case "Date Of Birth":
                        {
                            combocol = "DateOfBirth";
                            break;
                        }
                }
            }

            string query = "SELECT EmployeeId,Name,FatherName,Gender,Address,ContactNo,DateOfBirth FROM EmployeeData WHERE " + combocol + "='" + searchtext.Text + "' ";

            try
            {
                con.Open();
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();

                dataGridView1.DataSource = null;
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void employee_Click(object sender, EventArgs e)
        {
          
            EditEmployeDatacs employee = new EditEmployeDatacs(index);
            employee.Hide();

        }
    }
}
