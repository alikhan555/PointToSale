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
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();

            dtform();




        }


        DataTable dt = new DataTable();

        public void dtform()
        {
            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string qury = "select * from SalesData  Order By SalesId DESC";
            SqlDataAdapter swd = new SqlDataAdapter(qury, sql);
            swd.Fill(dt);
            dataGridView1.DataSource = dt;
            sql.Close();


        }





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

           

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void search_OnValueChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = "Name Like '%" + search.Text + "%'" + 
                "OR Convert(SalesId,'System.String') Like '" + search.Text + "'"
                ;





        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

            DataView dv = dt.DefaultView;
            dv.RowFilter = "Date Like '" +  datepk.Value.ToShortDateString()  +"%'";





        }

        private void button1_Click(object sender, EventArgs e)
        {
           



        }


        Bitmap bmp;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(bmp, 0, 0);





        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            int height = dataGridView1.Height;
            int width = dataGridView1.Width;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();






        }

        private void orders_Load(object sender, EventArgs e)
        {


            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string query = "select * from info";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string header = (dr["Name"].ToString());
                title.Text = header;
            }



            sql.Close();



        }
    }
}
