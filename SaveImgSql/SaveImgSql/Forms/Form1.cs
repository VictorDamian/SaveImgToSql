using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveImgSql.Repositorios;
using SaveImgSql.Forms;
using System.Windows.Forms;
using System.IO;

namespace SaveImgSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form obj = new AgregarN();
            obj.Show();
        }
        DataImg obj = new DataImg();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.VerUsr();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }
        private MemoryStream ByteImage()
        {
            byte[] img = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
            MemoryStream ms = new MemoryStream(img);
            return ms;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tarjeta obj = new Tarjeta();
            obj.pictureBox1.Image = Image.FromStream(ByteImage());
            obj.label1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            obj.label2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            obj.label3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            obj.ShowDialog();
        }
    }
}
