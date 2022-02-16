using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace Admin_SSDA
{
    public partial class Form1 : Form
    {
        String constr = "", mood_path = "";
        String predict_python = "";
        public void XML()
        {
            XmlDocument xmlDoc = new XmlDocument();

            // Add XML file address below 
            xmlDoc.Load(@"D:\research\research\SSDA_project-main (1)\SSDA_project-main\XML\data.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/Meta_data");
            foreach (XmlNode node in nodeList)
            {
                constr = node.SelectSingleNode("DBstring").InnerText;
                mood_path = node.SelectSingleNode("mood_P").InnerText;
                predict_python = node.SelectSingleNode("Prediction").InnerText;

            }

        }
        

        public Form1()
        {

            XML();
            InitializeComponent();
            try
            {
                connection = new MySqlConnection(constr);
                connection.Open();
                String select_query = "SELECT DISTINCT Course FROM ssda.results ";
                command = new MySqlCommand(select_query, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (dataReader.Read())
                {
                    comboBox1.Items.Add(dataReader["Course"]);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }
        MySqlConnection connection;
        MySqlCommand command;
        private void Form1_Load(object sender, EventArgs e)
        { 
        }

        private void Save_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(constr);
                dataGridView1.Rows.Clear();
                connection.Open();
                String select_query = "SELECT Name,Detection,Time FROM ssda.results WHERE Name='" + comboBox3.Text + "' AND Course ='" + comboBox1.Text + "' AND Date ='" + comboBox2.Text + "' AND Start_Time ='" + comboBox4.Text +"'";
                command = new MySqlCommand(select_query, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dataReader["Name"] + "";
                    dataGridView1.Rows[n].Cells[1].Value = dataReader["Detection"] + "";
                    dataGridView1.Rows[n].Cells[2].Value = dataReader["Time"] + "";
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                String select_query = "SELECT DISTINCT Date FROM ssda.results WHERE Course='" + comboBox1.Text + "'";
                command = new MySqlCommand(select_query, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                comboBox2.Items.Clear();
                while (dataReader.Read())
                {
                    comboBox2.Items.Add(dataReader["Date"]);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                String select_query = "SELECT DISTINCT Name FROM ssda.results WHERE Date='" + comboBox2.Text + "' AND Course ='" + comboBox1.Text + "'";
                command = new MySqlCommand(select_query, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                comboBox3.Items.Clear();
                while (dataReader.Read())
                {
                    comboBox3.Items.Add(dataReader["Name"]);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                String select_query = "SELECT DISTINCT Start_Time FROM ssda.results WHERE Date='" + comboBox2.Text + "' AND Course ='" + comboBox1.Text + "' AND Name ='" + comboBox3.Text + "'";
                command = new MySqlCommand(select_query, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                comboBox4.Items.Clear();
                while (dataReader.Read())
                {
                    comboBox4.Items.Add(dataReader["Start_Time"]);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        String summary;
        private void button2_Click(object sender, EventArgs e)
        {
            String strCmdText = "/C "+ mood_path+" " + comboBox3.Text + " " + comboBox1.Text + " " + comboBox2.Text + " " + comboBox4.Text;
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            dataGridView1.Rows.Clear();
            connection.Open();
            String select_query = "SELECT Name,Detection,Time,Emotion FROM ssda.results WHERE Name='" + comboBox3.Text + "' AND Course ='" + comboBox1.Text + "' AND Date ='" + comboBox2.Text + "' AND Start_Time ='" + comboBox4.Text + "'";
            command = new MySqlCommand(select_query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            int detect = 0;
            int emotion = 0;
            int total = 0;
            int cnt = 0;
            int prev = 0;

            DateTime End_time = Convert.ToDateTime(comboBox4.Text);

            while (dataReader.Read())
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dataReader["Name"] + "";
                dataGridView1.Rows[n].Cells[1].Value = dataReader["Detection"] + "";
                dataGridView1.Rows[n].Cells[2].Value = dataReader["Time"] + "";
                dataGridView1.Rows[n].Cells[3].Value = dataReader["Emotion"] + "";

                if (Convert.ToString(dataReader["Detection"]) == "True")
                {
                    detect = detect + 1;
                    if (Convert.ToString(dataReader["Emotion"]) != " " && Convert.ToString(dataReader["Emotion"]) != "0")
                    {
                        emotion = emotion + 1;
                    }
                }
                
                
                cnt = cnt + 1;
                total = total + (Convert.ToInt32(dataReader["Time"]) - prev);
                prev = Convert.ToInt32(dataReader["Time"]);

            }
            End_time.AddSeconds(total);
            int average = total / cnt;
            summary = "The session started at "+ comboBox4.Text+ " and executed for " + (total/60) + " minutes, in this time a total of "+ cnt +" images were captured with the average time interval of "+ average+" seconds and from these "+cnt + " images "+ detect + " Faces was detected and "+emotion+" emotions was predicted.";
            dataReader.Close();
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(summary);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

         /*   try
            {

                ScriptEngine pythonEngine = Python.CreateEngine();
                ScriptSource pythonScript =
                    pythonEngine.CreateScriptSourceFromFile(@"D:\research\research\SSDA_project-main (1)\SSDA_project-main\Python\\cheatingprediction_finalversion.py");
                pythonScript.Execute();
        
            }
            catch (Exception)
            {

                throw;
            }*/

        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

    }
}
