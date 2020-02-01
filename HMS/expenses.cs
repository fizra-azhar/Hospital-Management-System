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
    public partial class expenses : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;

        private void display()
        {
            con.Open();
            DataTable sp5 = new DataTable();
            adapter = new SqlDataAdapter("exec sp5", con);
            adapter.Fill(sp5);
            dataGridView1.DataSource = sp5;
            con.Close();


        }
        public expenses()
        {
            InitializeComponent();
            display();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void expenses_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            button5.Enabled = false;
            button2.Enabled = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
          

                con.Open();
                DataTable searchexp = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM expenses WHERE exp_name LIKE '" + textBox1.Text.Trim() + "%' ", con);
                adapter.Fill(searchexp);
                dataGridView1.DataSource = searchexp;
                con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string exp_id = dataGridView1.CurrentRow.Cells["exp_id"].Value.ToString();
            string exp_name = dataGridView1.CurrentRow.Cells["exp_name"].Value.ToString();

            string exp_amount = dataGridView1.CurrentRow.Cells["exp_amount"].Value.ToString();
            string exp_date_time = dataGridView1.CurrentRow.Cells["date_time"].Value.ToString();

            SqlCommand cmd = new SqlCommand("delete from expenses where exp_id =" + exp_id + " and exp_name =" + "'" + exp_name + "'" + " and  exp_amount =" + exp_amount + " and date_time = " + "'" + exp_date_time + "'", con);
 
            cmd.ExecuteNonQuery();

            con.Close();
            display();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertexp insertexp = new insertexp();
            insertexp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
 
           con.Open();
            string query = "update expenses set exp_name = '"+ textBox2.Text + "',  exp_amount = '"+textBox3.Text+"', date_time = '"+textBox4.Text+"' where exp_id = '"+myid +"'";
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
            label7.Enabled = false;
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
            label7.Enabled = true;
            button5.Enabled = true;
            button2.Enabled = true;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
