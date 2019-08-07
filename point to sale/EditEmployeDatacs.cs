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
    public partial class EditEmployeDatacs : Form
    {
        SqlConnection con = new SqlConnection(Admin.conn);
        string imgloc = "";


        public EditEmployeDatacs(string index)
        {
            InitializeComponent();


            employeeIDtext.Text = index;


            SqlCommand Command;
            string query = "SELECT EmployeeId,Name,FatherName,Gender,Photo,Address,ContactNo,DateOfBirth,password FROM EmployeeData WHERE EmployeeId='" + index + "'   ";   //id=index

            try
            {
                con.Open();
                Command = new SqlCommand(query, con);
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                //  idtextbox.Text = reader[0].ToString();
                nametext.Text = reader[1].ToString();
                fathernametext.Text = reader[2].ToString();
                genderCombo.Text = reader[3].ToString();
                addresstext.Text = reader[5].ToString();
                contacttext.Text = reader[6].ToString();
                dob.Text = reader[7].ToString();
                passtext.Text = reader[8].ToString();

                byte[] img = (byte[])(reader[4]);
                MemoryStream ms = new MemoryStream(img);
                pictureBox2.Image = Image.FromStream(ms);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            employee em = new employee();
            em.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (employeeIDtext.Text == "" || nametext.Text == "" || fathernametext.Text == "" || pictureBox2.Image == null || addresstext.Text == "" || contacttext.Text == "" || passtext.Text == "" || genderCombo.Text == "")
            {
                MessageBox.Show("Please fill the form Completely");
            }
            else
            {
                if (imgloc == "") MessageBox.Show("Yout must select new Picture");
                else
                {
                     /*
                     
                    byte[] img = null;
                    FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);


                    string query = "UPDATE EmployeeData SET Name='" + nametext.Text + "' , FatherName='" + fathernametext.Text + "' , Gender='" + genderCombo.Text + "' , Address='" + addresstext.Text + "' , ContactNo='" + contacttext.Text + "' , DateOfBirth='" + dob.Text + "' , Photo=@img    WHERE EmployeeId='" + employeeIDtext.Text + "'";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        SqlCommand Command = new SqlCommand(query, con);
                        Command.Parameters.Add(new SqlParameter("@img", img));
                        Command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data Updated successfully");
                    }
                    else
                    {
                        con.Close();
                    }
                    //EmployeeId='" + employeeIDtext.Text + "' 
                    */


                    try
                    {
                        byte[] img = null;
                        FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        img = br.ReadBytes((int)fs.Length);


                        string query = "UPDATE EmployeeData SET Name='" + nametext.Text + "' , FatherName='" + fathernametext.Text + "' , Gender='" + genderCombo.Text + "' , Address='" + addresstext.Text + "' , ContactNo='" + contacttext.Text + "' , Password='" + passtext.Text + "'   , DateOfBirth='" + dob.Text + "' , Photo=@img    WHERE EmployeeId='" + employeeIDtext.Text + "'";
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                            SqlCommand Command = new SqlCommand(query, con);
                            Command.Parameters.Add(new SqlParameter("@img", img));
                            Command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Data Updated successfully");
                        }
                        else
                        {
                            con.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgloc = ofd.FileName.ToString();
                pictureBox2.ImageLocation = imgloc;
            }
        }
    }
}
