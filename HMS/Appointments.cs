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
    public partial class Appointments : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        private void display()
        {
            con.Open();
            DataTable sp5 = new DataTable();
            adapter = new SqlDataAdapter("exec sp3", con);
            adapter.Fill(sp5);
            dataGridView1.DataSource = sp5;
            con.Close();


        }
        public Appointments()
        {
            InitializeComponent();
            display();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
      
            if (comboBox1.Text == "appointment_id")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM appointments WHERE appointment_id LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;
                
            }
            else if (comboBox1.Text == "patient_id")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM appointments WHERE patient_id LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;
                
            }
            else if (comboBox1.Text == "doctor_id")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM appointments WHERE doctor_id LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;
                
            }
            else if (comboBox1.Text == "disease")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM appointments WHERE disease LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;
                
            }
            else if (comboBox1.Text == "date")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM appointments WHERE date_time LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;
                
            }
     
            con.Close();

        }
    }
}
