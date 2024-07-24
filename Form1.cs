using Microsoft.Data.SqlClient;

namespace singinupandlogin
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

         }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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

            }

            catch (Exception ex)
            {
                MessageBox.Show("An Error Occur" + ex);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection zain = new SqlConnection("Data Source=DESKTOP-PD7G7PD\\SQLEXPRESS;Initial Catalog=loginandsingup;Integrated Security=True;Trust Server Certificate=True");
            try
            {
                string userdata = textBox5.Text;
                string passworddat = textBox6.Text;
                string query = "SELECT COUNT(1) FROM singup WHERE username = @userdata AND password_p = @passworddat";
                using (SqlCommand cmmd = new SqlCommand(query, zain))
                {

                    zain.Open();
                    cmmd.Parameters.AddWithValue("@userdata", userdata);
                    cmmd.Parameters.AddWithValue("@passworddat", passworddat);
                    int count = Convert.ToInt32(cmmd.ExecuteScalar());

                    if (count == 1)
                    {
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    zain.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Erorr Occur" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                string uname = textBox3.Text;
                using (SqlConnection cnn = new SqlConnection(Settings.ConnectionString))
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