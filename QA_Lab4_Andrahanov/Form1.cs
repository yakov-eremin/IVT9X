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
        }
    }
}
