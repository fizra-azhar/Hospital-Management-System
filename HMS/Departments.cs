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
    public partial class Departments : Form
    {


        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;

        private void display()
        {
            con.Open();
            DataTable sp8 = new DataTable();
            adapter = new SqlDataAdapter("exec sp8", con);
            adapter.Fill(sp8);
            dataGridView1.DataSource = sp8;
            con.Close();


        }
        public Departments()
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

        private void button3_Click(object sender, EventArgs e)
        {
            departmentinsert depinsert = new departmentinsert();
            depinsert.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string department_id = dataGridView1.CurrentRow.Cells["department_id"].Value.ToString();
            string department_name = dataGridView1.CurrentRow.Cells["department_name"].Value.ToString();
            string department_room = dataGridView1.CurrentRow.Cells["rooms"].Value.ToString();
            string department_rmp = dataGridView1.CurrentRow.Cells["department_name"].Value.ToString();
            SqlCommand cmd = new SqlCommand("delete from departments where department_name = '" + department_name + "' , deppartment_id = '" + department_id  + "'", con);
            cmd.ExecuteNonQuery();

            con.Close();
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable searchdepartment = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM departments WHERE department_name LIKE '" + textBox1.Text.Trim() + "%' ", con);
            adapter.Fill(searchdepartment);
            dataGridView1.DataSource = searchdepartment;
            con.Close();
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

        private void Departments_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "update departments set department_name = '" + textBox2.Text + "',  Rooms = '" + textBox3.Text + "', Employees = '" + textBox4.Text + "' where department_id = '" + myid + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated");

            con.Close();
            display();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            button5.Enabled = false;
        }
        int myid;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            myid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            button5.Enabled = true;
            button2.Enabled = true;
        }
    }
}
