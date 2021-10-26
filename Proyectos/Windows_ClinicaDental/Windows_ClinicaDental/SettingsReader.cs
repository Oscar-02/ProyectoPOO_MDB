using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Windows_ClinicaDental
{
    public class SettingsReader
    {
        #region SQL Settings Variables
        public string sqlLoginMode { get; }
        public string sqlPingMode { get; }
        public string sqlPingServer { get; }
        public string sqlUser { get; }
        public string sqlPwd { get; }
        #endregion


        public SettingsReader()
        {
            string[] read = File.ReadAllLines(Environment.CurrentDirectory + @"\app.config");
            foreach (string line in read)
            {
                if (line.StartsWith("sqlPingMode=")) sqlPingMode = line.Substring(line.IndexOf('=') + 1);
                if (line.StartsWith("sqlPingServer=")) sqlPingServer = line.Substring(line.IndexOf('=') + 1);
                if (line.StartsWith("sqlLoginMode=")) sqlLoginMode = line.Substring(line.IndexOf('=') + 1);
                if (line.StartsWith("sqlUser=")) sqlUser = line.Substring(line.IndexOf('=') + 1);
                if (line.StartsWith("sqlPwd=")) sqlPwd = line.Substring(line.IndexOf('=') + 1);
            }
        }

        //"Integrated Security=true; Initial Catalog=master; server=127.0.0.1,1433"
        public static string sqlCnnStringMaker(SettingsReader settings, string CatalogInit)
        {
            string authMode = settings.sqlLoginMode == "Windows" ? "Integrated Security=True" : "Integrated Security=False";
            string server = settings.sqlPingMode == "local" ? "Data Source=(local)" : "Data Source=" + settings.sqlPingServer;
            string intialCat = "Initial Catalog=" + CatalogInit;
            string cnnStr = server + ";" + authMode + ";" + intialCat + ";";
            if (settings.sqlLoginMode != "Windows")
            {
                cnnStr += "User Id=" + settings.sqlUser + ";" + "Password=" + settings.sqlPwd + ";";
            }
            return cnnStr;
        }
    }
}
