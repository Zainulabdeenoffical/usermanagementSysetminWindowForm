using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace singinupandlogin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
        
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         }
        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connection = "Data Source=DESKTOP-PD7G7PD\\SQLEXPRESS;Initial Catalog=loginandsingup;Integrated Security=True;Trust Server Certificate=True";
                using (SqlConnection zain2 = new SqlConnection(connection))
                {
                    zain2.Open();
                  string searchword = textBox1.Text;
                    if (searchword.IsNullOrEmpty())
                    {
                        MessageBox.Show("please Enter username");
                        return;
                    }
                    else
                    {
                        string query = "select * from singup where " +
                            "firstname like @SearchWord or lastname like @SearchWord or username like @SearchWord;";
                     using (SqlCommand cmd = new SqlCommand(query, zain2))
                        {
                            searchword = "%" + searchword + "%";
                            cmd.Parameters.AddWithValue("@SearchWord", searchword);
                            var reader = cmd.ExecuteReader();
                            DataTable table = new DataTable();
                            table.Load(reader);
                            dataGridView1.DataSource = table;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_VisibleChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            string connection = "Data Source=DESKTOP-PD7G7PD\\SQLEXPRESS;Initial Catalog=loginandsingup;Integrated Security=True;Trust Server Certificate=True";
            SqlConnection zain1 = new SqlConnection(connection);
            zain1.Open();
            string a = "select * from singup";
            SqlCommand cmd = new SqlCommand(a, zain1);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            zain1.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form5 f5 = new Form5();
            f5.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f5.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f5.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f5.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f5.ShowDialog();
             this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
    }
}
