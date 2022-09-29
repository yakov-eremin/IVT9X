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
    }
}
