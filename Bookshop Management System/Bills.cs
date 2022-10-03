using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bookshop
{
    public partial class Bills : Form
    {
        public Bills()
        {
            InitializeComponent();
        }
        public int BillID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void Bills_Load(object sender, EventArgs e)
        {
            GetBillsRecords();
        }
        private void GetBillsRecords()
        {

            SqlCommand cmd = new SqlCommand("Select * from Bill_Generate", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            BillsRecordsDataGridView.DataSource = dt;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            BillID = 0;
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
                if (IsValid())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Bill_Generate VALUES (@Bill_ID , @Order_ID, @Customer_ID, @StockID, @Bill_Date , @Total_Cost)", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Bill_ID ", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Order_ID", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Customer_ID", textBox3.Text);
                        cmd.Parameters.AddWithValue("@StockID", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Bill_Date ", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Total_Cost", textBox6.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("New Bill Generated Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetBillsRecords();
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
                MessageBox.Show("Bill ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void BillsRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BillID = Convert.ToInt32(BillsRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = BillsRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = BillsRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = BillsRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = BillsRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = BillsRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = BillsRecordsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (BillID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Bill_Generate WHERE Bill_ID = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.BillID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Bill Record Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetBillsRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Bill To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (BillID > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Bill_Generate SET Bill_ID  = @Bill_ID,  Order_ID = @Order_ID, Customer_ID = @Customer_ID, StockID= @StockID, Bill_Date = @Bill_Date, Total_Cost = @Total_Cost WHERE Bill_ID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Bill_ID ", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Order_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Customer_ID", textBox3.Text);
                    cmd.Parameters.AddWithValue("@StockID", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Bill_Date ", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Total_Cost", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ID", this.BillID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Bill Record Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetBillsRecords();
                    ResetFormControls();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Bill To Update Its Information.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
