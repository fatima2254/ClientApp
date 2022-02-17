using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Admin_SSDA
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\Nabeel\Desktop\Questions - Copy.xlsx";

            filereader(path);
        }
        public static void filereader(string filepath) 
        {
            var stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet();
            var tables = result.Tables.Cast<DataTable>();
            foreach (DataTable table in tables) { 
            }
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();//open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)//if there is a file choosen by the user
            {
                filePath = file.FileName;//get the path of the file
                fileExt = Path.GetExtension(filePath);//get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt);//read excel file
                        //dataGridView1.Visible = false;
                        //dataGridView1.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//to close the window(Form3)
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);//here we read data from sheet1
                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                    //TextBox[] textBoxes = new TextBox[dtexcel.Rows.Count];
                    //Label[] labels = new Label[dtexcel.Rows.Count];

                    //for (int i = 0; i < dtexcel.Rows.Count; i++)
                    //{
                    //    textBoxes[i] = new TextBox();
                    //    // Here you can modify the value of the textbox which is at textBoxes[i]

                    //    labels[i] = new Label();
                    //    // Here you can modify the value of the label which is at labels[i]
                    //}

                    //// This adds the controls to the form (you will need to specify thier co-ordinates etc. first)
                    //for (int i = 0; i < dtexcel.Rows.Count; i++)
                    //{
                    //    this.Controls.Add(textBoxes[i]);
                    //    this.Controls.Add(labels[i]);
                    //}
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
