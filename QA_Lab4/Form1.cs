using System;
using System.Windows.Forms;

namespace QA_Lab4_Form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
    }

    public class Number
    {
        private double _current = 1;

        public double GetCurrent()
        {
            return _current;
        }
    }
}
