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
    public partial class Patients : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public Patients()
        {
            InitializeComponent();
            display();
        }

        private void display()
        {
            con.Open();
            DataTable sp1 = new DataTable();
            adapter = new SqlDataAdapter("exec sp2", con);
            adapter.Fill(sp1);
            dataGridView1.DataSource = sp1;
            con.Close();


        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable searchdoc = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM patients WHERE patient_name LIKE '" + textBox1.Text.Trim() + "%' ", con);
            adapter.Fill(searchdoc);
            dataGridView1.DataSource = searchdoc;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patientInset patientinser = new patientInset();
            patientinser.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string patient_id = dataGridView1.CurrentRow.Cells["patient_id"].Value.ToString();
            string patient_name = dataGridView1.CurrentRow.Cells["patient_name"].Value.ToString();
            string patient_gender = dataGridView1.CurrentRow.Cells["patient_gender"].Value.ToString();
            string patient_age = dataGridView1.CurrentRow.Cells["patient_age"].Value.ToString();
            string patient_contact = dataGridView1.CurrentRow.Cells["patient_contact"].Value.ToString();
            string patient_weight = dataGridView1.CurrentRow.Cells["patient_weight"].Value.ToString();
            SqlCommand cmd = new SqlCommand("delete from patients where patient_name = '" + patient_name + "'", con);
            cmd.ExecuteNonQuery();

            con.Close();
            display();

        }
        int myid;

        private void button6_Click(object sender, EventArgs e)
        {
            
            con.Open();
            string query = "update patients set patient_name = '" + textBox3.Text + "',  patient_gender = '" + comboBox1.Text + "', patient_age = " + textBox4.Text + ", patient_contact = " + textBox2.Text +   ", patient_weight = " + textBox6.Text  + " where patient_id = '" + myid + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");

            con.Close();
            display();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            myid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
