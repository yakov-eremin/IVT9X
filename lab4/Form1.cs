using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_lab4
{
    public partial class Form1 : Form
    {
        Number num = new Number();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            double _value = 0;
            _value = Convert.ToDouble(textBox1.Text);
            num.SetCurrent(_value);
            if ((listBox1.SelectedIndex == 0) && (listBox2.SelectedIndex == 2))
            {
                label2.Text = "Новое значение - " + (num.From0To2()).ToString();
            }
            if ((listBox1.SelectedIndex == 1) && (listBox2.SelectedIndex == 2))
            {
                label2.Text = "Новое значение - " + (num.From1To2()).ToString();
            }
            if ((listBox1.SelectedIndex == 0) && (listBox2.SelectedIndex == 1))
            {
                label2.Text = "Новое значение - " + (num.From0To1()).ToString();
            }
            if ((listBox1.SelectedIndex == 1) && (listBox2.SelectedIndex == 0))
            {
                label2.Text = "Новое значение - " + (num.From1To0()).ToString();
            }
            if ((listBox1.SelectedIndex == 2) && (listBox2.SelectedIndex == 0))
            {
                label2.Text = "Новое значение - " + (num.From2To0()).ToString();
            }
            if ((listBox1.SelectedIndex == 2) && (listBox2.SelectedIndex == 1))
            {
                label2.Text = "Новое значение - " + (num.From2To1()).ToString();
            }

            if (((listBox1.SelectedIndex == 0) && (listBox2.SelectedIndex == 0)) || ((listBox1.SelectedIndex == 1) && (listBox2.SelectedIndex == 1)) || ((listBox1.SelectedIndex == 2) && (listBox2.SelectedIndex == 2)))
            {
                label2.Text = "Новое значение - " + (num.GetCurrent()).ToString();
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
