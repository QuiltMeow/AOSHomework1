using System;
using System.Windows.Forms;

namespace AOSHomework
{
    public static class Program
    {
        // 程式入口點
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}