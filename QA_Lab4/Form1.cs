using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_QA
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
        }

        delegate void UpdateLabel(Label lbl, string value);
        void UpdateDataLabel(Label lbl, string value)
        {
            lbl.Text = value;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            timer.Start();
            label1.Text = "В процессе....";
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            label1.Text = "Стоп";
        }
    }
}
