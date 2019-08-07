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
    public partial class AddNewEmployee : Form
    {

       

        SqlConnection con = new SqlConnection(Admin.conn);
        SqlCommand Command;
        string imgloc;
        public AddNewEmployee()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files(*.gif)|*.gif";
                ofd.Title = "Select Employee Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgloc = ofd.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /*
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        */


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (employeeIDtext.Text == "" || nametext.Text == "" || fathernametext.Text == "" || pictureBox1.Image == null || addresstext.Text == "" || contacttext.Text == "" || passtext.Text == "" || genderCombo.Text == "")
            {
                MessageBox.Show("Please fill the form Completely");
            }
            else
            {

                byte[] img = null;
                FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string query = "INSERT INTO EmployeeData(EmployeeId, Name, FatherName, Gender, Photo, Address, ContactNo, Password, DateOfBirth) VALUES('" + employeeIDtext.Text + "', '" + nametext.Text + "','" + fathernametext.Text + "','" + genderCombo.Text + "', @img, '" + addresstext.Text + "','" + contacttext.Text + "','" + passtext.Text + "','" + this.dob.Text + "' )";
                
                try
                {
                    con.Open();
                    Command = new SqlCommand(query, con);
                    Command.Parameters.Add(new SqlParameter("@img", img));
                    Command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data saved successfully");

                    employeeIDtext.Clear();
                    nametext.Clear();
                    fathernametext.Clear();
                    //genderCombo.Text.se;           how to reset combobox value
                    pictureBox1.Image = null;
                    addresstext.Clear();
                    contacttext.Clear();
                    passtext.Clear();
                    dob.ResetText();
                }
                catch(Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }






                /*



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    Command = new SqlCommand(query, con);
                    Command.Parameters.Add(new SqlParameter("@img", img));
                    Command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data saved successfully");

                    employeeIDtext.Clear();
                    nametext.Clear();
                    fathernametext.Clear();
                    //genderCombo.Text.se;           how to reset combobox value
                    pictureBox1.Image = null;
                    addresstext.Clear();
                    contacttext.Clear();
                    passtext.Clear();
                    dob.ResetText(); 
                    
                    
                                                      
                }
                else
                {
                    con.Close();
                }

    */



            }
        }
        
        
               

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            employee em = new employee();
            em.Show();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            employeeIDtext.Clear();
            nametext.Clear();
            fathernametext.Clear();
            //genderCombo.Text.se;           how to reset combobox value
            pictureBox1.Image = null;
            addresstext.Clear();
            contacttext.Clear();
            passtext.Clear();
            dob.ResetText();
        }
    }
}
