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


namespace MovieArchiveExample
{
    public partial class Form1 : Form
    {
        //Data Source=DESKTOP-P1B8IEM\MSSQLSERVER1;Initial Catalog=DbSiparisUygulaması;Integrated Security=True
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P1B8IEM\MSSQLSERVER1;Initial Catalog=FilmArsivi;Integrated Security=True");

        void Filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFILMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Filmler();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLFILMLER (AD,KATEGORI,LINK) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", txtKategori.Text);
            komut.Parameters.AddWithValue("@P3", txtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listenize Eklenmiştir","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Filmler();


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();


            webBrowser1.Navigate(link);



        }

        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje 18 Aralık 2021 Tarihinde kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnRenkDeğiştir_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {

        }
    }
}
