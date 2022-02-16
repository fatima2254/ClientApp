using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ExcelDataReader;

namespace Admin_SSDA
{
    public partial class studentData : Form
    {
        public static Cloudinary cloudinary;
        private int _tick;
        public studentData()
        {
            InitializeComponent();
        }

        static Ping p = new Ping();
        static string host = "8.8.8.8";
        static byte[] buffer = new byte[32];
        static int timeout = 1000;
        static PingOptions po = new PingOptions();
        static PingReply pr;
        static bool load = false;
        public bool checkConnection()
        {
            pr = p.Send(host, timeout, buffer, po);
            return pr.Status == IPStatus.Success;
        }

        public async void connectionTask()
        {
            while (!checkConnection())
            {
                await System.Threading.Tasks.Task.Delay(200);
            }
            //player.Play();
            //label updated after connection
            label1.Text = "Connected";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string CLOUD_NAME = "dhmzxoqi4";
            string API_KEY = "124261996441551";
            string API_SECRET = "TBtx4XrlE29CWvhRoJ3whJ0kNyc";

            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            Console.WriteLine(path);
            //uploadFile(path + "\\DOC.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "Doc", "doc");
            //uploadFile(path + "\\log.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "log", "log");
            //Application.Exit();
        }
        public static void uploadFile(string path, string subfolder, string public_id, string type)
        {
            try
            {
                var uploadParams = new RawUploadParams()
                {
                    File = new FileDescription(path),
                    PublicId = public_id,
                    Folder = "studentLogs/" + subfolder
                };
                var ping = p.Send("google.com");
                var status = ping.Status.ToString();
                if (status == "Success")
                {
                    if (type == "doc")
                    {
                        var uploadResult = cloudinary.Upload(uploadParams);
                        Console.WriteLine(uploadResult.Uri);
                        if (uploadResult.StatusCode.ToString() == "OK")
                        {
                            MessageBox.Show("Submitted successfully.");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Unable to upload please try again.");
                        }
                    }
                    else
                    {
                        cloudinary.Upload(uploadParams);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to connect to internet. Please make sure you have internet connection and then upload exam again. Donot close this window or your exam will be terminated.");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to connect to internet. Please make sure you have internet connection and then upload exam again. Donot close this window or your exam will be terminated.");

                Console.WriteLine(e.Message);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _tick++;
            this.Text = _tick.ToString();
            if (_tick == 900)
            {
                t.Stop();
                timer1.Enabled = false;
                this.Text = "Done";

                MessageBox.Show("Time's Up");

                string CLOUD_NAME = "dhmzxoqi4";
                string API_KEY = "124261996441551";
                string API_SECRET = "TBtx4XrlE29CWvhRoJ3whJ0kNyc";

                Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
                cloudinary = new Cloudinary(account);
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Console.WriteLine(path);
                //uploadFile(path + "\\DOC.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "Doc", "doc");
                //uploadFile(path + "\\log.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "log", "log");

                //Application.Exit();
            }
        }
        System.Timers.Timer t;
        int h, m, s;
        public void filereader(string filepath)
        {
            var stream = File.Open(filepath, FileMode.Open, FileAccess.Read);



            var client = new HttpClient();
            var response = client.GetAsync(@"https://res.cloudinary.com/dhmzxoqi4/raw/upload/v1644969223/MCQs_File.xlsx");
            //if (response.Result.Content.ToString() == "Faulted")
            //{
            //    MessageBox.Show("You don't have internet connection please connect to stable internet connection first to proceed the exam.");
            //    return;
            //}
            var streammmm = response.Result.Content.ReadAsStreamAsync();

            var reader = ExcelReaderFactory.CreateReader(streammmm.Result);
            var result = reader.AsDataSet();
            var dtexcel = result.Tables.Cast<DataTable>();
            foreach (var row in dtexcel)
            {
                label1.Text = row.Rows[1].ItemArray[0].ToString();
                radioButton1.Text = row.Rows[1].ItemArray[1].ToString();
                radioButton2.Text = row.Rows[1].ItemArray[2].ToString();
                radioButton3.Text = row.Rows[1].ItemArray[3].ToString();
                radioButton4.Text = row.Rows[1].ItemArray[4].ToString();

                label2.Text = row.Rows[2].ItemArray[0].ToString();
                radioButton5.Text = row.Rows[2].ItemArray[1].ToString();
                radioButton6.Text = row.Rows[2].ItemArray[2].ToString();
                radioButton7.Text = row.Rows[2].ItemArray[3].ToString();
                radioButton8.Text = row.Rows[2].ItemArray[4].ToString();

                label3.Text = row.Rows[3].ItemArray[0].ToString();
                radioButton9.Text = row.Rows[3].ItemArray[1].ToString();
                radioButton10.Text = row.Rows[3].ItemArray[2].ToString();
                radioButton11.Text = row.Rows[3].ItemArray[3].ToString();
                radioButton12.Text = row.Rows[3].ItemArray[4].ToString();

                label4.Text = row.Rows[4].ItemArray[0].ToString();
                radioButton13.Text = row.Rows[4].ItemArray[1].ToString();
                radioButton14.Text = row.Rows[4].ItemArray[2].ToString();
                radioButton15.Text = row.Rows[4].ItemArray[3].ToString();
                radioButton16.Text = row.Rows[4].ItemArray[4].ToString();

                label5.Text = row.Rows[5].ItemArray[0].ToString();
                radioButton17.Text = row.Rows[5].ItemArray[1].ToString();
                radioButton18.Text = row.Rows[5].ItemArray[2].ToString();
                radioButton19.Text = row.Rows[5].ItemArray[3].ToString();
                radioButton20.Text = row.Rows[5].ItemArray[4].ToString();

                label6.Text = row.Rows[6].ItemArray[0].ToString();
                radioButton21.Text = row.Rows[6].ItemArray[1].ToString();
                radioButton22.Text = row.Rows[6].ItemArray[2].ToString();
                radioButton23.Text = row.Rows[6].ItemArray[3].ToString();
                radioButton24.Text = row.Rows[6].ItemArray[4].ToString();

                label7.Text = row.Rows[7].ItemArray[0].ToString();
                radioButton25.Text = row.Rows[7].ItemArray[1].ToString();
                radioButton26.Text = row.Rows[7].ItemArray[2].ToString();
                radioButton27.Text = row.Rows[7].ItemArray[3].ToString();
                radioButton28.Text = row.Rows[7].ItemArray[4].ToString();

                label8.Text = row.Rows[8].ItemArray[0].ToString();
                radioButton29.Text = row.Rows[8].ItemArray[1].ToString();
                radioButton30.Text = row.Rows[8].ItemArray[2].ToString();
                radioButton31.Text = row.Rows[8].ItemArray[3].ToString();
                radioButton32.Text = row.Rows[8].ItemArray[4].ToString();

                label9.Text = row.Rows[9].ItemArray[0].ToString();
                radioButton33.Text = row.Rows[9].ItemArray[1].ToString();
                radioButton34.Text = row.Rows[9].ItemArray[2].ToString();
                radioButton35.Text = row.Rows[9].ItemArray[3].ToString();
                radioButton36.Text = row.Rows[9].ItemArray[4].ToString();

                label10.Text = row.Rows[10].ItemArray[0].ToString();
                radioButton37.Text = row.Rows[10].ItemArray[1].ToString();
                radioButton38.Text = row.Rows[10].ItemArray[2].ToString();
                radioButton39.Text = row.Rows[10].ItemArray[3].ToString();
                radioButton40.Text = row.Rows[10].ItemArray[4].ToString();

                label11.Text = row.Rows[11].ItemArray[0].ToString();
                radioButton41.Text = row.Rows[11].ItemArray[1].ToString();
                radioButton42.Text = row.Rows[11].ItemArray[2].ToString();
                radioButton43.Text = row.Rows[11].ItemArray[3].ToString();
                radioButton44.Text = row.Rows[11].ItemArray[4].ToString();

                label12.Text = row.Rows[12].ItemArray[0].ToString();
                radioButton45.Text = row.Rows[12].ItemArray[1].ToString();
                radioButton46.Text = row.Rows[12].ItemArray[2].ToString();
                radioButton47.Text = row.Rows[12].ItemArray[3].ToString();
                radioButton48.Text = row.Rows[12].ItemArray[4].ToString();

                label13.Text = row.Rows[13].ItemArray[0].ToString();
                radioButton49.Text = row.Rows[13].ItemArray[1].ToString();
                radioButton50.Text = row.Rows[13].ItemArray[2].ToString();
                radioButton51.Text = row.Rows[13].ItemArray[3].ToString();
                radioButton52.Text = row.Rows[13].ItemArray[4].ToString();

                label14.Text = row.Rows[14].ItemArray[0].ToString();
                radioButton53.Text = row.Rows[14].ItemArray[1].ToString();
                radioButton54.Text = row.Rows[14].ItemArray[2].ToString();
                radioButton55.Text = row.Rows[14].ItemArray[3].ToString();
                radioButton56.Text = row.Rows[14].ItemArray[4].ToString();

                label15.Text = row.Rows[15].ItemArray[0].ToString();
                radioButton57.Text = row.Rows[15].ItemArray[1].ToString();
                radioButton58.Text = row.Rows[15].ItemArray[2].ToString();
                radioButton59.Text = row.Rows[15].ItemArray[3].ToString();
                radioButton60.Text = row.Rows[15].ItemArray[4].ToString();
                //i++;
                ques16.Text = row.Rows[16].ItemArray[0].ToString();
                radioButton126.Text = row.Rows[16].ItemArray[1].ToString();
                radioButton127.Text = row.Rows[16].ItemArray[2].ToString();
                radioButton123.Text = row.Rows[16].ItemArray[3].ToString();
                radioButton125.Text = row.Rows[16].ItemArray[4].ToString();

                ques17.Text = row.Rows[17].ItemArray[0].ToString();
                radioButton116.Text = row.Rows[17].ItemArray[1].ToString();
                radioButton117.Text = row.Rows[17].ItemArray[2].ToString();
                radioButton118.Text = row.Rows[17].ItemArray[3].ToString();
                radioButton120.Text = row.Rows[17].ItemArray[4].ToString();

                ques18.Text = row.Rows[18].ItemArray[0].ToString();
                radioButton112.Text = row.Rows[18].ItemArray[1].ToString();
                radioButton122.Text = row.Rows[18].ItemArray[2].ToString();
                radioButton124.Text = row.Rows[18].ItemArray[3].ToString();
                radioButton119.Text = row.Rows[18].ItemArray[4].ToString();

                ques19.Text = row.Rows[19].ItemArray[0].ToString();
                radioButton129.Text = row.Rows[19].ItemArray[1].ToString();
                radioButton130.Text = row.Rows[19].ItemArray[2].ToString();
                radioButton131.Text = row.Rows[19].ItemArray[3].ToString();
                radioButton128.Text = row.Rows[19].ItemArray[4].ToString();

                ques20.Text = row.Rows[20].ItemArray[0].ToString();
                radioButton114.Text = row.Rows[20].ItemArray[1].ToString();
                radioButton115.Text = row.Rows[20].ItemArray[2].ToString();
                radioButton121.Text = row.Rows[20].ItemArray[3].ToString();
                radioButton113.Text = row.Rows[20].ItemArray[4].ToString();

                ques21.Text = row.Rows[21].ItemArray[0].ToString();
                radioButton133.Text = row.Rows[21].ItemArray[1].ToString();
                radioButton134.Text = row.Rows[21].ItemArray[2].ToString();
                radioButton135.Text = row.Rows[21].ItemArray[3].ToString();
                radioButton132.Text = row.Rows[21].ItemArray[4].ToString();

                ques22.Text = row.Rows[22].ItemArray[0].ToString();
                radioButton137.Text = row.Rows[22].ItemArray[1].ToString();
                radioButton138.Text = row.Rows[22].ItemArray[2].ToString();
                radioButton136.Text = row.Rows[22].ItemArray[3].ToString();
                radioButton139.Text = row.Rows[22].ItemArray[4].ToString();

                ques23.Text = row.Rows[23].ItemArray[0].ToString();
                radioButton141.Text = row.Rows[23].ItemArray[1].ToString();
                radioButton142.Text = row.Rows[23].ItemArray[2].ToString();
                radioButton143.Text = row.Rows[23].ItemArray[3].ToString();
                radioButton140.Text = row.Rows[23].ItemArray[4].ToString();

                ques24.Text = row.Rows[24].ItemArray[0].ToString();
                radioButton93.Text = row.Rows[24].ItemArray[1].ToString();
                radioButton111.Text = row.Rows[24].ItemArray[2].ToString();
                radioButton144.Text = row.Rows[24].ItemArray[3].ToString();
                radioButton92.Text = row.Rows[24].ItemArray[4].ToString();

                ques25.Text = row.Rows[25].ItemArray[0].ToString();
                radioButton83.Text = row.Rows[25].ItemArray[1].ToString();
                radioButton84.Text = row.Rows[25].ItemArray[2].ToString();
                radioButton85.Text = row.Rows[25].ItemArray[3].ToString();
                radioButton86.Text = row.Rows[25].ItemArray[4].ToString();

                ques26.Text = row.Rows[26].ItemArray[0].ToString();
                radioButton91.Text = row.Rows[26].ItemArray[1].ToString();
                radioButton94.Text = row.Rows[26].ItemArray[2].ToString();
                radioButton82.Text = row.Rows[26].ItemArray[3].ToString();
                radioButton90.Text = row.Rows[26].ItemArray[4].ToString();

                ques27.Text = row.Rows[27].ItemArray[0].ToString();
                radioButton79.Text = row.Rows[27].ItemArray[1].ToString();
                radioButton80.Text = row.Rows[27].ItemArray[2].ToString();
                radioButton81.Text = row.Rows[27].ItemArray[3].ToString();
                radioButton78.Text = row.Rows[27].ItemArray[4].ToString();

               ques28.Text = row.Rows[28].ItemArray[0].ToString();
                radioButton75.Text = row.Rows[28].ItemArray[1].ToString();
                radioButton76.Text = row.Rows[28].ItemArray[2].ToString();
                radioButton74.Text = row.Rows[28].ItemArray[3].ToString();
                radioButton77.Text = row.Rows[28].ItemArray[4].ToString();

                ques29.Text = row.Rows[29].ItemArray[0].ToString();
                radioButton87.Text = row.Rows[29].ItemArray[1].ToString();
                radioButton88.Text = row.Rows[29].ItemArray[2].ToString();
                radioButton89.Text = row.Rows[29].ItemArray[3].ToString();
                radioButton73.Text = row.Rows[29].ItemArray[4].ToString();

                ques30.Text = row.Rows[30].ItemArray[0].ToString();
                radioButton108.Text = row.Rows[30].ItemArray[1].ToString();
                radioButton109.Text = row.Rows[30].ItemArray[2].ToString();
                radioButton110.Text = row.Rows[30].ItemArray[3].ToString();
                radioButton107.Text = row.Rows[30].ItemArray[4].ToString();


            }
        }
        private void studentData_Load(object sender, EventArgs e)
        {

            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;

            this.timer1.Enabled = true;
            t.Start();
            timer1.Start();
            string path = AppDomain.CurrentDomain.BaseDirectory 
 + "\\" + "Questions.xlsx";//@"https://res.cloudinary.com/dhmzxoqi4/raw/upload/v1644969223/MCQs_File.xlsx";//
            //string path = @"C:\Users\Nabeel\Desktop\Questions - Copy.xlsx";
            filereader(path);
            //StreamReader stream = new StreamReader(path);
            //string filedata = stream.ReadToEnd();
            //var filename = Path.GetFileName(path);
            //ReadExcel(path, filename.Split('.')[1].ToString());
            ////richTextBox1.Text = filedata.ToString();
            //stream.Close();
        }

        private void studentData_FormClosing(object sender, FormClosingEventArgs e)
        {
            string CLOUD_NAME = "dhmzxoqi4";
            string API_KEY = "124261996441551";
            string API_SECRET = "TBtx4XrlE29CWvhRoJ3whJ0kNyc";


            string message = "Do you want to submit exam";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
                cloudinary = new Cloudinary(account);
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Console.WriteLine(path);
                uploadFile(path + "\\DOC.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "Doc", "doc");
                uploadFile(path + "\\log.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "log", "log");
                //Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CLOUD_NAME = "dhmzxoqi4";
            string API_KEY = "124261996441551";
            string API_SECRET = "TBtx4XrlE29CWvhRoJ3whJ0kNyc";


            string message = "Do you want to submit exam";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
                cloudinary = new Cloudinary(account);
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Console.WriteLine(path);
                uploadFile(path + "\\DOC.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "Doc", "doc");
                uploadFile(path + "\\log.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "log", "log");
                //Application.Exit();
            }
            else if (result == DialogResult.No)
            {

            }

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string CLOUD_NAME = "dhmzxoqi4";
            string API_KEY = "124261996441551";
            string API_SECRET = "TBtx4XrlE29CWvhRoJ3whJ0kNyc";


            string message = "Do you want to submit exam";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
                cloudinary = new Cloudinary(account);
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Console.WriteLine(path);
                uploadFile(path + "\\DOC.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "Doc", "doc");
                uploadFile(path + "\\log.txt", GlobalConfig.UserID + "-" + GlobalConfig.RollNumber, "log", "log");
                //Application.Exit();
            }
            else if (result == DialogResult.No)
            {

            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton57_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void radioButton60_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton59_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton53_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton56_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton55_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton54_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void radioButton48_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton49_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton45_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton46_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void radioButton52_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton51_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton50_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton41_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void radioButton44_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton43_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton42_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton47_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton36_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton58_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox16_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton37_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void radioButton40_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton39_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton38_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton34_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton35_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton33_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void timerbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label119_Click(object sender, EventArgs e)
        {

        }

        private void label110_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton61_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void radioButton62_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton63_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton64_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton65_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void radioButton66_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton67_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton68_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton69_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void radioButton70_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton71_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton72_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton73_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton74_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques28_Click(object sender, EventArgs e)
        {

        }

        private void radioButton75_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton76_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton77_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton78_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques27_Click(object sender, EventArgs e)
        {

        }

        private void radioButton79_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton80_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton81_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton82_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton83_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques25_Click(object sender, EventArgs e)
        {

        }

        private void radioButton84_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton85_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton86_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }

        private void ques29_Click(object sender, EventArgs e)
        {

        }

        private void radioButton87_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton88_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton89_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton90_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques26_Click(object sender, EventArgs e)
        {

        }

        private void radioButton91_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox21_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton92_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques24_Click(object sender, EventArgs e)
        {

        }

        private void radioButton93_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton94_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox22_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton95_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void radioButton96_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton97_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton98_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void radioButton99_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton100_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton101_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox23_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox24_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton102_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton103_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void radioButton104_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton105_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton106_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox25_Enter(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void radioButton107_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques30_Click(object sender, EventArgs e)
        {

        }

        private void radioButton108_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton109_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton110_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox26_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton111_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton112_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton113_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques20_Click(object sender, EventArgs e)
        {

        }

        private void radioButton114_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton115_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques17_Click(object sender, EventArgs e)
        {

        }

        private void radioButton116_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton117_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton118_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton119_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton120_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton121_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques18_Click(object sender, EventArgs e)
        {

        }

        private void radioButton122_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques22_Click(object sender, EventArgs e)
        {

        }

        private void radioButton123_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton124_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton125_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton126_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton127_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton128_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques19_Click(object sender, EventArgs e)
        {

        }

        private void radioButton129_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton130_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox27_Enter(object sender, EventArgs e)
        {

        }

        private void ques16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox28_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox29_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox30_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton131_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox31_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox32_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton132_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques21_Click(object sender, EventArgs e)
        {

        }

        private void radioButton133_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton134_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton135_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox33_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton136_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton137_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton138_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton139_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox34_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton140_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ques23_Click(object sender, EventArgs e)
        {

        }

        private void radioButton141_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton142_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton143_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox35_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton144_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox36_Enter(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Invoke(new Action(() =>
                {

                    s += 1;
                    if (s == 60)
                    {
                        s = 0;
                        m += 1;
                    }
                    if (m == 60)
                    {
                        m = 0;
                        h += 1;
                    }

                    timerbox.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

                }));
            }
            catch (IOException)
            {


            }

        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            //if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
            //    conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Users\Nabeel\Desktop\Questions.xlsx" + ";Extended Properties=Excel 12.0;";//for below excel 2007
            //else
            //    conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Users\Nabeel\Desktop\Questions.xlsx" + ";Extended Properties=Excel 12.0;";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);//here we read data from sheet1
                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable

                    foreach (DataRow row in dtexcel.Rows)
                    {
                        label1.Text = row.ItemArray[0].ToString();
                        radioButton1.Text = row.ItemArray[1].ToString();
                        radioButton2.Text = row.ItemArray[2].ToString();
                        radioButton3.Text = row.ItemArray[3].ToString();
                        radioButton4.Text = row.ItemArray[4].ToString();

                        label2.Text = row.ItemArray[0].ToString();
                        radioButton5.Text = row.ItemArray[1].ToString();
                        radioButton6.Text = row.ItemArray[2].ToString();
                        radioButton7.Text = row.ItemArray[3].ToString();
                        radioButton8.Text = row.ItemArray[4].ToString();

                        label3.Text = row.ItemArray[0].ToString();
                        radioButton9.Text = row.ItemArray[1].ToString();
                        radioButton10.Text = row.ItemArray[2].ToString();
                        radioButton11.Text = row.ItemArray[3].ToString();
                        radioButton12.Text = row.ItemArray[4].ToString();

                        label4.Text = row.ItemArray[0].ToString();
                        radioButton13.Text = row.ItemArray[1].ToString();
                        radioButton14.Text = row.ItemArray[2].ToString();
                        radioButton15.Text = row.ItemArray[3].ToString();
                        radioButton16.Text = row.ItemArray[4].ToString();

                        label5.Text = row.ItemArray[0].ToString();
                        radioButton17.Text = row.ItemArray[1].ToString();
                        radioButton18.Text = row.ItemArray[2].ToString();
                        radioButton19.Text = row.ItemArray[3].ToString();
                        radioButton20.Text = row.ItemArray[4].ToString();

                        label6.Text = row.ItemArray[0].ToString();
                        radioButton21.Text = row.ItemArray[1].ToString();
                        radioButton22.Text = row.ItemArray[2].ToString();
                        radioButton23.Text = row.ItemArray[3].ToString();
                        radioButton24.Text = row.ItemArray[4].ToString();

                        label7.Text = row.ItemArray[0].ToString();
                        radioButton25.Text = row.ItemArray[1].ToString();
                        radioButton26.Text = row.ItemArray[2].ToString();
                        radioButton27.Text = row.ItemArray[3].ToString();
                        radioButton28.Text = row.ItemArray[4].ToString();

                        label8.Text = row.ItemArray[0].ToString();
                        radioButton29.Text = row.ItemArray[1].ToString();
                        radioButton30.Text = row.ItemArray[2].ToString();
                        radioButton31.Text = row.ItemArray[3].ToString();
                        radioButton32.Text = row.ItemArray[4].ToString();

                        label9.Text = row.ItemArray[0].ToString();
                        radioButton33.Text = row.ItemArray[1].ToString();
                        radioButton34.Text = row.ItemArray[2].ToString();
                        radioButton35.Text = row.ItemArray[3].ToString();
                        radioButton36.Text = row.ItemArray[4].ToString();

                        label10.Text = row.ItemArray[0].ToString();
                        radioButton37.Text = row.ItemArray[1].ToString();
                        radioButton38.Text = row.ItemArray[2].ToString();
                        radioButton39.Text = row.ItemArray[3].ToString();
                        radioButton40.Text = row.ItemArray[4].ToString();

                        label11.Text = row.ItemArray[0].ToString();
                        radioButton41.Text = row.ItemArray[1].ToString();
                        radioButton42.Text = row.ItemArray[2].ToString();
                        radioButton43.Text = row.ItemArray[3].ToString();
                        radioButton44.Text = row.ItemArray[4].ToString();

                        label12.Text = row.ItemArray[0].ToString();
                        radioButton45.Text = row.ItemArray[1].ToString();
                        radioButton46.Text = row.ItemArray[2].ToString();
                        radioButton47.Text = row.ItemArray[3].ToString();
                        radioButton48.Text = row.ItemArray[4].ToString();

                        label13.Text = row.ItemArray[0].ToString();
                        radioButton49.Text = row.ItemArray[1].ToString();
                        radioButton51.Text = row.ItemArray[2].ToString();
                        radioButton52.Text = row.ItemArray[3].ToString();
                        radioButton53.Text = row.ItemArray[4].ToString();

                        label14.Text = row.ItemArray[0].ToString();
                        radioButton53.Text = row.ItemArray[1].ToString();
                        radioButton54.Text = row.ItemArray[2].ToString();
                        radioButton55.Text = row.ItemArray[3].ToString();
                        radioButton56.Text = row.ItemArray[4].ToString();

                        label15.Text = row.ItemArray[0].ToString();
                        radioButton57.Text = row.ItemArray[1].ToString();
                        radioButton58.Text = row.ItemArray[2].ToString();
                        radioButton59.Text = row.ItemArray[3].ToString();
                        radioButton60.Text = row.ItemArray[4].ToString();
                        //i++;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return dtexcel;
        }
    }

}
