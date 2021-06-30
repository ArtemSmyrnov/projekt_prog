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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            
           
        }
        
       static string connectionString = @"Data Source=DESKTOP-JJA64DE\SQLEXPRESS;Initial Catalog=Projekt1;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        private void button1_Click(object sender, EventArgs e)  //add order to database
        {
            connection.Open();
            
            SqlCommand command = new SqlCommand("insert into CarRent values ('" + comboBox1.Text + "','" + comboBox2.Text + "', getdate()) ", connection);
            command.ExecuteNonQuery();
            MessageBox.Show("You placed your order!");
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logowanie logowanie = new Logowanie();
            logowanie.Show();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double cena = 0;
            int n;
            double sum;

            if (radioButton1.Checked)
                cena = 120000;
            if (radioButton2.Checked)
                cena = 59000;
            if (radioButton3.Checked)
                cena = 400000;
            if (radioButton4.Checked)
                cena = 50000;
            if (radioButton5.Checked)
                cena = 77000;

            n = Convert.ToInt32(textBox1.Text);

            if (n >= 2) {
                sum = cena / n;
                MessageBox.Show("Price: " + cena.ToString("c") + "\n" + "" + n.ToString() + " " + "Months. \n" + "Per months: " + sum.ToString("C"));
            }
           
            else
            {
                MessageBox.Show("Price: " + cena.ToString("c"));
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  // focus leasing button
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button4.Focus();

                }
                return;
            }
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)  //activate leasing button
        {
            if (textBox1.Text.Length == 0)
                button4.Enabled = false;
            else
                button4.Enabled = true;
            label2.Text = "";
        }
         private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
            textBox1.Focus();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            textBox1.Focus();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
          
            textBox1.Focus();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
         
            textBox1.Focus();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
           
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
