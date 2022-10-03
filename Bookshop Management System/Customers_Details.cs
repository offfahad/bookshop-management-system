using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace Bookshop
{
    public partial class Customers_Details : Form
    {
        public Customers_Details()
        {
            InitializeComponent();
        }
        public int CustomerID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void Customers_Details_Load(object sender, EventArgs e)
        {
            GetCustomersRecords();
        }
        private void GetCustomersRecords()
        {

            SqlCommand cmd = new SqlCommand("Select * from Customer", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            CustomersRecordsDataGridView.DataSource = dt;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            CustomerID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Customer VALUES (@Customer_ID, @Name, @CustomerAddress, @Phone, @Email, @Age)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Customer_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CustomerAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Age", textBox6.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("New Stock Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetCustomersRecords();
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(Ex.Message);
                }

            }
        }
        private bool IsValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Customer ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void CustomersRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerID = Convert.ToInt32(CustomersRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = CustomersRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = CustomersRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = CustomersRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = CustomersRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = CustomersRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = CustomersRecordsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (CustomerID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE Customer_ID = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.CustomerID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetCustomersRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Customer To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (CustomerID > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Customer SET Customer_ID = @Customer_ID, Name = @Name, CustomerAddress = @CustomerAddress, Phone = @Phone, Email = @Email, Age = @Age WHERE Customer_ID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Customer_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CustomerAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Age", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ID", this.CustomerID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Stock Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetCustomersRecords();
                    ResetFormControls();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Customer To Update Its Information.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
