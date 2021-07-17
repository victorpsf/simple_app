using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;

namespace RecorteDeCoração.src
{
    class FileController
    {
        public static bool Exists(string path)
        {
            bool exists = false;

            try {
                exists = File.Exists(path);                
            }

            catch (Exception error) {
                LogController.WriteException(error);
            }

            return exists;
        }

        public static bool NotExists(string path)
        {
            return !(FileController.Exists(path));
        }

        public static bool Write(string path, string content)
        {
            bool success = false;

            try {
                File.WriteAllText(path, content);
                success = true;
            }

            catch (Exception error) {
                LogController.WriteException(error);
            }

            return success;
        }

        public static string Read(string path)
        {
            try {
                return File.ReadAllText(path);
            }

            catch (Exception error) {
                LogController.WriteException(error);
                return "";
            }
        }

        public static bool Create(string path)
        {
            try {
                Directory.CreateDirectory(path);
                return true;
            }

            catch (Exception error) {
                LogController.WriteException(error);
                return false;
            }
        }
    }
}
