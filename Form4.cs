using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace singinupandlogin
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
      private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("blanks are not allowed");
                    return;
                }
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PD7G7PD\\SQLEXPRESS;Initial Catalog=loginandsingup;Integrated Security=True;Trust Server Certificate=True");
                con.Open();
                string MM = textBox1.Text;
                string NN = textBox2.Text;
                string SS = textBox3.Text;
                string TT = textBox4.Text;
                string q = "insert into singup(firstname,lastname,username,password_p) values(@MM,@NN,@SS,@TT)";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@MM", MM);
                    cmd.Parameters.AddWithValue("@NN", NN);
                    cmd.Parameters.AddWithValue("@SS", SS);
                    cmd.Parameters.AddWithValue("@TT", TT);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Account created successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An Error occur", ex.Message);

            }
        }
     private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                string uname = textBox3.Text;
                using (SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-PD7G7PD\\SQLEXPRESS;Initial Catalog=loginandsingup;Integrated Security=True;Trust Server Certificate=True"))
                {
                    string query = "SELECT * FROM singup WHERE username = @username";
                    using (SqlCommand cs = new SqlCommand(query, cnn))
                    {
                        cs.Parameters.AddWithValue("@username", uname);
                        cnn.Open();
                        using (SqlDataReader dr = cs.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                MessageBox.Show("This username already exists!");
                            }
                            else
                            {
                                textBox4.Enabled = true;
                                textBox4.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
    }
}
