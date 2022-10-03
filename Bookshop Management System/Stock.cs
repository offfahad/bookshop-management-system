using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bookshop
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        public int StockID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void Button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO StockTb VALUES (@StockID, @SupplierID, @BookID, @AuthorName, @BookName, @PublisherName, @PublishedYear, @Price)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@StockID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@BookID", textBox3.Text);
                    cmd.Parameters.AddWithValue("@AuthorName", textBox4.Text);
                    cmd.Parameters.AddWithValue("@BookName", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PublisherName", textBox6.Text);
                    cmd.Parameters.AddWithValue("@PublishedYear", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Price", textBox8.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("New Stock Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetStockRecords();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private bool IsValid()
        {
            if(textBox2.Text == string.Empty)
            {
                MessageBox.Show("Stock ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if(StockID>0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE StockTb SET StockID = @StockId, SupplierID = @SupplierID , BookID = @BookID, AuthorName = @AuthorName, @BookName = @BookName, PublisherName = @PublisherName, PublishedYear = @PublishedYear, Price = @Price WHERE StockID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@StockID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@BookID", textBox3.Text);
                    cmd.Parameters.AddWithValue("@AuthorName", textBox4.Text);
                    cmd.Parameters.AddWithValue("@BookName", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PublisherName", textBox6.Text);
                    cmd.Parameters.AddWithValue("@PublishedYear", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Price", textBox8.Text);
                    cmd.Parameters.AddWithValue("@ID", this.StockID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Stock Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetStockRecords();
                    ResetFormControls();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Stock To Update Its Information.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStockRecords();
            ResetFormControls();
        }

        private void GetStockRecords()
        {
            
            SqlCommand cmd = new SqlCommand("Select * from StockTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StockRecordsDataGridView.DataSource = dt;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();

        }
        private void ResetFormControls()
        {
            StockID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox1.Focus();
        }

        private void StockRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StockID = Convert.ToInt32(StockRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = StockRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = StockRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = StockRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = StockRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = StockRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = StockRecordsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = StockRecordsDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = StockRecordsDataGridView.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(StockID>0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM StockTb WHERE StockID = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.StockID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Stock Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStockRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Stock To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
