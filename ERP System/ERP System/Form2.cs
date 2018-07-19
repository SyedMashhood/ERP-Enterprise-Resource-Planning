using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP_System
{
    public partial class Form2 : Form
    {
        Myconn conn = new Myconn();
        Mycontrol obj;
        
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            obj = new Mycontrol(this);
            obj.cs_hide();
            obj.ad_hide();
            obj.vendor_comboo();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            obj.cs_show();
            obj.ad_hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            obj.vendor();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            obj.ad_show();
            obj.cs_hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.main_login();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            obj.signup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.ad_signup();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            obj.ad_hide();
            obj.grn();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Show();
            obj.add_Vendor();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.comboBox7.Show();
            this.groupBox3.Show();
            this.button3.Hide();
            this.label15.Hide();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select POID from PO where status='Open'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox7.Items.Add(dr["POID"]);
            }
            conn.oleDbConnection1.Close();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.comboBox3.Items.Clear();
            this.comboBox3.Show();
            this.label9.Hide();
            this.label8.Hide();
            this.label7.Hide();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select deptname from Dept", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox3.Items.Add(dr["deptname"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox4.Items.Clear();
            this.comboBox4.Show();
            this.dataGridView1.Show();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VGroup='" + this.comboBox3.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox4.Items.Add(dr["VName"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.search_vendor_combo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Vendor (VID,VName,VCode,PH1,CPName,VGroup) values (@VID,@VName,@VCode,@PH1,@CPName,@VGroup)");
            cmd.Parameters.AddWithValue("@VID",textBox3.Text);
            cmd.Parameters.AddWithValue("@VName",textBox4.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox5.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox7.Text);
            cmd.Parameters.AddWithValue("@VGroup", textBox8.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vendor Successfully Added");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error: "+ee);
            }
            conn.oleDbConnection1.Close();

            //obj.enter_vendor_data();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            obj.Purchase_Order();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.po_id();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.grn_data();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.po_vid();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.po_model();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            obj.add_purchaseorder();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            obj.enter_purchaseorder();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            obj.show_purchaseorder();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            obj.generate_grn();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            obj.invoice();
        }




        







        }
 }
