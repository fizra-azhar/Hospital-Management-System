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
    public partial class Staffs : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public Staffs()
        {
            InitializeComponent();
            display();
        }

        private void display()
        {
            con.Open();
            DataTable spstaff = new DataTable();
            adapter = new SqlDataAdapter("exec spstaff", con);
            adapter.Fill(spstaff);
            dataGridView1.DataSource = spstaff;
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

        private void button1_Click(object sender, EventArgs e)
        {
            staffInsert staffinsert = new staffInsert();
            staffinsert.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable searchstaff = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM staffs WHERE staff_name LIKE '" + textBox1.Text.Trim() + "%' ", con);
            adapter.Fill(searchstaff);
            dataGridView1.DataSource = searchstaff;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            string staff_id = dataGridView1.CurrentRow.Cells["staff_id"].Value.ToString();
            string staff_name = dataGridView1.CurrentRow.Cells["staff_name"].Value.ToString();
            string staff_designation = dataGridView1.CurrentRow.Cells["staff_designation"].Value.ToString();
            string staff_gender = dataGridView1.CurrentRow.Cells["staff_gender"].Value.ToString();
            string staff_age = dataGridView1.CurrentRow.Cells["staff_age"].Value.ToString();
            string staff_contact = dataGridView1.CurrentRow.Cells["staff_contact"].Value.ToString();
            string satff_salary = dataGridView1.CurrentRow.Cells["salary"].Value.ToString();
            string department_id = dataGridView1.CurrentRow.Cells["department_id"].Value.ToString();
            SqlCommand cmd = new SqlCommand("delete from staffs where staff_name = '" + staff_name + "'", con);
            cmd.ExecuteNonQuery();

            con.Close();
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}
