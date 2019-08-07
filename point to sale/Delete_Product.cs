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
    public partial class Delete_Product : Form
    {
        public Delete_Product()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Delete_Product_Load(object sender, EventArgs e)
        {

            label2.Text = Admin_Dashboard.ide; 
           
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = Admin_Dashboard.ide;

            Admin Admin = new Admin();
            string g = Admin.conn;
            SqlConnection sql = new SqlConnection(g);
            string qry = "DELETE FROM products WHERE Product_Id=' " + label2.Text + " ' ";
            sql.Open();

            SqlCommand sd4 = new SqlCommand(qry,sql);
            sd4.ExecuteNonQuery();

            
            sql.Close();

              
            this.Close();
            

            MessageBox.Show("Record deleted successfully");
            

        }
    }
}
