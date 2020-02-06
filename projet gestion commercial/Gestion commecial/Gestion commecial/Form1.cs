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
	public partial class Form1 : Form
	{//constructeur
		public Form1()
		{
			InitializeComponent();
		}
		SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SMF5EAE\SEKHARSQL;Initial Catalog=GestionC;Integrated Security=True");
		private void button6_Click(object sender, EventArgs e)
		{
			clientBS.MoveFirst();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			con.Open();
			SqlCommand cmd = new SqlCommand("select * from Client where codel=1",con);
			SqlDataReader dr = cmd.ExecuteReader();
			//methode ()
			//propriete __
			while (dr.Read())
			{

				textBox1.Text = dr["codel"].ToString();
				textBox2.Text = dr["nom"].ToString();
				textBox3.Text = dr["ville"].ToString();

			}
			con.Close();
			//-----------------BS-----------
			DataTable dt = new DataTable();
			SqlCommand cmd2 = new SqlCommand("select * from Client", con);
			con.Open();
			SqlDataReader dr2 = cmd2.ExecuteReader();
			clientBS.DataSource = dt;
			dt.Load(dr2);

			textBox1.DataBindings.Add("Text", clientBS, "codel");
			textBox2.DataBindings.Add("Text", clientBS, "nom");
			textBox3.DataBindings.Add("Text", clientBS, "ville");
			dr.Close();
			dr2.Close();
			con.Close();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			clientBS.MovePrevious();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			clientBS.MoveNext();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			clientBS.MoveLast();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//gerer l'exepction
			try
			{

				con.Open();
				SqlCommand cmd = new SqlCommand("insert into Client  values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "')", con);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Ajout bien!");
				con.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			//vider les champs
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";

		}

		private void button2_Click(object sender, EventArgs e)
		{
			con.Open();
			SqlCommand cmd = new SqlCommand("update Client set nom='" + textBox2.Text + "',ville='" + textBox3.Text + "' where codel=" + textBox1.Text, con);
			cmd.ExecuteNonQuery();
			MessageBox.Show("Moifié bien!");
			con.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			con.Open();

			SqlCommand cmd = new SqlCommand("delete Client where codel = " + textBox1.Text, con);
			cmd.ExecuteNonQuery();
			MessageBox.Show("suppression bien!");
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";

			con.Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{

			con.Open();
			SqlCommand cmd = new SqlCommand("select * from Client where codel="+textBox4.Text, con);
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{

				textBox1.Text = dr["codel"].ToString();
				textBox2.Text = dr["nom"].ToString();
				textBox3.Text = dr["ville"].ToString();
				
			}
			con.Close();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			menu M = new menu();
			this.Hide();
			M.Show();
		}
	}
}
