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
    public partial class Reciepts : Form
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
        public Reciepts()
        {
            InitializeComponent();
            display();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void Reciepts_Load(object sender, EventArgs e)
        {

        }
    }
}
