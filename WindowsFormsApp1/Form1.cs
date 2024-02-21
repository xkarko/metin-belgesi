using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Dosyaları | *.txt";
            DialogResult cevap = ofd.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                txtEditor.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            DialogResult cevap = pd.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                belge.Print();
            }
        }

        private void menuKes_Click(object sender, EventArgs e)
        {
            txtEditor.Cut();
        }

        private void menuKopyala_Click(object sender, EventArgs e)
        {
            txtEditor.Copy();
        }

        private void menuYapistir_Click(object sender, EventArgs e)
        {
            txtEditor.Paste();
        }
        private void belge_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtEditor.Text, txtEditor.Font,
            Brushes.Black, new Point(100, 100));
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtEditor.Font = fd.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                txtEditor.SelectionColor = cd.Color;
            }
        }

        private void menuKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Dosyası | *.txt | Tüm Dosyalar | *.*";
            DialogResult cevap = sfd.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                txtEditor.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void menuCikis_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void menuCikiss_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
