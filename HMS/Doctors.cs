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
    public partial class Doctors : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public Doctors()
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
            dataGridView1.DataSource = sp1;
            con.Close();


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctors2 doc2 = new Doctors2();
            doc2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        int myid;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            myid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            maskedTextBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string doctor_id = dataGridView1.CurrentRow.Cells["doctor_id"].Value.ToString();
                string doctor_name = dataGridView1.CurrentRow.Cells["doctor_name"].Value.ToString();
                string doctor_gender = dataGridView1.CurrentRow.Cells["doctor_gender"].Value.ToString();
                string doctor_age = dataGridView1.CurrentRow.Cells["doctor_age"].Value.ToString();
                string doctor_contact = dataGridView1.CurrentRow.Cells["doctor_contact"].Value.ToString();
                string doctor_qualification = dataGridView1.CurrentRow.Cells["doctor_qualification"].Value.ToString();
                string doctor_specialization = dataGridView1.CurrentRow.Cells["doctor_specialization"].Value.ToString();
                string doctor_salary = dataGridView1.CurrentRow.Cells["doctor_salary"].Value.ToString();
                string department_id = dataGridView1.CurrentRow.Cells["department_id"].Value.ToString();
                SqlCommand cmd = new SqlCommand("delete from doctors where doctor_name = '" + doctor_name + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                display();
            }
            catch
            {
                MessageBox.Show("something wents wong");

            }



        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Doctors_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable searchdoc = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM doctors WHERE doctor_name LIKE '"+textBox1.Text.Trim()+ "%' ", con);
            adapter.Fill(searchdoc);
            dataGridView1.DataSource = searchdoc;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                string query = "update expenses set doctor_name = '" + textBox5.Text + "', doctor_gender = '" + comboBox1.Text + "', doctor_age = " + textBox4.Text + ", doctor_contact = " + maskedTextBox1.Text + "', doctor_qualification = '" + textBox6.Text + "', doctor_specialization = '" + textBox2.Text + "'" + "', department_id = " + textBox7.Text + " where exp_id = '" + myid + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated");


                con.Close();
                display();
            }

            catch
            {
                MessageBox.Show("something wents wong");

            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            
                

            myid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            maskedTextBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
