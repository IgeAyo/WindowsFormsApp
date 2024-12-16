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
using System.Runtime.Remoting.Contexts;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\Local; Initial Catalog = invoicedb; Integrated Security = True;");
            SqlCommand cnn = new SqlCommand("Select * from table1" ,conn);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\Local; Initial Catalog = invoicedb; Integrated Security = True;");
            conn.Open();
            SqlCommand cnn = new SqlCommand("insert into table1(clientname,productname,description,mobile,address,price,total) values(@clientname,@productname,@description,@mobile,@address,@price,@total) ", conn);
            cnn.Parameters.AddWithValue("@clientname", (textBox1.Text));
            cnn.Parameters.AddWithValue("@productname", (textBox2.Text));
            cnn.Parameters.AddWithValue("@description", (textBox3.Text));
            cnn.Parameters.AddWithValue("@mobile", (textBox7.Text));
            cnn.Parameters.AddWithValue("@address", (textBox6.Text));
            cnn.Parameters.AddWithValue("@price", (textBox5.Text));
            cnn.Parameters.AddWithValue("@total", (textBox4.Text));
            cnn.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data Successfully Added");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\Local; Initial Catalog = invoicedb; Integrated Security = True;");
            SqlCommand cnn = new SqlCommand("Select * from table1 where clientname = @clientname", conn);
            cnn.Parameters.AddWithValue("@clientname", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
