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

        public double From0To2()
        {
            return 0.7112 * GetCurrent();
        }

    }
}
