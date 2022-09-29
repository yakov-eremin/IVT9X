using System;
using System.Drawing;
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
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            CreateMap();
            CreateStartPics();
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

        private void GenerateNewPic()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 4);
            int y = rnd.Next(0, 4);
            while (tiles[x, y] != null)
            {
                x = rnd.Next(0, 4);
                y = rnd.Next(0, 4);
            }
            CreatePic(x, y);
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

        private void RightKey()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (map[i, j] == 1)
                    {
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (map[i, k] == 0)
                            {
                                MovePic(i, k, 0, -1);
                            }
                            else
                            {
                                int a = int.Parse(tiles[i, k].Label.Text);
                                int b = int.Parse(tiles[i, k - 1].Label.Text);
                                if (a == b)
                                {
                                    UnitePic(a + b, i, k, 0, -1);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            GenerateNewPic();
        }

        private void LeftKey()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (map[i, j] == 1)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (map[i, k] == 0)
                            {
                                MovePic(i, k, 0, 1);
                            }
                            else
                            {
                                int a = int.Parse(tiles[i, k].Label.Text);
                                int b = int.Parse(tiles[i, k + 1].Label.Text);
                                if (a == b)
                                {
                                    UnitePic(a + b, i, k, 0, 1);
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            GenerateNewPic();
        }

        private void UpKey()
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map[i, j] == 1)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (map[k, j] == 0)
                            {
                                MovePic(k, j, 1, 0);
                            }
                            else
                            {
                                int a = int.Parse(tiles[k, j].Label.Text);
                                int b = int.Parse(tiles[k + 1, j].Label.Text);
                                if (a == b)
                                {
                                    UnitePic(a + b, k, j, 1, 0);
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            GenerateNewPic();
        }

        private void DownKey()
        {
            for (int i = 2; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map[i, j] == 1)
                    {
                        for (int k = i + 1; k < 4; k++)
                        {
                            if (map[k, j] == 0)
                            {
                                MovePic(k, j, -1, 0);
                            }
                            else
                            {
                                int a = int.Parse(tiles[k, j].Label.Text);
                                int b = int.Parse(tiles[k - 1, j].Label.Text);
                                if (a == b)
                                {
                                    UnitePic(a + b, k, j, -1, 0);
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            GenerateNewPic();
        }

        private void MovePic(int x, int y, int h, int w)
        {
            map[x, y] = 1;
            map[x + h, y + w] = 0;

            tiles[x, y] = tiles[x + h, y + w];
            tiles[x + h, y + w] = null;

            tiles[x, y].Pic.Location = new Point(tiles[x, y].Pic.Location.X + w * -1 * 56, tiles[x, y].Pic.Location.Y + h * -1 * 56);
        }

        private void UnitePic(int sum, int x, int y, int h, int w)
        {
            map[x + h, y + w] = 0;

            tiles[x, y].Label.Text = sum.ToString();
            score = tiles[x, y].SumScore(sum, score);
            tiles[x, y].ChangeColor(sum);
            label1.Text = "Score: " + score;

            this.Controls.Remove(tiles[x + h, y + w].Pic);
            this.Controls.Remove(tiles[x + h, y + w].Label);

            tiles[x + h, y + w] = null;
        }

            private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    RightKey();
                    break;
                case "Left":
                    LeftKey();
                    break;
                case "Up":
                    UpKey();
                    break;
                case "Down":
                    DownKey();
                    break;
            }
        }
    }
}
