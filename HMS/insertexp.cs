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
    public partial class insertexp : Form
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
            con.Close();


        }
        public insertexp()
        {
            InitializeComponent();
        }

        private void insertexp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertexp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@exp_name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@exp_amount", SqlDbType.Int).Value = textBox2.Text.Trim();
                cmd.Parameters.AddWithValue("@date_time", SqlDbType.DateTime).Value = textBox3.Text.Trim();

                cmd.ExecuteNonQuery();
                con.Close();

                display();
                MessageBox.Show("Expenses has been Inserted");
                display();

               

            }

            catch
            {
                MessageBox.Show("you entered some wrong values");
            }
        }
    }
}
