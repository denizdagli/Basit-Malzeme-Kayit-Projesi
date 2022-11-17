using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //veritabanı bağlantısı
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace malzemeKayitDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void listele()//veritabanındaki güncel kayıtları gösterir
        {
            baglanti.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select *from Malzemeler", baglanti);
            DataTable tablo = new DataTable();
            dataAdapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        //SQL connection global alanda yapılır
        SqlConnection  baglanti = new SqlConnection("Data Source= DDPC; Initial Catalog =MalzemeKayit; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {//EKLE
            String t1 = textBox1.Text; //malzeme kodu
            String t2 = textBox2.Text; //malzeme adı
            String t3 = textBox3.Text; //yillik satis
            String t4 = textBox4.Text; //birim fiyar
            String t5 = textBox5.Text; //minstok
            String t6 = textBox6.Text; //tsuresi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler (MalzemeKodu, MalzemeAdi, YillikSatis, BirimFiyat, MinStok, TSuresi) VALUES ('"+t1+"','" +t2 + "','"+t3+ "','"+t4+ "','"+t5+ "','"+t6+ "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {//SİL: malzeme koduna göre yapılır
            String t1 = textBox1.Text; 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE from Malzemeler WHERE MalzemeKodu= ('" + t1 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();


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

        private void button3_Click(object sender, EventArgs e)
        {//GÜNCELLE

            String t1 = textBox1.Text; //malzeme kodu
            String t2 = textBox2.Text; //malzeme adı
            String t3 = textBox3.Text; //yillik satis
            String t4 = textBox4.Text; //birim fiyar
            String t5 = textBox5.Text; //minstok
            String t6 = textBox6.Text; //tsuresi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeAdi= '" + t2 + "', YillikSatis = '" + t3 + "' ,BirimFiyat= '" + t4+ "', MinStok= '" + t5 + "', TSuresi = '" + t6 + "' WHERE MalzemeKodu='"+t1+"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
    }
}
