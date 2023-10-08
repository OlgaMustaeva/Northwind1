using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind1
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter adapter;
        private DataTable CustomersTable = new DataTable("Customers");
        private DataTable OrdersTable = new DataTable("Orders");
        private DataTable ProductsTable = new DataTable("Products");
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (username == "Olga" && password == "111")
            {
                // Подключение к базе данных
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6D0IVG5\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");

                try
                {
                    connection.Open();
                    MessageBox.Show("Подключение успешно установлено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль.");
            }
        }

        private void Products_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=DESKTOP-6D0IVG5\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            string query = "SELECT * FROM Products";
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
               
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-6D0IVG5\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            string query = "SELECT * FROM Orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

        }

        private void Customers_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-6D0IVG5\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            string query = "SELECT * FROM Customers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите строку, которую хотите удалить.");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (dataGridView1.DataSource != null && adapter != null) 
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update((DataTable)dataGridView1.DataSource);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
