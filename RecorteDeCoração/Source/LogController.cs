using System;

namespace RecorteDeCoração.Source
{
    class LogController
    {
        public static string FileName(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();

            if (month.Length == 1) month = "0" + month;
            if (day.Length == 1) day = "0" + day;

            return day + month + year + ".log";
        }

        public static void WriteException(Exception error, string content = null)
        {
            string path = "./log/";
            if (content == null) content = error.Message + "\n\n" + error.StackTrace;
            DateTime date = DateTime.Now;

            if (FileController.NotExists(path)) {
                FileController.Create(path);
            }

            FileController.Write(path + LogController.FileName(date), content);
        }

        public static string WriteExceptionAndGetMessage(Exception error) {
            string content = error.Message + "\n\n" + error.StackTrace;

            LogController.WriteException(error, content);
            return content;
        }
    }
}
