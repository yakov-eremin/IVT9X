using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QA_Lab4_Form
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Birthday
    {
        public void AddDate(DateTimePicker dtp, TextBox tb)
        {
            string new_date = dtp.Text;
            string new_name = tb.Text;
            using (StreamWriter sw = File.AppendText("D:\\Desktop\\input.txt"))
            {
                sw.WriteLine(new_date);
                sw.WriteLine(new_name);
                sw.Close();
            }
        }
    }
}
