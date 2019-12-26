using System;
using System.Data.OleDb;

namespace PrintQueueManagement
{
    static class DatabaseController
    {
        static OleDbConnection databaseConnection;
        static OleDbCommand Command = new OleDbCommand();



        public static int GetLastPrintJobNumber()
        {
            int lastPrintJobNumber;
            databaseConnection = new OleDbConnection("Provider = Microsoft.Ace.Oledb.12.0; Data Source = test.mdb");
            databaseConnection.Open();
            Command.Connection = databaseConnection;

            Command.CommandText = "Select max(job_no) as job_no from testTable " +
                                  "where computer_name = '" + Environment.MachineName + "'";



            if (Command.ExecuteScalar().Equals(DBNull.Value))
            {
                databaseConnection.Close();
                Command.Dispose();
                return -1;
            }
            else
            {
                lastPrintJobNumber = Convert.ToInt32(Command.ExecuteScalar());
                databaseConnection.Close();
                Command.Dispose();
                return lastPrintJobNumber;
            }

        }


        public static void AddFirstRow()
        {
            databaseConnection = new OleDbConnection("Provider = Microsoft.Ace.Oledb.12.0; Data Source = test.mdb");
            databaseConnection.Open();
            Command.Connection = databaseConnection;

            Command.CommandText = "insert into testTable (computer_name , job_no , queue_count , dt , is_finished)" +
                                  "values (?,?,?,?,?)";
            Command.Parameters.AddWithValue("?", Environment.MachineName);
            Command.Parameters.AddWithValue("?", 1);
            Command.Parameters.AddWithValue("?", 0);
            Command.Parameters.AddWithValue("?", DateTime.Now.ToString("dd/MM/yyyy"));
            Command.Parameters.AddWithValue("?", "no");

            Command.ExecuteNonQuery();
            databaseConnection.Close();
            Command.Dispose();
        }

        public static void InitializeDatabase()
        {
            databaseConnection = new OleDbConnection("Provider= Microsoft.Ace.Oledb.12.0; Data Source = test.mdb");
            databaseConnection.Open();
            Command.Connection = databaseConnection;

            Command.CommandText = "update testTable set is_finished = 'yes' where is_finished = 'no'" +
                                  "and computer_name = '" + Environment.MachineName + "'";
            Command.ExecuteNonQuery();

            databaseConnection.Close();
            Command.Dispose();
        }


        public static void InsertIntoDatabase(int job_no, int queue_count)
        {
            databaseConnection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=test.mdb");
            databaseConnection.Open();
            Command.Connection = databaseConnection;
            Command.CommandText = "insert into testTable " +
                                  "(computer_name, " +
                                  "job_no, " +
                                  "queue_count, " +
                                  "dt, " +
                                  "is_finished) values" +
                                  "(@computer_name," +
                                  " @job_no, " +
                                  "@queue_count, " +
                                  "@dt, " +
                                  "@is_finished)";

            Command.Parameters.AddWithValue("@computer_name", Environment.MachineName.ToString());
            Command.Parameters.AddWithValue("@job_no", job_no);
            Command.Parameters.AddWithValue("@queue_count", queue_count);
            Command.Parameters.AddWithValue("@dt", DateTime.Now.ToString("dd/MM/yyyy"));
            Command.Parameters.AddWithValue("@is_finished", "no");

            Command.ExecuteNonQuery();
            databaseConnection.Close();
            Command.Dispose();
        }

        public static void UpdateDatabase(int job_no, int queue_count)
        {

            string isFinished;

            if (queue_count.Equals(0))
            {
                isFinished = "yes";
            }
            else
            {
                isFinished = "no";
            }




            databaseConnection = new OleDbConnection("Provider= Microsoft.Ace.Oledb.12.0; Data Source = test.mdb");
            databaseConnection.Open();
            Command.Connection = databaseConnection;

            Command.CommandText = "update testTable set " +
                                  "queue_count = " + queue_count +
                                  " , is_finished = '" + isFinished +
                                  "' where " +
                                  "(computer_name = '" + Environment.MachineName.ToString() +
                                  "' and job_no = " + job_no +
                                  " and dt = '" + DateTime.Now.ToString("dd/MM/yyyy") + "')";


            Command.ExecuteNonQuery();

            databaseConnection.Close();
            Command.Dispose();

        }
    }
}
