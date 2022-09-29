using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab_4_QA
{
    public class Tile
    {
        private Label label;
        public Label Label { get { return label; } set { label = value; } }

        private PictureBox pic;
        public PictureBox Pic { get { return pic; } set { pic = value; } }

        public Tile()
        {
            Label = new Label();
            Pic = new PictureBox();
        }

        public Tile(int x, int y)
        {
            label = new Label();
            pic = new PictureBox();
            label.Text = "2";
            label.Size = new Size(50, 50);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font(new FontFamily("Microsoft Sans Serif"), 15);
            pic.Location = new Point(12 + (y * 56), 73 + (56 * x));
            pic.Size = new Size(50, 50);
            pic.BackColor = Color.Yellow;
        }

        public int SumScore(int sum, int score)
        {
            return score + sum;
        }

        public void ChangeColor(int sum)
        {
            if (sum % 1024 == 0) pic.BackColor = Color.Pink;
            else if (sum % 512 == 0) pic.BackColor = Color.Red;
            else if (sum % 256 == 0) pic.BackColor = Color.DarkViolet;
            else if (sum % 128 == 0) pic.BackColor = Color.Blue;
            else if (sum % 64 == 0) pic.BackColor = Color.Brown;
            else if (sum % 32 == 0) pic.BackColor = Color.Coral;
            else if (sum % 16 == 0) pic.BackColor = Color.Cyan;
            else if (sum % 8 == 0) pic.BackColor = Color.Maroon;
            else pic.BackColor = Color.Green;
        }
    }
}
