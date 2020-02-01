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
    public partial class Labs : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        private void display()
        {
            con.Open();
            DataTable sp5 = new DataTable();
            adapter = new SqlDataAdapter("exec sp4", con);
            adapter.Fill(sp5);
            dataGridView1.DataSource = sp5;
            con.Close();


        }
        public Labs()
        {
            InitializeComponent();
            display();
        }

        private void Labs_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "id")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM labs WHERE lab_id LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
            else if (comboBox1.Text == "name")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM labs WHERE lab_name LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
            else if (comboBox1.Text == "charges")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM labs WHERE lab_charges LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
            else if (comboBox1.Text == "staff")
            {
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM labs WHERE staff_id LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
