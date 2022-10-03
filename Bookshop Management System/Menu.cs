using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookshop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Supplier s1 = new Supplier();
            s1.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Stock f1 = new Stock();
            f1.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Employees e1 = new Employees();
            e1.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Customers_Details c1 = new Customers_Details();
            c1.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Orders o1 = new Orders();
            o1.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Bills b1 = new Bills();
            b1.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Payments p1 = new Payments();
            p1.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ReturnedOrders r1 = new ReturnedOrders();
            r1.Show();
        }
    }
}
