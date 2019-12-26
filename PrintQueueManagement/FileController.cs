using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace PrintQueueManagement
{
    static class FileController
    {
        public static void ChangeIniFile(int jobNumber)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\PDF Writer\Bullzip PDF Printer\settings.ini", "settings.txt");
            StringBuilder newFile = new StringBuilder();
            string[] file = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\PDF Writer\Bullzip PDF Printer\settings.txt");
            string temp = "";
            foreach (string line in file)
            {
                if (line.Contains(@"output=\\ab00700-5699\"))

                {
                    temp = line.Replace(line, @"output=\\ab00700-5699\yazici\" + Environment.MachineName + @"\" + jobNumber.ToString() + ".pdf"); ;
                    newFile.Append(temp + "\r\n");
                    continue;
                }
                newFile.Append(line + "\r\n");
            }
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\PDF Writer\Bullzip PDF Printer\settings.txt", newFile.ToString());
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\PDF Writer\Bullzip PDF Printer\settings.txt", "settings.ini");
        }
    }
}
