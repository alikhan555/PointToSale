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
    public partial class Admin_Dashboard : Form
    {
      
        public static string val;

        public Admin_Dashboard()
        {

            InitializeComponent();
        }

        DataTable dt = new DataTable();
        
        public void datagridform()
        {
        
            Admin Admin = new Admin();
            string conn = Admin.conn;
            
            SqlConnection sql = new SqlConnection(conn);

            string query3 = "select * from products";
            sql.Open();
            SqlDataAdapter sd = new SqlDataAdapter(query3, sql);
            
            sd.Fill(dt);

            dataGridView1.DataSource = dt;

            sql.Close();

        }
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState =  FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel5_MouseClick(object sender, MouseEventArgs e)
        {
           
            employee emp = new employee();
            emp.Show();
               
        }

        public void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            
            countproducts();
            countcost();
         


            datagridform();

            countemp();
            

        }




        public void countemp()
        {

            Admin admin = new Admin();
            string gg = Admin.conn;
            SqlConnection sql = new SqlConnection(gg);
            string qury = "select count(*) FROM EmployeeData";
            sql.Open();
            SqlCommand sd = new SqlCommand(qury, sql);
            object count = sd.ExecuteScalar();
            if (count != null)
            {
                label5.Text = count.ToString();
            }

            sql.Close();
        }
        
        public void countcost()
        {
            
            SqlConnection sql = new SqlConnection(Admin.conn);
            string qury = "select sum(Price * Quantity) FROM products";
            sql.Open();
            SqlCommand sd = new SqlCommand(qury, sql);
            object  count = sd.ExecuteScalar();
            if (count != null)
            {
                label11.Text = count.ToString();
            }

        }

        
        public void countproducts()
        {

            Admin admin = new Admin();
            string gg = Admin.conn;
            SqlConnection sql = new SqlConnection(gg);
            string qury = "select count(*) FROM products";
            sql.Open();
            SqlCommand sd = new SqlCommand(qury, sql);
            object count = sd.ExecuteScalar();
            if (count != null)
            {
                label4.Text = count.ToString();
            }
            
            sql.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            add_product product = new add_product();
            product.ShowDialog();

            refresh();  //changing;


            

            
        }

        public static string ide;


        private void button3_Click(object sender, EventArgs e)
        {
           

                ide = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Delete_Product del = new Delete_Product();
                del.ShowDialog();

            refresh();   //  chinging


            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            val = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            edit_product edit = new edit_product();
           
            edit.ShowDialog();

            refresh();   // changing
        }

        private void label4_Click(object sender, EventArgs e)
        {



        }

        private void button4_Click(object sender, EventArgs e)
        {
            datagridform();
            countproducts();

        }

       
        private void label8_Click(object sender, EventArgs e)
        {

            this.Hide();

            employee emp = new employee();
            emp.Show();

           

        }

        private void Admin_Dashboard_Click(object sender, EventArgs e)
        {
            
          




        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();
            this.Hide();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            





        }

        private void button10_Click(object sender, EventArgs e)
        {
            bkup_db imp = new bkup_db();
            imp.Show();



        }

        private void button12_Click(object sender, EventArgs e)
        {
            refresh();
        }


      

        private void search_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Name  Like '%" + search.Text + "%'" + " OR Category Like '%" + search.Text + "%'"
                

                ;



        }

        

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

           


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;

           
          

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

            employee emp = new employee();
            emp.Show();
            this.Hide();

            
        }

        private void importExportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bkup_db h = new bkup_db();
            h.Show();


        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddNewEmployee add = new AddNewEmployee();
            add.Show();


        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            employee emp = new employee();
            emp.Show();


        }

        private void search_OnValueChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = "Name Like '%" + search.Text + "%'"
               +  "OR Convert(Product_Id,'System.String') Like '%" + search.Text + "'"
           
                ;





        }

        private void date_onValueChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = "Date Like '%" + date.Value.ToShortDateString()  +"%'";


        }

        Bitmap bmp;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage( bmp,0,0);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            int width = dataGridView1.Width;
            bmp = new Bitmap(width, height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0,0,width,height));
            printPreviewDialog1.ShowDialog();



        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Software Was Designed and Created By Abdul Mujeeb & Muhammad Ali","About ");
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            notifications noti = new notifications();
            noti.Show();
           


        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void setingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings setting = new settings();
            setting.Show();
        }

        public void refresh()
        {
            

            string conn = Admin.conn;
            dt.Clear();
            SqlConnection sql = new SqlConnection(conn);

            string query3 = "select * from products";
            sql.Open();
            SqlDataAdapter sd = new SqlDataAdapter(query3, sql);

            sd.Fill(dt);

            dataGridView1.DataSource = dt;

            sql.Close();
        }
    }
}
