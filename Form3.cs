using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace singinupandlogin
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
         private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connection = "Data Source=DESKTOP-PD7G7PD\\SQLEXPRESS;Initial Catalog=loginandsingup;Integrated Security=True;Trust Server Certificate=True";

                using (SqlConnection zain2 = new SqlConnection(connection))
                {
                    zain2.Open();

                    string delete_username = textBox1.Text;
                    if (delete_username.IsNullOrEmpty())
                    {
                        MessageBox.Show("please Enter username");
                        return;
                    }
                    string checkQuery = "SELECT COUNT(*) FROM singup WHERE username = @Username";

                    {
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, zain2))
                        {
                            checkCmd.Parameters.AddWithValue("@Username", delete_username);
                            int userCount = (int)checkCmd.ExecuteScalar();

                            if (userCount == 0)
                            {
                                MessageBox.Show("User not available");
                            }
                            else
                            {
                                string z = "delete from singup where username = '" + delete_username + "';";
                               SqlCommand cmd = new SqlCommand(z, zain2);
                                var reader = cmd.ExecuteReader();
                                DataTable table = new DataTable();
                                table.Load(reader);
                                MessageBox.Show("data delete succefully");
                            }
                            Form2 f2 = new Form2();
                            f2.Show();
                            this.Hide();
                            zain2.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}

