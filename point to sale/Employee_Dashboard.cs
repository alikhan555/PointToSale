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
    public partial class Employee_Dashboard : Form
    {
        SqlConnection conn = new SqlConnection(Admin.conn);

   //     int total=0;
        

        DataTable dt = new DataTable();
        int dataindex;
        int total = 0;

        public Employee_Dashboard()
        {
            InitializeComponent();

            
            dt.Columns.Add("Product Id", typeof(string));
            dt.Columns.Add("Product Name", typeof(string));
            dt.Columns.Add("Rate", typeof(int));
            dt.Columns.Add("Quentity", typeof(string));
            dt.Columns.Add("Cost", typeof(int));
        }

     
        public void productslist() {

          SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query,sql);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                var g = (dr["Name"].ToString());
                combo1.Items.Add(g);
                
            }



            sql.Close();

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Employee_Dashboard_Click(object sender, EventArgs e)
        {

        }


        // Title of market store starts here  //
       
        public void titleofstore()
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

        // Title of market store Ends here //



        private void Employee_Dashboard_Load(object sender, EventArgs e)
        {


            // Title of store //
            titleofstore();
            
            //PRODUCTS LIST FROM DB
            productslist();

           // ORDER NO FROM DB 
            orderno();


        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void geneorder_Click(object sender, EventArgs e)
        {
            
            


        }

        // FUNCTION FOR GETTING CURRENT ORDER ID
        public void orderno(){
            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string qury = "select Max(SalesId)+1 from SalesData";
            SqlCommand cmd = new SqlCommand(qury, sql);
            object def = cmd.ExecuteScalar();

            if (def != null)
            {

                order_no.Text = def.ToString();
            }

            sql.Close();
        
        }


        // ORDER ID ENDS HERE






      



        private void button1_Click(object sender, EventArgs e)
        {

            
        }


        // TOTAL FUNCTION OF PRODUCTS STARTS HERE
        public void totalfunction()
        {
            total = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                total = total + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            label8.Text = "Rs " + total.ToString();
        }


        // TOTLA FUNCTION OF PRODUCTS ENDS HERE



        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            


        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }




        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {


            try
            {
                conn.Open();
                string query = "SELECT Product_Id,Name,Price,Quantity,Category,Details,Date FROM products WHERE Product_Id=" + productIdtext.Text + " ";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader SDR = command.ExecuteReader();
                SDR.Read();
                if (Convert.ToUInt16(quentitytext.Text) <= Convert.ToInt16(SDR[3]))
                {
                    //     serialno = serialno + 1;
                    dt.Rows.Add(/*serialno, */ SDR[0].ToString(), SDR[1].ToString(), SDR[2].ToString(), quentitytext.Text, (Convert.ToInt16(SDR[2].ToString()) * Convert.ToInt16(quentitytext.Text)));
                    dataGridView1.DataSource = dt;
                    productIdtext.Text = "";
                    quentitytext.Text = "";

                    



                }
                else
                {
                    MessageBox.Show("we have not available product to your required quentity");
                }
                conn.Close();
                totalfunction();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }








        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            dataindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(dataindex);
            totalfunction();




        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {


            try
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    conn.Open();
                    string proid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string query = "SELECT * From Products WHERE  Product_Id='" + proid + "' ";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader SDR = command.ExecuteReader();
                    SDR.Read();
                    int qu = int.Parse(SDR[3].ToString());
                    conn.Close();

                    conn.Open();
                    query = "UPDATE Products SET Quantity='" + (qu - int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString())) + "' WHERE Product_Id='" + proid + "'  ";
                    SqlCommand command2 = new SqlCommand(query, conn);
                    command2.ExecuteNonQuery();
                    conn.Close();
                }

                {
                    string[] ProNo = { "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A" };
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        ProNo[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    }




                    var datetime = DateTime.Now; 
                    var date = datetime.ToShortDateString();
                    var time = datetime.ToShortTimeString();




                    string query = "INSERT INTO SalesData(Name,Date,Time,TotalCost,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10) VALUES( '" + name.Text + "',   '" +  date + "','" + time + "', '" + label8.Text + "', '" + ProNo[0] + "','" + ProNo[1] + "','" + ProNo[2] + "','" + ProNo[3] + "','" + ProNo[4] + "','" + ProNo[5] + "','" + ProNo[6] + "','" + ProNo[7] + "','" + ProNo[8] + "','" + ProNo[9] + "' )";
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }

               
                dt.Clear();
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }


            /*  printing form code   */













        }


        







        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

            





        }

        private void button2_Click_1(object sender, EventArgs e)
        {


           


        }

        private void bunifuThinButton22_Click_2(object sender, EventArgs e)
        {


          



        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
       
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string query = "select * from info";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            
            // Store Info Change from settings in admin panel  
               Name = dr[0].ToString(); string address = (dr["Address"].ToString());
                string phone = (dr["Phone"].ToString()); string mobile = (dr["Mobile"].ToString());
                string email = (dr["Email"].ToString()); string web = (dr["Website"].ToString());

            // Name to upper string ;
            Name.ToUpper();

            var g = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ";

                e.Graphics.DrawString(Name, new Font("Arial", 30, FontStyle.Bold), Brushes.Tomato, new Point(50, 100));


                e.Graphics.DrawString("Address : " + address, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(160, 180));
                e.Graphics.DrawString("Phone No : " + phone , new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(80, 210));
                e.Graphics.DrawString("Mobile No : " + mobile, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(420, 210));
                e.Graphics.DrawString("Email : " + email, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(80, 240));
                e.Graphics.DrawString("Website : " + web , new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(420, 240));




            sql.Close();




            e.Graphics.DrawString("Order Id : ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(90, 300));
            e.Graphics.DrawString(Orderno, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(230, 300));

            e.Graphics.DrawString("Customer Name : ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(370, 300));
            e.Graphics.DrawString(Ordername, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(560, 300));


            e.Graphics.DrawString(g + "- - - - - - - - - - - - - - - - - - - - - - - ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 360));


            e.Graphics.DrawString("Item Description", new Font("Arial", 13, FontStyle.Bold), Brushes.Black, new Point(70,385 ));
            e.Graphics.DrawString("Quantity", new Font("Arial", 13, FontStyle.Bold), Brushes.Black, new Point(400, 385));
            e.Graphics.DrawString("Price", new Font("Arial", 13, FontStyle.Bold), Brushes.Black, new Point(630, 385));


            e.Graphics.DrawString(g + "- - - - - - - - - - - - - - - - - - - - - - - ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 410));

            // ORDERS DESCRIPTION STARTS HERE 


            int j = 435;   /* top position of items row */

            /* items Name */
            for (int k = 0; k < datarowcount; k++)
            {
                e.Graphics.DrawString(Employee_Dashboard.Proname[k], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(70,j+(k*32)));
                

            }

            
            /* Items Quantity */

            for (int k = 0; k < datarowcount; k++)
            {
                e.Graphics.DrawString(quantity[k], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(420, j + (k * 32)));


            }

            /* Items Price */

            for (int k = 0; k < datarowcount; k++)
            {
                e.Graphics.DrawString(price[k], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(650, j + (k * 32)));


            }


            // ORDERS DESCRIPTION ENDS HERE 

            //total Payment footer 

            e.Graphics.DrawString(g + "- - - - - - - - - - - - - - - - - - - - - - - ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 900));
            e.Graphics.DrawString("Total Payment", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(70, 925));
            e.Graphics.DrawString(Ordertotlal, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(630, 925));
            e.Graphics.DrawString(g + "- - - - - - - - - - - - - - - - - - - - - - - ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 950));



        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();



        }

        private void restartToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }


        


        private void button1_Click_1(object sender, EventArgs e)
        {

            if (int.Parse(quentitytext.Text) < 0) MessageBox.Show("Quentity can not be negative");

            else
            {


                for (int k = 0; k < dataGridView1.RowCount - 1; k++)
                {
                    Proname[k] = dataGridView1.Rows[0].Cells[0].Value.ToString();

                }



                try
                {
                    conn.Open();
                    string query = "SELECT Product_Id,Name,Price,Quantity,Category,Details,Date FROM products WHERE Product_Id=" + productIdtext.Text + " ";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader SDR = command.ExecuteReader();
                    SDR.Read();
                    if (Convert.ToUInt16(quentitytext.Text) <= Convert.ToInt16(SDR[3]))
                    {
                        //     serialno = serialno + 1;
                        dt.Rows.Add(/*serialno, */ SDR[0].ToString(), SDR[1].ToString(), SDR[2].ToString(), quentitytext.Text, (Convert.ToInt16(SDR[2].ToString()) * Convert.ToInt16(quentitytext.Text)));
                        dataGridView1.DataSource = dt;
                        productIdtext.Text = "";
                        quentitytext.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("we have not available product to your required quentity");
                    }
                    conn.Close();
                    totalfunction();

                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            dataindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(dataindex);
            totalfunction();

        }




        public string Orderno;
        public string Ordername;
        public string Ordertotlal;
        public static string[] Proname = new string[10]; public static string[] quantity = new string[10]; public static string[] price = new string[10];
        public static int datarowcount;




        private void button4_Click(object sender, EventArgs e)
        {
            /* Order names  Values pass for printing */

            datarowcount = dataGridView1.RowCount-1 ;
            for (int k = 0; k < dataGridView1.RowCount - 1 ; k++)
            {
                Proname[k] = dataGridView1.Rows[k].Cells[1].Value.ToString();

            }

            /* Quantity  Values pass for printing */

            for (int k = 0; k < dataGridView1.RowCount - 1; k++)
            {
                quantity[k] = dataGridView1.Rows[k].Cells[3].Value.ToString();

            }


            /* Price  Values pass for printing */

            for (int k = 0; k < dataGridView1.RowCount - 1; k++)
            {
                price[k] = dataGridView1.Rows[k].Cells[2].Value.ToString();

            }




            




            Orderno = order_no.Text;
            Ordername = name.Text;
            Ordertotlal = label8.Text;



            if (order_no.Text == "" || name.Text == "")
            {

                MessageBox.Show("Please Enter Order Name & Id");

            }






            else
           { 

                




                try
                {
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        conn.Open();
                        string proid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        string query = "SELECT * From Products WHERE  Product_Id='" + proid + "' ";
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader SDR = command.ExecuteReader();
                        SDR.Read();
                        int qu = int.Parse(SDR[3].ToString());
                        conn.Close();

                        conn.Open();
                        query = "UPDATE Products SET Quantity='" + (qu - int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString())) + "' WHERE Product_Id='" + proid + "'  ";
                        SqlCommand command2 = new SqlCommand(query, conn);
                        command2.ExecuteNonQuery();
                        conn.Close();
                    }

                    {
                        string[] ProNo = { "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A", "n/A" };
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            ProNo[i] = dataGridView1.Rows[i].Cells[0].Value.ToString() + "(" +dataGridView1.Rows[i].Cells[3].Value.ToString() + ")";
                        }


                        var datetime = DateTime.Now;
                        var date = datetime.ToShortDateString();
                        var time = datetime.ToShortTimeString();




                        string query = "INSERT INTO SalesData(Name,Date,Time,TotalCost,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10) VALUES(  '" + name.Text + "',    '" + date + "','" + time + "', '" + label8.Text + "', '" + ProNo[0] + "','" + ProNo[1] + "','" + ProNo[2] + "','" + ProNo[3] + "','" + ProNo[4] + "','" + ProNo[5] + "','" + ProNo[6] + "','" + ProNo[7] + "','" + ProNo[8] + "','" + ProNo[9] + "' )";
                        conn.Open();
                        SqlCommand command = new SqlCommand(query, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                    }


                    dt.Clear();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
                /*  printing form code   */
                printPreviewDialog1.ShowDialog();

                /*   After closing printing form   */

                combo1.SelectedIndex = 0;
                name.Text = "";
                label8.Text = "0";
                orderno();
            }
        }
        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            
        }

        private void ordersListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ordersListToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            orders order = new orders();
            order.Show();


        }

        private void productIdtext_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string gf = combo1.SelectedItem.ToString();
            SqlConnection sql = new SqlConnection(Admin.conn);
            sql.Open();
            string query = "select * from products Where Name='" +  gf +"'";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                var id_product = (dr["Product_Id"].ToString());
                productIdtext.Text = id_product;

            }
            sql.Close();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            for (int k = 0; k < dataGridView1.RowCount - 1; k++)
            {
                Proname[k] = dataGridView1.Rows[k].Cells[1].Value.ToString();
            }
            test tets = new test();
            tets.Show();

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
