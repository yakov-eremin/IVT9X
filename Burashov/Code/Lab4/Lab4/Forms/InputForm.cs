using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4.Forms
{
    public partial class InputForm : Form
    {
        public string PersonName
        {
            get { return textBox1.Text; }
        }

        public DateTime Date
        {
            get { return monthCalendar1.SelectionStart; }
        }

        public InputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && monthCalendar1.SelectionStart.Date <= DateTime.Now)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
