using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Jewellery_System
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-MGBIM8D;Initial Catalog=Jewellery;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from tbl_Item";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Itemdgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ItNametxt.Text == "" || Pricetxt.Text == "" || Quantitytxt.Text == "" || CatCb.SelectedIndex == -1 || TypesCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into tbl_Item values('" + ItNametxt.Text + "', '" + CatCb.SelectedIndex.ToString() + "', '" + TypesCb.SelectedIndex.ToString() + "', '" + Pricetxt.Text + "', '" + Quantitytxt.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Items Saved Successfully");
                    Con.Close();
                    Reset();

                }catch(Exception ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }
        int key = 0;
        private void Itemdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItNametxt.Text = Itemdgv.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.SelectedItem = Itemdgv.SelectedRows[0].Cells[2].Value.ToString();
            TypesCb.SelectedItem = Itemdgv.SelectedRows[0].Cells[3].Value.ToString();
            Pricetxt.Text = Itemdgv.SelectedRows[0].Cells[4].Value.ToString();
            Quantitytxt.Text = Itemdgv.SelectedRows[0].Cells[5].Value.ToString();

            if (ItNametxt.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(Itemdgv.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        private void Reset() 
        {
            ItNametxt.Text = "";
            CatCb.SelectedIndex = -1;
            TypesCb.SelectedIndex = -1;
            Pricetxt.Text = "";
            Quantitytxt.Text = "";
            key = 0;

        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from tbl_Item where ItId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Items Deleted Successfully");
                    Con.Close();
                    populate();
                    Reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (ItNametxt.Text == "" || Pricetxt.Text == "" || Quantitytxt.Text == "" || CatCb.SelectedIndex == -1 || TypesCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update tbl_Item set ItNametxt ='"+ItNametxt.Text+"',ItCat='"+CatCb.SelectedItem.ToString()+"',ItType='"+TypesCb.SelectedItem.ToString()+"',ItPrice='"+Pricetxt.Text+"', ItQuantity='"+Quantitytxt.Text+"' where ItId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Items Updated Successfully");
                    Con.Close();
                    populate();
                    Reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }
    }
}
