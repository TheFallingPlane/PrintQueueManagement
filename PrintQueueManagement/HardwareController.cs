using System;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
namespace PrintQueueManagement
{
    static class HardwareController
    {


        private static int printJobCount = 0;
        private static int prevTotalJobsPrinted = 0;

        public static bool CheckIfBullzipIsActive()
        {
            var process = from Process p in Process.GetProcesses()
                          where p.ProcessName.Contains("gui")
                          select p;

            if ((process.FirstOrDefault()) != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SetPrintJobCount()
        {
            printJobCount = DatabaseController.GetLastPrintJobNumber();
        }

        public static void SetTotalJobCount(int totalJobCount)
        {
            prevTotalJobsPrinted = totalJobCount;
        }

        public static int CheckTotalJobs()
        {
            string query = "Select TotalJobsPrinted from Win32_PerfFormattedData_Spooler_PrintQueue Where Name = 'Bullzip PDF Printer'";

            ManagementObjectSearcher testSearcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection testCollection = testSearcher.Get();

            var testObject = from ManagementObject c in testCollection
                             select c.Properties["TotalJobsPrinted"];

            int totalJobCount = Convert.ToInt32(testObject.FirstOrDefault().Value);

            if (prevTotalJobsPrinted < totalJobCount)
            {
                prevTotalJobsPrinted = totalJobCount;
            }
            testSearcher.Dispose();
            return totalJobCount;

        }
        public static Label[] CheckPrintQueue(Label tempResultLabel, Label tempInfoLabel)
        {

            string query = "Select Jobs, TotalJobsPrinted from Win32_PerfFormattedData_Spooler_PrintQueue Where Name = 'Bullzip PDF Printer'";

            ManagementObjectSearcher printerSearcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection resultCollection = printerSearcher.Get();

            var propertyDataJobs = from ManagementObject c in resultCollection
                                   select c.Properties["Jobs"];
            var propertyDataTotalJobs = from ManagementObject x in resultCollection
                                        select x.Properties["TotalJobsPrinted"];

            int totalJobsPrinted = Convert.ToInt32(propertyDataTotalJobs.FirstOrDefault().Value);

            int jobQueueCount = Convert.ToInt32(propertyDataJobs.FirstOrDefault().Value);

            if (prevTotalJobsPrinted < totalJobsPrinted)
            {
               
                bool bullzipCheck = CheckIfBullzipIsActive();

                if (jobQueueCount.Equals(0))
                {

                    if (!bullzipCheck)
                    {
                        Console.WriteLine("bullzip dönüştürmeyi bitirdi");
                        prevTotalJobsPrinted = totalJobsPrinted;
                        tempResultLabel.ForeColor = Color.Green;
                        tempResultLabel.Text = "Müsait";
                        DatabaseController.UpdateDatabase(printJobCount, jobQueueCount);
                        printJobCount++;
                        DatabaseController.InsertIntoDatabase(printJobCount, jobQueueCount);
                        tempInfoLabel.Text = "Son yazdırılan iş no : " + (printJobCount - 1) + " Şimdiki iş no : " + printJobCount;
                        printerSearcher.Dispose();
                        return new Label[] { tempResultLabel, tempInfoLabel };

                    }
                    else
                    {
                        tempResultLabel.ForeColor = Color.Red;
                        tempResultLabel.Text = printJobCount.ToString();
                        printerSearcher.Dispose();
                        return new Label[] { tempResultLabel, tempInfoLabel };
                    }
                }
                else
                {
                    tempResultLabel.ForeColor = Color.Red;
                    tempResultLabel.Text = printJobCount.ToString();
                    DatabaseController.UpdateDatabase(printJobCount, jobQueueCount);
                    printerSearcher.Dispose();
                    return new Label[] { tempResultLabel, tempInfoLabel };
                }
            }
            else
            {
                tempResultLabel.ForeColor = Color.Green;
                tempResultLabel.Text = "Müsait";
                printerSearcher.Dispose();
                return new Label[] { tempResultLabel, tempInfoLabel };
            }
            
            

        }
    }
}
