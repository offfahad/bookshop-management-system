using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bookshop
{
    public partial class ReturnedOrders : Form
    {
        public ReturnedOrders()
        {
            InitializeComponent();
        }
        public int ReturnedID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void ReturnedOrders_Load(object sender, EventArgs e)
        {
            GetReturnedRecords();
        }
        private void GetReturnedRecords()
        {

            SqlCommand cmd = new SqlCommand("Select * from Returns", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            ReturnedRecordsDataGridView.DataSource = dt;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            ReturnedID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Returns VALUES (@Return_ID , @Bill_ID, @Payment_ID, @Order_ID, @PayReturned)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Return_ID ", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Bill_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Payment_ID", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Order_ID", textBox4.Text);
                    cmd.Parameters.AddWithValue("@PayReturned ", textBox5.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Returned Order Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetReturnedRecords();
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
                MessageBox.Show("Return Order ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ReturnedRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ReturnedID = Convert.ToInt32(ReturnedRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = ReturnedRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = ReturnedRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = ReturnedRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = ReturnedRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = ReturnedRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (ReturnedID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Returns WHERE Return_ID = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.ReturnedID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Returned Record Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetReturnedRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Customer To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
