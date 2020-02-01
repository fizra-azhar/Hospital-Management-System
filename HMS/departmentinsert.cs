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
    public partial class departmentinsert : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project_HMS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        int id = 0;
        public departmentinsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertdept", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dep_name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@dep_room", SqlDbType.Int).Value = textBox3.Text.Trim();

                cmd.Parameters.AddWithValue("@dep_emp", SqlDbType.Int).Value = textBox2.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Department added successfully");

  

            }

            catch
            {
                MessageBox.Show("you entered some wrong values");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
