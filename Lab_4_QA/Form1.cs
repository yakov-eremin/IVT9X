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
            dataGridView1.Rows.Clear();
            Birthday birthday = new Birthday();
            birthday.UploadDates(dataGridView1);
        }
    }

    public class Birthday
    {
        public void UploadDates(DataGridView obj)
        {
            StreamReader f = new StreamReader("D:\\Desktop\\input.txt");
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                DateTime oDate = Convert.ToDateTime(s);
                string n = f.ReadLine();
                var current = DateTime.Today;
                int year = current.Month > oDate.Month || current.Month == oDate.Month && current.Day > oDate.Day
                   ? current.Year + 1 : current.Year;
                var days = (new DateTime(year, oDate.Month, oDate.Day) - current).TotalDays;
                obj.Rows.Add(oDate.Day + "." + oDate.Month + "." + oDate.Year, n, days);
            }
            f.Close();
        }

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
