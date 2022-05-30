using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QA_Lab4_Form
{
    enum Systems : int
    {
        OldRussian = 0,
        American = 1,
        SI = 2
    }
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>() { "Старорусская (аршин)", "Американская (ярд)", "СИ (метр)" };
            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i]);
                listBox2.Items.Add(list[i]);
            }
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

        public double FromOldRussianToAmerican()
        {
            return 0.7778 * GetCurrent();
        }

        public double FromSIToOldRussian()
        {
            return 1.4061 * GetCurrent();
        }

        public double FromSIToAmerican()
        {
            return 1.0936 * GetCurrent();
        }
    }
}
