using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace LoginDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["LoginDesktop"].ToString();
            conn.Open();
            string user = textBox1.Text;
            string pass = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select CodUser from SystemUsers where Username = @Name and TxtPassword = @Pass", conn);
            cmd.Parameters.Add(new SqlParameter("Name", user));
            cmd.Parameters.Add(new SqlParameter("Pass", pass));

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show("Log In successful!");
                return;
            }
            MessageBox.Show("You could not Log In!");
        }
    }
}
