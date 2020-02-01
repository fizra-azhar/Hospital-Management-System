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
    public partial class Doctors2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public Doctors2()
        {
            InitializeComponent();
            display();
        }
        private void display()
        {
            con.Open();
            DataTable sp1 = new DataTable();
            adapter = new SqlDataAdapter("exec sp1", con);
            adapter.Fill(sp1);

            con.Close();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertdoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@doctor_name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@doctor_specialization", SqlDbType.VarChar).Value = textBox2.Text.Trim();
                cmd.Parameters.AddWithValue("@doctor_salary", SqlDbType.BigInt).Value = textBox3.Text.Trim();
                cmd.Parameters.AddWithValue("@doctor_age", SqlDbType.Int).Value = textBox4.Text.Trim();
                cmd.Parameters.AddWithValue("@doctor_contact", SqlDbType.NVarChar).Value = maskedTextBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@doctor_qualification", SqlDbType.NVarChar).Value = textBox6.Text.Trim();
                cmd.Parameters.AddWithValue("@department_id", SqlDbType.Int).Value = textBox7.Text.Trim();
                cmd.Parameters.AddWithValue("@doctor_gender", SqlDbType.VarChar).Value = comboBox1.Text.Trim();

                cmd.ExecuteNonQuery();
                con.Close();
                Doctors doctors = new Doctors();
                doctors.Show();
                MessageBox.Show("Doctor has been inserted");

                Doctors2 doc2 = new Doctors2();
                

            }

            catch
            {
                MessageBox.Show("you entered some wrong values");
            }
        }

        private void Doctors2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            int age = Convert.ToInt32(textBox4.Text);
            if (age < 40 || age > 85)
            {
                MessageBox.Show("Age out of scope");
                textBox4.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Doctors doctors = new Doctors();
            doctors.Show();
           

        }
    }
}
