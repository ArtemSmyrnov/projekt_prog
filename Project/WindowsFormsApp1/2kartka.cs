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

namespace WindowsFormsApp1
{
    public partial class _2kartka : Form
    {
        public _2kartka()
        {
            InitializeComponent();
            BindData();
        }
        
        private void _2kratka_Load(object sender, EventArgs e)
        {
            BindData();
        }
        static string connectionString = @"Data Source=DESKTOP-JJA64DE\SQLEXPRESS;Initial Catalog=Projekt1;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        private void button2_Click(object sender, EventArgs e)  //update
        {
           
            connection.Open();
            SqlCommand command = new SqlCommand("Update CarRent set CarName = '" + comboBox1.Text + "', Complectation='" + comboBox2.Text + "' , [DataTake]=getdate() where id ='" + int.Parse(textBox1.Text) + "' ", connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Succesfully updated");
            connection.Close();
            BindData();

        }
        void BindData() //show database
        {
            SqlCommand command = new SqlCommand("select * from CarRent", connection);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)  //delete
        {
            
            connection.Open();
            if (textBox1.Text != "")
            {
                SqlCommand command = new SqlCommand("DELETE from CarRent where id ='" + int.Parse(textBox1.Text) + "'", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Succesfully deleted");
            }
            else
            {
                MessageBox.Show("Write ID");
            }
            connection.Close();
            BindData();

        }

        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
