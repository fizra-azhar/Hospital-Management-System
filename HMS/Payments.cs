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
    public partial class Payments : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        private void display()
        {
            con.Open();
            DataTable sp1 = new DataTable();
            adapter = new SqlDataAdapter("exec sp6", con);
            adapter.Fill(sp1);
            dataGridView1.DataSource = sp1;

            DataTable sp7 = new DataTable();
            adapter = new SqlDataAdapter("exec sp7", con);
            adapter.Fill(sp7);
            dataGridView2.DataSource = sp7;
            con.Close();


        }

        public Payments()
        {
            InitializeComponent();
            display();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.Text == "Doctor ID")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM doctors_payment where doctor_id LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
            else if (comboBox1.Text == "Doctor Salary Amount")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM doctors_payment WHERE doctor_payment_amount LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
            else if (comboBox1.Text == "Doctor Month Of Salary")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM doctors_payment WHERE month_salary LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
            else if (comboBox1.Text == "Staff Month Of  Salary")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM staff_payments WHERE month_of_salary LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }

            else if (comboBox1.Text == "Staff ID")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM staff_payments WHERE staff_id LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
            else if (comboBox1.Text == "Staff Salary Amount")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM staff_payments WHERE staff_payment_amount LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }

            con.Close();
            label6.Hide();
            label5.Hide();
            dataGridView2.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Payments_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
