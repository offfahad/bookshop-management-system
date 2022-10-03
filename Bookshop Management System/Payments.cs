using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bookshop
{
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }
        public int PaymentID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void Payments_Load(object sender, EventArgs e)
        {
            GetPaymentRecords();
        }
        private void GetPaymentRecords()
        {

            SqlCommand cmd = new SqlCommand("Select * from PAYMENTS", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            PaymentsRecordsDataGridView.DataSource = dt;
        }
        private void ResetFormControls()
        {
            PaymentID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void PaymentsRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PaymentID = Convert.ToInt32(PaymentsRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = PaymentsRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = PaymentsRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = PaymentsRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = PaymentsRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = PaymentsRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = PaymentsRecordsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO PAYMENTS VALUES (@Payment_ID, @Bill_ID, @Customer_ID, @Credit_card_numb, @Credit_card_expiry, @PaymentPaid)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Payment_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Bill_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Customer_ID", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Credit_card_numb", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Credit_card_expiry", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PaymentPaid", textBox6.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Payment Made Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetPaymentRecords();
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
                MessageBox.Show("Payment ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (PaymentID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM PAYMENTS WHERE Payment_ID = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.PaymentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Payment Record Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetPaymentRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Customer To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (PaymentID > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE PAYMENTS SET Payment_ID = @Payment_ID, Bill_ID = @Bill_ID, Customer_ID = @Customer_ID, Credit_card_numb= @Credit_card_numb, Credit_card_expiry = @Credit_card_expiry, PaymentPaid = @PaymentPaid WHERE Payment_ID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Payment_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Bill_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Customer_ID", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Credit_card_numb", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Credit_card_expiry", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PaymentPaid", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ID", this.PaymentID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Payment Details Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetPaymentRecords();
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
