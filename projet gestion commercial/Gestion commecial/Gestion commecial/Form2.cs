using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data;

namespace Gestion_commecial
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SMF5EAE\SEKHARSQL;Initial Catalog=GestionC;Integrated Security=True");
		private void Form2_Load(object sender, EventArgs e)
		{

			con.Open();
			SqlCommand cmd = new SqlCommand("select * from Client", con);
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				comboBox1.Items.Add(dr[0]);
			}
			con.Close();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

			con.Open();
			SqlCommand cmd = new SqlCommand("select * from Client where codel="+comboBox1.Text, con);
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				
				textBox1.Text = dr["nom"].ToString();
				textBox2.Text = dr["ville"].ToString();

			}
			con.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			menu M = new menu();
			this.Hide();
			M.Show();
		}
	}
}
