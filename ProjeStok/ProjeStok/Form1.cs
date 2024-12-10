using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace ProjeStok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8T4KVF8\\SQLLDERS;Initial Catalog=proje;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e) //Ekle butonu
        {
            string t1 = textBox1.Text; //Malzeme Kodu
            string t2 = textBox2.Text; //Malzeme Adı
            string t3 = textBox3.Text; //Yıllık satıs
            string t4 = textBox4.Text; //Birim fiyat
            string t5 = textBox5.Text; //Minimum stok
            string t6 = textBox1.Text; //Temin süresi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler(MalzemeKodu, MalzemeAdi, YillikSatis, BirimFiyat, MinStok, TeminSuresi) VALUES ('"+t1+ "','"+t2+ "','"+t3+ "','"+t4+ "','"+t5+ "','"+t6+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();

        }

         void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()//veritabanındaki kayıtların görüntülenmesini sağlar
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Malzemeler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Sil butonu
        {
            string t1 = textBox1.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('"+t1+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e) //Güncelle butonu
        {
            string t1 = textBox1.Text; //Malzeme Kodu
            string t2 = textBox2.Text; //Malzeme Adı
            string t3 = textBox3.Text; //Yıllık satıs
            string t4 = textBox4.Text; //Birim fiyat
            string t5 = textBox5.Text; //Minimum stok
            string t6 = textBox1.Text; //Temin süresi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='" + t1 + "',MalzemeAdi='" + t2+ "', YillikSatis='" + t3 + "', BirimFiyat='" + t4 + "', MinStok='" + t5 + "', TeminSuresi='" + t6 + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();

        }
    }
}
