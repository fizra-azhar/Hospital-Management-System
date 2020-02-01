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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("You're Login as Reception administrator");

            display();
        }

        private void display()
        {
            



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctors Doctorsclick = new Doctors();
            Doctorsclick.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patients Doctorsclick = new Patients();
            Doctorsclick.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Staffs Doctorsclick = new Staffs();
            Doctorsclick.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Appointments Doctorsclick = new Appointments();
            Doctorsclick.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Labs Doctorsclick = new Labs();
            Doctorsclick.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rooms Doctorsclick = new Rooms();
            Doctorsclick.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Departments Doctorsclick = new Departments();
            Doctorsclick.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reciepts Doctorsclick = new Reciepts();
            Doctorsclick.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Payments Doctorsclick = new Payments();
            Doctorsclick.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            expenses Doctorsclick = new expenses();
            Doctorsclick.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

     

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
