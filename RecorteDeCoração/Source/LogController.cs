using System;
using System.Windows.Forms;

namespace RecorteDeCoração.Source
{
    class LogController
    {
        public static void Init()
        {
            LogController.ValidateAndCreate();
        }

        public static string LogPathString()
        {
            return FileController.AppendPath(FileController.AppDataDirectory(), "log/");
        }

        public static void ValidateAndCreate()
        {
            string path = LogController.LogPathString();

            if (FileController.NotExists(path)) {
                FileController.Create(path);
            }
        }

        public static string FileName(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();

            if (month.Length == 1) month = "0" + month;
            if (day.Length == 1) day = "0" + day;

            return FileController.AppendPath(LogController.LogPathString(), day + month + year + ".log");
        }

        public static string WriteException(Exception error)
        {
            DateTime now = DateTime.Now;
            string stack = "Date: " + now.ToString() + "\n";

            stack += "Message: \n\n" + error.Message + "\n\n";
            stack += "StackTrace: \n\n" + error.StackTrace.ToString() + "\n\n";

            FileController.Write(
                LogController.FileName(now),
                stack
            );

            return stack;
        }

        public static string WriteExceptionAndGetMessage(Exception error) {
            return LogController.WriteException(error);
        }

        public static DialogResult ErrorMessage(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
