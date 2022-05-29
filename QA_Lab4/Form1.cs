using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Lab4_Form
{
    public partial class MainForm : Form
    {
        Number num = new Number();
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

        private void button1_Click(object sender, EventArgs e)
        {
            int FirstIndex, SecondIndex;
            FirstIndex = listBox1.SelectedIndex;
            SecondIndex = listBox2.SelectedIndex;
            double _value;
            _value = Convert.ToDouble(textBox1.Text);
            num.SetCurrent(_value);
            switch (FirstIndex)
            {
                case 0:
                    if (SecondIndex == 0)
                        label2.Text = "Новое значение - " + num.GetCurrent().ToString();
                    else if (SecondIndex == 1)
                        label2.Text = "Новое значение - " + num.From0To1().ToString();
                    else if (SecondIndex == 2)
                        label2.Text = "Новое значение - " + num.From0To2().ToString();
                    break;
                case 1:
                    if (SecondIndex == 0)
                        label2.Text = "Новое значение - " + num.From1To0().ToString();
                    else if (SecondIndex == 1)
                        label2.Text = "Новое значение - " + num.GetCurrent().ToString();
                    else if (SecondIndex == 2)
                        label2.Text = "Новое значение - " + num.From1To2().ToString();
                    break;
                case 2:
                    if (SecondIndex == 0)
                        label2.Text = "Новое значение - " + num.From2To0().ToString();
                    else if (SecondIndex == 1)
                        label2.Text = "Новое значение - " + num.From2To1().ToString();
                    else if (SecondIndex == 2)
                        label2.Text = "Новое значение - " + num.GetCurrent().ToString();
                    break;
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

        public double From0To2()
        {
            return 0.7112 * GetCurrent();
        }

        public double From1To2()
        {
            return 0.9114 * GetCurrent();
        }

        public double From1To0()
        {
            return 1.2857 * GetCurrent();
        }

        public double From0To1()
        {
            return 0.7778 * GetCurrent();
        }

        public double From2To0()
        {
            return 1.4061 * GetCurrent();
        }

        public double From2To1()
        {
            return 1.0936 * GetCurrent();
        }
    }
}
