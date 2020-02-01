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
    public partial class patientInset : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public patientInset()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertpat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patient_name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@patient_gender", SqlDbType.VarChar).Value = comboBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@patient_age", SqlDbType.Int).Value = textBox4.Text.Trim();
                cmd.Parameters.AddWithValue("@patient_contact", SqlDbType.BigInt).Value = textBox2.Text.Trim();
                cmd.Parameters.AddWithValue("@patient_weight", SqlDbType.Int).Value = textBox6.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Patient entered successfully");

            }


            catch
            {
                MessageBox.Show("You entered some wrong values");
            }





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
