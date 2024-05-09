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


namespace arena
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\HP\\source\\repos\\arena\\arenahalısaha.mdb");

        OleDbCommand komut = new OleDbCommand();


        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From bilgiler";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ad"].ToString();
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["takımadı1"].ToString());
                ekle.SubItems.Add(oku["takımadı2"].ToString());
                ekle.SubItems.Add(oku["tarih"].ToString());
                ekle.SubItems.Add(oku["ücret"].ToString());
                ekle.SubItems.Add(oku["saat"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }


        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "15:00-16:00";
            button1.BackColor = Color.MediumSeaGreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "17:00-18:00";
            button2.BackColor = Color.MediumSeaGreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "19:00-20:00";
            button3.BackColor = Color.MediumSeaGreen;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "21:00-22:00";
            button6.BackColor = Color.MediumSeaGreen;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "23:00-24:00";
            button5.BackColor = Color.MediumSeaGreen;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "00:00-01:00";
            button4.BackColor = Color.MediumSeaGreen;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into bilgiler (ad,soyad,telefon,takımadı1,takımadı2,tarih,ücret,saat) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + dateTimePicker1.Value.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            button1.BackColor = Color.DarkSeaGreen;
            button2.BackColor = Color.DarkSeaGreen;
            button3.BackColor = Color.DarkSeaGreen;
            button4.BackColor = Color.DarkSeaGreen;
            button5.BackColor = Color.DarkSeaGreen;
            button6.BackColor = Color.DarkSeaGreen;
            MessageBox.Show("Randevunuz başarıyla oluşturulmuştur.");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from bilgiler where telefon ='" + textBox5.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
            textBox5.Clear();
            MessageBox.Show("Randevunuz başarıyla silinmiştir.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = ("update bilgiler set ad='" + textBox1.Text + "',soyad='" + textBox2.Text + "',takımadı1='" + comboBox1.Text + "',takımadı2='" + comboBox2.Text + "',tarih='" + dateTimePicker1.Value + "',ücret='" + comboBox3.Text + "',saat='" + textBox3.Text + "' where telefon='" + textBox4.Text + "'");
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            button1.BackColor = Color.DarkSeaGreen;
            button2.BackColor = Color.DarkSeaGreen;
            button3.BackColor = Color.DarkSeaGreen;
            button4.BackColor = Color.DarkSeaGreen;
            button5.BackColor = Color.DarkSeaGreen;
            button6.BackColor = Color.DarkSeaGreen;
            MessageBox.Show("Randevunuz başarıyla güncellenmiştir.");
        }
    }
}
