using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lab4.Forms;

namespace Lab4
{
    public partial class ListForm : Form
    {
        private int currentDay = -1;

        public ListForm()
        {
            InitializeComponent();
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Application;
            System.Threading.Timer t = new System.Threading.Timer(TimerCallback, null, 0, 2000);
        }

        private void UpdateList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = Calendar.GetCalendar();
        }

        private void TimerCallback(Object o)
        {
            if (DateTime.Now.DayOfYear != currentDay)
            {
                currentDay = DateTime.Now.DayOfYear;
                List<Person> list = Calendar.Check(DateTime.Now);
                if (list.Count > 0)
                {
                    string message = "Сегодня день рождения у ";
                    for (int i = 0; i < list.Count; i++)
                    {
                        message += list[i].name + " (" + list[i].GetAge(DateTime.Now) + " лет) ";
                    }
                    notifyIcon1.ShowBalloonTip(5000, "Напоминание", message, ToolTipIcon.Info);
                }
            }
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InputForm input = new InputForm();
            if (input.ShowDialog() == DialogResult.OK)
            {
                Calendar.Add(new Person(input.PersonName, input.Date));
                UpdateList();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Calendar.Remove(listBox1.SelectedIndex);
                UpdateList();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Выберите человека из списка");
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void ListForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                this.ShowInTaskbar = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }
    }
}
