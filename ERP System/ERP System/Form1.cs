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
    public partial class Form1 : Form
    {
        Myconn conn = new Myconn();
        String ue,up;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from users where username= '"+this.textBox1.Text+" ' AND upassword= '"+this.textBox2.Text+" ' ", conn.oleDbConnection1);
            try
            {
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ue = dr["username"].ToString();
                    up = dr["upassword"].ToString();
                    if (ue == this.textBox1.Text || up == this.textBox2.Text)
                    {
                        Form2 f2= new Form2();
                        f2.Show();
                    }
                }
                else
                {
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    MessageBox.Show("Email or Password is invalid");
                 
                }
            }
            catch (Exception ae)
            {
                MessageBox.Show(""+ae);
            }
            conn.oleDbConnection1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        }
    }
