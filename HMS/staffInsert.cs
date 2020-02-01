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

namespace HMS
{
    public partial class staffInsert : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public staffInsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInserstaff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staff_name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@staff_gender", SqlDbType.VarChar).Value = comboBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@staff_designation", SqlDbType.Int).Value = textBox2.Text.Trim();
                cmd.Parameters.AddWithValue("@staff_salary", SqlDbType.BigInt).Value = textBox3.Text.Trim();
                cmd.Parameters.AddWithValue("@staff_age", SqlDbType.Int).Value = textBox4.Text.Trim();
                cmd.Parameters.AddWithValue("@staff_contact", SqlDbType.Int).Value = textBox5.Text.Trim();
                cmd.Parameters.AddWithValue("@department_id", SqlDbType.Int).Value = textBox7.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Member Added successfully");
            }

            catch
            {
                MessageBox.Show("You Entered some wrong values");
            }
        

        }

        private void staffInsert_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
