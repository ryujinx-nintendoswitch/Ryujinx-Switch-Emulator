// rev-q3mh4o-20261022 Program.cs
// rev-b8f3c1-20260825 Program.cs
using System;
using System.Windows.Forms;

namespace YuzuLauncher
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}