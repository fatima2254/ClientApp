using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_SSDA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

       
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void signin_Click(object sender, EventArgs e)
        {
           if(name.Text.ToString().Length !=0 && rollno.Text.ToString().Length!=0 && txtusername.Text.ToString().Length!=0 && txtpass.Text.ToString().Length!=0)
            {
                GlobalConfig.UserID = name.Text.ToString();
                GlobalConfig.RollNumber = rollno.Text.ToString();
                if (verifyUserFromFile(txtusername.Text.ToString(), txtpass.Text.ToString()))
                {
                    studentData sd = new studentData();
                    sd.Show();
                    sd.MaximizeBox = false;
                    sd.MinimizeBox = false;
                    sd.WindowState = FormWindowState.Normal;
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else {
                    MessageBox.Show("invalid username or passwrod.;");
                }
            } else
            {
                string message = "Enter name and rollno.";
                string title = "Error";
               // string uservarify = "Enter Username and Password";
                MessageBox.Show(message, title);
            }



        }
        public bool verifyUserFromFile(string username, string password)
        {
            var userfound = false;
            var client = new HttpClient();
            var response = client.GetAsync(@"https://res.cloudinary.com/dhmzxoqi4/raw/upload/v1644607419/users.xlsx");
            var streammmm = response.Result.Content.ReadAsStreamAsync();
            var reader = ExcelReaderFactory.CreateReader(streammmm.Result);
            var result = reader.AsDataSet();
            var dtexcel = result.Tables.Cast<DataTable>();
            foreach (var row in dtexcel)
            {
                foreach (var r in row.Rows) 
                {
                    var u = ((System.Data.DataRow)r).ItemArray[0].ToString();
                    var p = ((System.Data.DataRow)r).ItemArray[1].ToString();
                    if (u == username && p == password)
                    {
                        userfound =  true;
                        break;
                        //MessageBox.Show("Login successful.");
                    }
                    else {
                        userfound =  false;   

                    }
                }
                //var test = row.Rows[1].ItemArray[0].ToString();
            }
            return userfound;



            
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
