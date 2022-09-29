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
            label = new Label();
            pic = new PictureBox();
        }

        public Tile(int x, int y)
        {
            
        }
    }
}
