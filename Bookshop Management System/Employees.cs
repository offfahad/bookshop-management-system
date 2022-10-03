using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bookshop
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        public int EmployeeID;
        SqlConnection con = new SqlConnection("Data Source=FAHADMUGHAL\\SQLEXPRESS;Initial Catalog=CSharp;Integrated Security=True");
        private void Employees_Load(object sender, EventArgs e)
        {
            GetEmployeesRecords();
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            EmployeeID = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox2.Focus();
        }
        private void GetEmployeesRecords()
        {
            SqlCommand cmd = new SqlCommand("Select * from Employees", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            EmployeesRecordsDataGridView.DataSource = dt;
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Employees VALUES (@Employee_ID, @Employee_Name, @Employee_ContactNumber, @Employee_Position, @Employee_Salary)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Employee_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Employee_Name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Employee_ContactNumber", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Employee_Position", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Employee_Salary", textBox8.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("New Employee Record Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetEmployeesRecords();
                }
                catch (Exception Ex)
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

        private void EmployeesRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeID = Convert.ToInt32(EmployeesRecordsDataGridView.SelectedRows[0].Cells[0].Value);
            textBox2.Text = EmployeesRecordsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = EmployeesRecordsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = EmployeesRecordsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = EmployeesRecordsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox8.Text = EmployeesRecordsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (EmployeeID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE Employee_ID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.EmployeeID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee Record Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetEmployeesRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Employee Records To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (EmployeeID > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Employees SET Employee_ID = @Employee_ID, Employee_Name = @EmployeeName , Employee_ContactNumber = @Employee_ContactNumber, Employee_Position = @Employee_Position, Employee_Salary = @Employee_Salary WHERE Employee_ID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Employee_ID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@EmployeeName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Employee_ContactNumber", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Employee_Position", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Employee_Salary", textBox8.Text);
                    cmd.Parameters.AddWithValue("@ID", this.EmployeeID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Stock Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetEmployeesRecords();
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
