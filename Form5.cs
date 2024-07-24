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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PD7G7PD\\SQLEXPRESS;Initial Catalog=loginandsingup;Integrated Security=True;Trust Server Certificate=True");
                con.Open();
                string MM = textBox1.Text;
                string NN = textBox2.Text;
                string SS = textBox3.Text;
                string TT = textBox4.Text;
                string q = "UPDATE singup SET firstname = @MM, lastname = @NN,password_p = @TT where username = @SS;";
                using (SqlCommand cm = new SqlCommand(q, con))
                {
                    cm.Parameters.AddWithValue("MM", MM);
                    cm.Parameters.AddWithValue("NN", NN);
                    cm.Parameters.AddWithValue("@TT", TT);
                    cm.Parameters.AddWithValue("@SS", SS);

                    cm.ExecuteNonQuery();
                    MessageBox.Show("user data updated");
                    this.Close();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var f2= new Form2();
            f2.Show();
            this.Close();
        }
    }
}
