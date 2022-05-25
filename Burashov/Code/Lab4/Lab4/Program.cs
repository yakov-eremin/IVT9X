using System;
using System.Windows.Forms;

namespace Lab4
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Calendar.Load("calendar.data");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.Run(new ListForm());
        }

        static void OnApplicationExit(object sender, EventArgs e)
        {
            Calendar.Save("calendar.data");
        }
    }
}
