using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackPropagaation
{
    public partial class MainForm : Form
    {
        Bitmap bmp;
        Graphics graph;
        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Red);
        SolidBrush wbrush = new SolidBrush(Color.White);

        int[] X = new int[25];

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pbMain.Width = 301;
            pbMain.Height = 301;
            bmp = new Bitmap(pbMain.Width, pbMain.Height);
            graph = Graphics.FromImage(bmp);

            graph.DrawLine(pen, 0, 0, 0, 300);
            graph.DrawLine(pen, 60, 0, 60, 300);
            graph.DrawLine(pen, 120, 0, 120, 300);
            graph.DrawLine(pen, 180, 0, 180, 300);
            graph.DrawLine(pen, 240, 0, 240, 300);
            graph.DrawLine(pen, 300, 0, 300, 300);


            graph.DrawLine(pen, 0, 0, 300, 0);
            graph.DrawLine(pen, 0, 60, 300, 60);
            graph.DrawLine(pen, 0, 120, 300, 120);
            graph.DrawLine(pen, 0, 180, 300, 180);
            graph.DrawLine(pen, 0, 240, 300, 240);
            graph.DrawLine(pen, 0, 300, 300, 300);

            for (int i = 0; i < X.Length; i++)
            {
                X[i] = -1;
            }

            pbMain.Image = bmp;
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int x = e.X;
            int y = e.Y;
            if (e.Button == MouseButtons.Left)
                DrawPixel(x, y);
            if (e.Button == MouseButtons.Right)
                RedrawPixel(x, y);
        }

        private void DrawPixel(int x, int y)
        {
            int px; // координаты пикселя в сетке
            int py;

            px = x / 60;
            py = y / 60;
            X[py * 5 + px] = 1;
            graph.FillRectangle(brush, 60 * px + 1, 60 * py + 1, 59, 59);
            pbMain.Image = bmp;
        }

        private void RedrawPixel(int x, int y)
        {
            int px; // координаты пикселя в сетке
            int py;

            px = x / 60;
            py = y / 60;
            X[px * 5 + py] = -1;
            graph.FillRectangle(wbrush, 60 * px + 1, 60 * py + 1, 59, 59);
            pbMain.Image = bmp;
        }
    }
}
