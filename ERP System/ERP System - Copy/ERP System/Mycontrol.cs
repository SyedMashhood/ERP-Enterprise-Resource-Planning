using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace ERP_System
{
    class Mycontrol
    {
        Form2 f2;
        Myconn conn = new Myconn();
        String ue, up;
        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;

        public Mycontrol(Form2 ff2)
        {
            f2 = ff2;
        }
        public void cs_hide()
        {
            f2.label7.Hide();
            f2.label8.Hide();
            f2.label9.Hide();
            f2.label10.Hide();
            f2.button3.Hide();
            f2.label15.Hide();
            f2.comboBox1.Hide();
            f2.comboBox2.Hide();
            f2.dataGridView1.Visible=false;
            f2.comboBox3.Hide();
            f2.comboBox4.Hide();
            f2.dataGridView1.Hide();
            f2.textBox3.Hide();
            f2.textBox4.Hide();
            f2.textBox5.Hide();
            f2.textBox6.Hide();
            f2.textBox7.Hide();
            f2.textBox8.Hide();
            f2.label17.Hide();
            f2.label18.Hide();
            f2.label19.Hide();
            f2.label20.Hide();
            f2.label21.Hide();
            f2.label22.Hide();
            f2.button4.Hide();
            f2.textBox9.Hide();
            f2.textBox10.Hide();
            f2.textBox11.Hide();
            f2.textBox12.Hide();
            f2.textBox14.Hide();
            f2.dataGridView2.Hide();
            f2.label23.Hide();
            f2.label24.Hide();
            f2.label25.Hide();
            f2.label26.Hide();
            f2.label27.Hide();
            f2.label28.Hide();
            f2.label29.Hide();
            f2.comboBox5.Hide();
            f2.comboBox6.Hide();
            f2.comboBox7.Hide();
            f2.groupBox1.Hide();
            f2.groupBox2.Hide();
            f2.groupBox3.Hide();
            f2.groupBox4.Hide();
            f2.comboBox6.Hide();
            f2.button8.Hide();
            f2.comboBox10.Hide();
        }

        public void cs_show()
        {
            f2.label7.Show();
            f2.label8.Show();
            f2.label9.Show();
            f2.label10.Show();
            f2.label14.Hide();
            f2.label15.Hide();
        }

        public void ad_hide()
        {
            f2.textBox1.Hide();
            f2.textBox2.Hide();
            f2.button1.Hide();
            f2.button2.Hide();
            f2.label1.Hide();            
            f2.label11.Hide();
            f2.label12.Hide();
            f2.label13.Hide();
            f2.button3.Hide();
            f2.comboBox1.Hide();
            f2.comboBox2.Hide();
            f2.textBox3.Hide();
            f2.textBox4.Hide();
            f2.textBox5.Hide();
            f2.textBox6.Hide();
            f2.textBox7.Hide();
            f2.textBox8.Hide();
            f2.label17.Hide();
            f2.label18.Hide();
            f2.label19.Hide();
            f2.label20.Hide();
            f2.label21.Hide();
            f2.label22.Hide();
            f2.button4.Hide();
            f2.textBox9.Hide();
            f2.textBox10.Hide();
            f2.textBox11.Hide();
            f2.textBox12.Hide();
            f2.textBox14.Hide();
            f2.dataGridView2.Hide();
            f2.label23.Hide();
            f2.comboBox3.Hide();
            f2.comboBox4.Hide();
            f2.dataGridView1.Hide();
            f2.label24.Hide();
            f2.label25.Hide();
            f2.label26.Hide();
            f2.label27.Hide();
            f2.label28.Hide();
            f2.label29.Hide();
            f2.comboBox5.Hide();
            f2.comboBox6.Hide();
            f2.comboBox7.Hide();
            f2.groupBox1.Hide();
            f2.groupBox2.Hide();
            f2.groupBox3.Hide();
            f2.groupBox4.Hide();
            f2.comboBox10.Hide();
        }

        public void ad_show()
        {
            f2.textBox1.Show();
            f2.textBox2.Show();
            f2.button1.Show();
            f2.label1.Show();
            f2.label11.Show();
            f2.label12.Show();
            f2.label13.Show();
            f2.label14.Hide();
            f2.label1.Enabled = false;
        }

        public void signin()
        {
            f2.label1.Enabled = true;
            f2.textBox1.Clear();
            f2.textBox2.Clear();
        }

        public void signup()
        {
            f2.button2.Show();
            f2.label1.Hide();
        }

        public void vendor()
        {
            this.ad_hide();
            this.cs_hide();
            f2.comboBox1.Show();
        }

        public void grn()
        {
            f2.button3.Show();
            f2.textBox1.Hide();
            f2.textBox2.Hide();
            f2.button1.Hide();
            f2.button2.Hide();
            f2.label1.Hide();
            f2.label11.Hide();
            f2.label12.Hide();
            f2.label13.Hide();
            f2.label14.Hide();
            f2.label7.Hide();
            f2.label8.Hide();
            f2.label9.Hide();
            f2.label10.Hide();
            f2.label15.Show();
            f2.comboBox1.Hide();
            f2.comboBox10.Hide();
        }

        public void vendor_comboo()
        {

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Dept", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                f2.comboBox1.Items.Add(dr["Deptid"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        public void main_login()
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from users where username= '" + f2.textBox1.Text + " ' AND upassword= '" + f2.textBox2.Text + " ' ", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ue = dr["username"].ToString();
                    up = dr["upassword"].ToString();
                    if (ue == f2.textBox1.Text || up == f2.textBox2.Text)
                    {
                        this.signin();
                    }
                }
                else
                {
                    f2.textBox1.Clear();
                    f2.textBox2.Clear();
                    MessageBox.Show("Email or Password is invalid");
                }
            conn.oleDbConnection1.Close();
        }

        public void ad_signup()
        {
            conn.oleDbConnection1.Open();
            if (f2.textBox1.Text != "" && f2.textBox2.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand("insert into login (username, upassword) values (@username, @upassword);", conn.oleDbConnection1);
                cmd.Parameters.AddWithValue("@username", f2.textBox1.Text);
                cmd.Parameters.AddWithValue("@upassword", f2.textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Reistered Successful");
            }
            else
            {
                MessageBox.Show("Fill All Fields");
            }
            conn.oleDbConnection1.Close();
    }


        public void add_Vendor()
        {
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(POID) from PO where deptname= @deptname", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@deptname", f2.comboBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    f2.textBox3.Text = c.ToString() + "_" + System.DateTime.Today.Year;
                conn.oleDbConnection1.Close();
            }
                f2.label17.Show();
                f2.label18.Show();
                f2.label19.Show();
                f2.label20.Show();
                f2.label21.Show();
                f2.label22.Show();
                f2.textBox3.Show();
                f2.textBox4.Show();
                f2.textBox5.Show();
                f2.textBox6.Show();
                f2.textBox7.Show();
                f2.textBox8.Show();
                f2.button4.Show();
                f2.comboBox2.Hide();
 
        }

            public void enter_vendor_data()
            {
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into Vendor (VID,VName,VCode,PH1,CPName,VGroup) values (@VID,@VName,@VCode,@PH1,@CPName,@VGroup)");
                cmd.Parameters.AddWithValue("@VID",f2.textBox3.Text);
                cmd.Parameters.AddWithValue("",f2.textBox4.Text);
                cmd.Parameters.AddWithValue("",f2.textBox5.Text);
                cmd.Parameters.AddWithValue("",f2.textBox6.Text);
                cmd.Parameters.AddWithValue("",f2.textBox7.Text);
                cmd.Parameters.AddWithValue("",f2.textBox8.Text);
                //try
                //{
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendor Successfully Added");
                //}
               // catch (Exception ee)
                //{
                  //  MessageBox.Show("Error: "+ee);
                //}
                conn.oleDbConnection1.Close();
            }

            public void search_vendor_combo()
            {
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from Vendor where VGroup= '" + f2.comboBox3.Text + " ' ", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                f2.dataGridView1.Visible = true;
                DataTable dt = new DataTable();
                dt.Load(dr);
                f2.dataGridView1.DataSource = dt;
                conn.oleDbConnection1.Close();
            }

            public void Purchase_Order()
            {
                this.ad_hide();
                this.cs_hide();
                f2.label19.Hide();
                f2.label23.Show();
                f2.textBox9.Show();
                f2.textBox10.Show();
                f2.textBox11.Show();
                f2.textBox12.Show();
                f2.textBox14.Show();
                f2.dataGridView2.Show();
                f2.label24.Show();
                f2.label25.Show();
                f2.label26.Show();
                f2.label27.Show();
                f2.label28.Show();
                f2.label29.Show();
                f2.comboBox5.Show();
                f2.groupBox1.Show();
                f2.groupBox2.Show();
                f2.groupBox3.Hide();
                f2.comboBox10.Hide();

                {
                    conn.oleDbConnection1.Open();
                    f2.comboBox5.Items.Clear();
                    f2.textBox14.Text = "";
                    OleDbCommand cmd = new OleDbCommand("select * from Dept", conn.oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        f2.comboBox5.Items.Add(dr["deptname"]).ToString();
                    }
                    conn.oleDbConnection1.Close();
                }


                {
                    conn.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select VID from Vendor", conn.oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        f2.comboBox9.Items.Add(dr["VID"].ToString());
                    }
                    conn.oleDbConnection1.Close();
                }

                {
                    conn.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select Pid from Products", conn.oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        f2.comboBox8.Items.Add(dr["Pid"].ToString());
                    }
                    conn.oleDbConnection1.Close();
                }
            }

            public void po_id()
            {
                int c = 0;
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(POID) from PO where deptname= @deptname", conn.oleDbConnection1);
                cmd.Parameters.AddWithValue("@deptname", f2.comboBox5.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {                    
                    if (f2.comboBox5.Text == "Consumer")
                    {
                        c = Convert.ToInt32(dr[0]);
                        c++;
                        f2.textBox14.Text = "Cons_" + c.ToString() + "_" + System.DateTime.Today.Year;
                    }
                    if (f2.comboBox5.Text == "HR")
                    {
                        c = Convert.ToInt32(dr[0]);
                        c++;
                        f2.textBox14.Text = "HR_" + c.ToString() + "_" + System.DateTime.Today.Year;
                    }
                    if (f2.comboBox6.Text == "Marketing")
                    {
                        c = Convert.ToInt32(dr[0]);
                        c++;
                        f2.textBox14.Text = "MR_" + c.ToString() + "_" + System.DateTime.Today.Year;
                    }
                    if (f2.comboBox5.Text == "Sales")
                    {
                        c = Convert.ToInt32(dr[0]);
                        c++;
                        f2.textBox14.Text = "Sale_" + c.ToString() + "_" + System.DateTime.Today.Year;
                    }
                }
                conn.oleDbConnection1.Close();
            }

            public void add_purchaseorder()
            {
                prds[counter] = f2.comboBox8.Text;
                pprice[counter] = Convert.ToInt32(f2.textBox19.Text) * (qty[counter]);
                qty[counter] = Convert.ToInt32(f2.textBox18.Text);
                counter++;
            }

            public void enter_purchaseorder()
            {
             
                {   int i = 0;

                    conn.oleDbConnection1.Open();
                    for (i = 0; i < prds.Length; i++)
                    {
                        OleDbCommand cmd = new OleDbCommand("insert into POProducts (POID,Pid,Pprice,PQty) values(@POID,@Pid,@Pprice,@PQty)", conn.oleDbConnection1);
                        cmd.Parameters.AddWithValue("@POID", f2.comboBox9.Text);
                        cmd.Parameters.AddWithValue("@Pid", prds[i]);
                        cmd.Parameters.AddWithValue("@Pprice", qty[i]);
                        cmd.Parameters.AddWithValue("@PQty", pprice[counter]);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                    }
                    conn.oleDbConnection1.Close();
                }
            }

            public void show_purchaseorder()
            {
                    conn.oleDbConnection1.Open();
                    OleDbCommand cm = new OleDbCommand("Select * from POProducts", conn.oleDbConnection1);
                    OleDbDataReader dr = cm.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    f2.dataGridView2.DataSource = dt;
                    conn.oleDbConnection1.Close();
            }

            public void po_vid()
            {
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from Vendor where VID='" + f2.comboBox9.Text + "'", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    f2.textBox9.Text = dr["VName"].ToString();
                    f2.textBox10.Text = dr["VFax"].ToString();
                    f2.textBox11.Text = dr["CPName"].ToString();
                    f2.textBox12.Text = dr["PH1"].ToString();
                }
                conn.oleDbConnection1.Close();
            }

            public void po_model()
            {
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from Products where Pid='" + f2.comboBox8.Text + "'", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    f2.textBox20.Text = dr["PName"].ToString();
                    f2.textBox19.Text = dr["BasePrice"].ToString();
                }
                conn.oleDbConnection1.Close();
            }

            public void grn_data()
            {
                f2.groupBox3.Show();
                f2.button8.Show();
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select VID,SNO,DDate,VName,Status from PO where POID='" + f2.comboBox7.Text + "'", conn.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    f2.textBox21.Text = f2.comboBox7.Text;
                    f2.textBox23.Text = dr["VID"].ToString();
                    f2.textBox17.Text = dr["SNO"].ToString();
                    f2.textBox16.Text = dr["DDate"].ToString();
                    f2.textBox15.Text = dr["VName"].ToString();
                    f2.textBox13.Text = dr["Status"].ToString();
                    //f2.dateTimePicker3.Text = dr["GRDate"].ToString();
                }
                conn.oleDbConnection1.Close();
            }

            public void generate_grn()
            {
                conn.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into GRN (GRNID,POID,Status,VName,DDate,GRDate,SNO) values(@GRNID,@POID,@Status,@VName,@DDate,@GRDate,@SNO)", conn.oleDbConnection1);
                cmd.Parameters.AddWithValue("@GRNID", f2.textBox21.Text);
                cmd.Parameters.AddWithValue("@POID", f2.comboBox7.Text);
                cmd.Parameters.AddWithValue("@Status", f2.textBox13.Text);
                cmd.Parameters.AddWithValue("@VName", f2.textBox15.Text);
                cmd.Parameters.AddWithValue("@DDate", f2.textBox16.Text);
                cmd.Parameters.AddWithValue("@GRDate", f2.dateTimePicker3.Text);
                cmd.Parameters.AddWithValue("@SNO", f2.textBox17.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("GRN Created");
                conn.oleDbConnection1.Close();
            }

            public void invoice()
            {
                f2.groupBox4.Show();
                f2.comboBox10.Show();
            }
        

    }
}
