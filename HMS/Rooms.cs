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
    public partial class Rooms : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;

        private void display()
        {
            con.Open();
            DataTable sp9 = new DataTable();
            adapter = new SqlDataAdapter("exec sp9", con);
            adapter.Fill(sp9);
            dataGridView1.DataSource = sp9;
            con.Close();


        }
        public Rooms()
        {
            InitializeComponent();
            display();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {

        }
    }
}
