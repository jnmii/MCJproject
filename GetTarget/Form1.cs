using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;


namespace GetTarget
{
    public partial class Form1 : Form
    {
        // Dictionary will be used as storage as long as the Id was used once and the app is still running
        private Dictionary<string, string> getTarget;

        public Form1()
        {
            InitializeComponent();
            getTarget = new Dictionary<string, string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetTargetFile("C:\\GetTarget\\TextFile1.txt");
        }

        private void GetTargetFile(string path)
        {
            // Confirm existence of the file first
            if (File.Exists(path))
            {
                try
                {
                    // Get into file and read each line
                    var lines = File.ReadAllLines(path);
                    foreach (var line in lines)
                    {
                        // Split each column on the ';'
                        var columns = line.Split(';');
                        if (columns.Length >= 2)
                        {
                            var id = columns[0];
                            var target = columns[1];
                            // Stores the ID and target match in the dictionary so it's saved
                            getTarget[id] = target;
                        }
                    }
                }
                // If an error occurs (no file/ bad file), show this error in a message box and inlcude an OK button
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading targets from file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //the event handler will 
        private void button1_Click_1(object sender, EventArgs e)
        {
            //id text in the text box from user
            string id = loadIdTextBox.Text;
            //if theres a matching ide to target
            if (getTarget.ContainsKey(id))
            {
                //display target on the target Label as text
                string target = getTarget[id];
                targetLabel.Text = target;
            }
            else
            {
                // If the ID isn't found, this sets the target at the clearing station
                string clearingStationTarget = "Clearing Station";
                targetLabel.Text = clearingStationTarget;
            }

        }
    }
}
