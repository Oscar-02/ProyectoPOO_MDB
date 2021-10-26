using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
//Extra libraries
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Windows_ClinicaDental
{
    public class sqlDataConnector
    {
        public static SettingsReader sqlSettings = new SettingsReader();
        public static bool SQLServerCnnTest() //Prueba si se puede conectar SQL Server
        {
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings,"master"));
            try
            {
                cnn.Open();
            }
            catch (SqlException)
            {
                return false;
            }
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static (bool, bool) SSdbChecker()
        {
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings, "master"));
            if (cnn.State == ConnectionState.Closed)
            {
                try
                {
                    cnn.Open();
                }
                catch (SqlException)
                {
                    return (false, false);
                }
            }
            if (cnn.State == ConnectionState.Open)
            {
                string checker = "SELECT DB_ID(@dbName)";
                SqlCommand cmd = new SqlCommand(checker, cnn);
                cmd.Parameters.AddWithValue("@dbName", "ClinicaDental");
                bool dbState = cmd.ExecuteScalar() is DBNull ? false : true;
                cnn.Close();
                return (true, dbState);
            }
            else return (false,false);
        }

        public static bool SSdbCreator()
        {
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings, "master"));
            try
            {
                cnn.Open();
            }
            catch (SqlException)
            {
                return false;
            }
            if (cnn.State == ConnectionState.Open)
            {
                string data = File.ReadAllText(Environment.CurrentDirectory + @"\DB_Creator.sql");
                Server server = new Server(new ServerConnection(cnn));
                server.ConnectionContext.ExecuteNonQuery(data);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class sqlLoginUser
    {
        public static SettingsReader sqlSettings = new SettingsReader();

        public string UserName {  get; set; }
        protected string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int JobPosition { get; set; }
        public int Role { get; set; }

        public static (bool,  int, sqlLoginUser) Login(string username, string password)
        {
            bool state = false;
            int message = 3;
            /*
             * message -1 : INICIO DE SESION CORRECTO
             * message 0 : Error - SQL Server
             * message 1 : Error - No username
             * message 2 : Error - pwd Incorrecta
             * message 3 : default
             */
            sqlLoginUser current = new sqlLoginUser();
            SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(sqlSettings, "ClinicaDental"));
            try
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open) state = true;
            }
            catch (SqlException)
            {
                state = false;
                message = 0;
            }
            if (state)
            {
                string cmdText = "SELECT * FROM SystemUsers WHERE username = @username";
                SqlCommand cmd = new SqlCommand(cmdText, cnn);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        current.UserName = reader["username"].ToString();
                        current.Password = reader["password"].ToString();
                        current.Name = reader["Name"].ToString();
                        current.LastName = reader["LastName"].ToString();
                        current.JobPosition = int.Parse(reader["ID_JobPosition"].ToString());
                        current.Role = int.Parse(reader["Role"].ToString());
                    }
                }
                else
                {
                    message = 1;
                }
                if (message > 1)
                {
                    //Encripta la contraseña ingresada en la pagina
                    String pwdEncrypted = "";
                    StringBuilder stringBuilder = new StringBuilder();
                    SHA256 converter = SHA256Managed.Create();
                    Encoding utf8 = Encoding.UTF8;
                    Byte[] finish = converter.ComputeHash(utf8.GetBytes(password));
                    //Completa de nuevo la contraseña ya encriptada
                    foreach (byte b in finish) stringBuilder.Append(b.ToString("x2"));
                    pwdEncrypted = stringBuilder.ToString();

                    if (current.Password == pwdEncrypted)
                    {
                        message = -1;
                    }
                    else
                    {
                        message = 2;
                        current = null;
                    }
                }
            }
            return (state,  message , current);
        }
        
    }
}
