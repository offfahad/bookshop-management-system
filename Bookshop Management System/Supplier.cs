using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bookshop
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }
        public int SupplierID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void Supplier_Load(object sender, EventArgs e)
        {
            GetSupplierRecords();
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            SupplierID = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox2.Focus();
        }

        private void GetSupplierRecords()
        {

            SqlCommand cmd = new SqlCommand("Select * from SuppliersTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            SuppliersRecordsDataGridView.DataSource = dt;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SuppliersTb VALUES (@SupplierID, @Supplier_name, @Supplier_City, @Supplier_email, @Supplier_phone)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SupplierID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Supplier_name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Supplier_City", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Supplier_email", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Supplier_phone", textBox8.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("New Supplier Record Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSupplierRecords();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private bool IsValid()
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Supplier ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void SuppliersRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SupplierID = Convert.ToInt32(SuppliersRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox2.Text = SuppliersRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = SuppliersRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = SuppliersRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = SuppliersRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox8.Text = SuppliersRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (SupplierID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM SuppliersTb WHERE Supplier_ID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.SupplierID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Supplier Record Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetSupplierRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Supplier Records To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (SupplierID > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE SuppliersTb SET Supplier_ID = @SupplierID, Supplier_name = @SupplierName , Supplier_city = @SupplierCity, Supplier_email = @SupplierEmail, Supplier_phone = @SupplierPhone WHERE Supplier_ID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SupplierID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@SupplierName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@SupplierCity", textBox4.Text);
                    cmd.Parameters.AddWithValue("@SupplierEmail", textBox6.Text);
                    cmd.Parameters.AddWithValue("@SupplierPhone", textBox8.Text);
                    cmd.Parameters.AddWithValue("@ID", this.SupplierID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Stock Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSupplierRecords();
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
    }
}
