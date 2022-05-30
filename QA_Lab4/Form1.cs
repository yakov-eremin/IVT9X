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
        private double _current;

        public double GetCurrent()
        {
            return _current;
        }

        public void SetCurrent(double _value)
        {
            _current = _value;
        }

        public double FromOldRussianToSI()
        {
            return 0.7112 * GetCurrent();
        }

        public double FromAmericanToSI()
        {
            return 0.9114 * GetCurrent();
        }

        public double FromAmericanToOldRussian()
        {
            return 1.2857 * GetCurrent();
        }
    }
}
