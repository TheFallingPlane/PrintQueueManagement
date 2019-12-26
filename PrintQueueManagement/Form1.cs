using System;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace PrintQueueManagement
{
    public partial class Form1 : Form
    {
        Label[] resultLabelArray;
        Timer timer = new Timer()
        {
            Interval = 5000
        };

        public Form1()
        {
            InitializeComponent();
        }
        public void OnTimerEvent(object sender, EventArgs e)
        {
            resultLabelArray = HardwareController.CheckPrintQueue(printerStatusLabel, jobInfoLabel);
            printerStatusLabel = resultLabelArray[0];
            jobInfoLabel = resultLabelArray[1];

            if (printerStatusLabel.Text.Contains("Müsait"))
            {
                loadingGif.Hide();
                timer.Interval = 1000;
            }
            else
            {
                loadingGif.Show();
                timer.Interval = 10000;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int lastJobNumber = DatabaseController.GetLastPrintJobNumber();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int windowWidth = this.Bounds.Width;
            int windowHeight = this.Bounds.Height;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(screenWidth - windowWidth, (int)(screenHeight * 0.70));

            DatabaseController.InitializeDatabase();

            if (lastJobNumber == -1)
            {
                jobInfoLabel.Text = "İş no : 1";
                DatabaseController.AddFirstRow();
                FileController.ChangeIniFile(1);
            }
            else
            {
                jobInfoLabel.Text = "İş no : " + (lastJobNumber + 1);
                FileController.ChangeIniFile(lastJobNumber + 1);
                DatabaseController.InsertIntoDatabase(lastJobNumber + 1, 0);
            }

            HardwareController.SetPrintJobCount();

            printerStatusLabel.ForeColor = System.Drawing.Color.Green;
            printerStatusLabel.Text = "Müsait";

            compNameLabel.Text = "Bilgisayar adı : " + Environment.MachineName;



            HardwareController.SetTotalJobCount(HardwareController.CheckTotalJobs());
          
            timer.Enabled = true;
            timer.Tick += new EventHandler(OnTimerEvent);
        }
    }
}
