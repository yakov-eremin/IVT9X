using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4_QA
{
    public partial class Form1 : Form
    {
        public int[,] map = new int[4, 4];
        private Tile[,] tiles = new Tile[4, 4];
        private int score = 0;

        public Form1()
        {
            CreateMap();
            InitializeComponent();
        }

        private void CreateMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.Controls.Add(GenerateNullPic(i, j));
                }
            }
        }

        private PictureBox GenerateNullPic(int x, int y)
        {
            PictureBox pic = new PictureBox();
            pic.Location = new Point(12 + 56 * y, 73 + 56 * x);
            pic.Size = new Size(50, 50);
            pic.BackColor = Color.Gray;
            map[x, y] = 0;
            return pic;
        }

        private void CreateStartPics()
        {
            Random rnd = new Random();
            int x, y;
            for (int i = 0; i < 2; i++)
            {
                x = rnd.Next(0, 4);
                y = rnd.Next(0, 4);
                CreatePic(x, y);
            }
        }

        public void CreatePic(int x, int y)
        {
            map[x, y] = 1;
            tiles[x, y] = new Tile(x, y);
            tiles[x, y].Pic.Controls.Add(tiles[x, y].Label);
            this.Controls.Add(tiles[x, y].Pic);
            tiles[x, y].Pic.BringToFront();
        }

    }
}
