using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeChanger
{
    public partial class MainWindow : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        public readonly DateTime now;
        public static DateTime ChangingDate;
        public MainWindow()
        {
            InitializeComponent();
            now = DateTime.Now;
            ChangingDate = now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            var date = ChangingDate.AddDays(-7);
            SYSTEMTIME st = new SYSTEMTIME
            {
                wYear = (short)date.Year,
                wMonth = (short)date.Month,
                wDay = (short)date.Day,
                wHour = (short)date.Hour,
                wMinute = (short)date.Minute,
                wSecond = (short)date.Second
            };
            // must be short

            SetSystemTime(ref st); // invoke this method.
            ChangingDate = date;
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            var date = ChangingDate.AddDays(7);
            SYSTEMTIME st = new SYSTEMTIME
            {
                wYear = (short)date.Year,
                wMonth = (short)date.Month,
                wDay = (short)date.Day,
                wHour = (short)date.Hour,
                wMinute = (short)date.Minute,
                wSecond = (short)date.Second
            };
            // must be short

            SetSystemTime(ref st); // invoke this method.
            ChangingDate = date;

        }
    }
}
