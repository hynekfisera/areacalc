using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vypocetObsahu
{
    public partial class Form1 : Form
    {
        public List<Point> souradnice;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            souradnice = new List<Point>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (souradnice.Count < 2 || !(souradnice[0] == souradnice[souradnice.Count - 1])) souradnice.Add(((MouseEventArgs)e).Location);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (souradnice.Count > 1)
            {
                var g = e.Graphics;
                for (int i = 0; i < souradnice.Count - 1; i++)
                {
                    g.DrawLine(new Pen(Color.Black), souradnice[i], souradnice[i + 1]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (souradnice.Count > 2)
            {
                if (!(souradnice[0] == souradnice[souradnice.Count - 1]))
                {
                    souradnice.Add(souradnice[0]);
                    pictureBox1.Invalidate();
                }
                double obsah = 0;
                for (int i = 0; i < souradnice.Count - 2; i++)
                {
                    obsah += (souradnice[i].X * souradnice[i + 1].Y) - (souradnice[i + 1].X * souradnice[i].Y);
                }
                label1.Text = Convert.ToString(Math.Abs(obsah) / 2);
            }
            else
            {
                MessageBox.Show("Obrazec musí mít alespoň tři vrcholy aby ho bylo možné uzavřít");
            }
        }
    }
}
