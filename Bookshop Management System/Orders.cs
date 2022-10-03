using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bookshop
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
        public int OrderID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void Orders_Load(object sender, EventArgs e)
        {
            GetOrdersRecords();
        }
        private void GetOrdersRecords()
        {
            SqlCommand cmd = new SqlCommand("Select * from Orders", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            OrdersRecordsDataGridView.DataSource = dt;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            OrderID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES (@Order_ID, @Customer_ID, @Customer_Name, @Employee_ID, @StockID, @Qty_sold, @Order_Date)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Order_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Customer_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Customer_Name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Employee_ID", textBox4.Text);
                    cmd.Parameters.AddWithValue("@StockID", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Qty_sold", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Order_Date", textBox7.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("New Stock Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetOrdersRecords();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private bool IsValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Order ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void OrdersRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderID = Convert.ToInt32(OrdersRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = OrdersRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = OrdersRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = OrdersRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = OrdersRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = OrdersRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = OrdersRecordsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = OrdersRecordsDataGridView.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (OrderID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE Order_ID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.OrderID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Stock Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetOrdersRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Order To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (OrderID > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Orders SET Order_ID = @Order_ID, Customer_ID = @Customer_ID , Customer_Name = @Customer_Name, Employee_ID = @Employee_ID, StockID = @StockID, Qty_sold = @Qty_sold, Order_Date = @Order_Date WHERE Order_ID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Order_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Customer_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Customer_Name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Employee_ID", textBox4.Text);
                    cmd.Parameters.AddWithValue("@StockID", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Qty_sold", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Order_Date", textBox7.Text);
                    cmd.Parameters.AddWithValue("@ID", this.OrderID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order Record Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetOrdersRecords();
                    ResetFormControls();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Order To Update Its Information.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
