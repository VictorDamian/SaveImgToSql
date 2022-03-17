using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveImgSql.Repositorios;
using System.Windows.Forms;

namespace SaveImgSql
{
    public partial class AgregarN : Form
    {
        public AgregarN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataImg obj = new DataImg();
            obj.Usr = textBox1.Text;
            obj.Email = textBox2.Text;
            obj.Con = textBox3.Text;
            obj.Img = ConvertImg();
            MessageBox.Show(obj.SaveC());
        }
        private byte[] ConvertImg()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            DialogResult dr = dl.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dl.FileName);
            }
        }
    }
}
