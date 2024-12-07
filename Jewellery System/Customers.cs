using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            populate();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Item Obj = new Item();
            Obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-MGBIM8D;Initial Catalog=Jewellery;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from tbl_Cust";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Reset()
        {
            CustnameTb.Text = "";
            CustPhoneTb.Text = "";
        }
    

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (CustnameTb.Text == "" || CustPhoneTb.Text == "")
            { 
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into tbl_Cust values('" + CustnameTb.Text + "', '" + CustPhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customers Saved Successfully");
                    Con.Close();
                    Reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        int key = 0;
        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustnameTb.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
           

            if (CustnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustnameTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update tbl_Cust set Custname= '" + CustnameTb.Text + "', CustPhone= '" + CustPhoneTb.Text + "' where CustId=" + key + ";)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customers Updated Successfully");
                    Con.Close();
                    Reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }
    }
}
