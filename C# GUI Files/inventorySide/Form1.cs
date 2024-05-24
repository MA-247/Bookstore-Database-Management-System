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

namespace inventorySide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=192.168.43.181;Initial Catalog=Pro_Sat;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Book_Title FROM Books WHERE ISBN IN (SELECT ISBN FROM Books_Order WHERE Order_ID =  @Order_ID)", con);
            cmd.Parameters.AddWithValue("@Order_ID", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=192.168.43.181;Initial Catalog=Pro_Sat;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(Price) AS 'Total Bill' FROM Prices WHERE ISBN IN (SELECT ISBN FROM Books_Order WHERE Order_ID = @Order_ID)", con);
            cmd.Parameters.AddWithValue("@Order_ID", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=192.168.43.181;Initial Catalog=Pro_Sat;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand( "INSERT INTO Books VALUES (@ISBN, @Book_Title, @Publisher_ID, @Pages, @Genre)", con);
            cmd.Parameters.AddWithValue("@ISBN", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Book_Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Publisher_ID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Pages", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Genre", textBox5.Text);

            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=192.168.43.181;Initial Catalog=Pro_Sat;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Quantity", con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
