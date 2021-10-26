using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Extra libraries
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.Settings
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public static SettingsReader reader = new SettingsReader();
        public Settings()
        {
            this.InitializeComponent();
            cnnServerMode.SelectedIndex = reader.sqlPingMode == "local" ? 0 : 1;
            cnnLoginMode.SelectedIndex = reader.sqlLoginMode == "Windows" ? 0 : 1;
            cnnIPInfo.Text = reader.sqlPingServer;
            cnnIPInfo.Visibility = cnnServerMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnPortInfo.Visibility = cnnIPInfo.Visibility;
            cnnSqlUser.Text = reader.sqlUser;
            cnnSqlPwd.Password = reader.sqlPwd;
            cnnSqlUser.Visibility = cnnLoginMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnSqlPwd.Visibility = cnnSqlUser.Visibility;
        }

        private void cnnServerMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cnnIPInfo.Visibility = cnnServerMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnPortInfo.Visibility = cnnIPInfo.Visibility;
        }

        private void cnnLoginMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cnnSqlUser.Visibility = cnnLoginMode.SelectedIndex == 0 ? Visibility.Collapsed : Visibility.Visible;
            cnnSqlPwd.Visibility = cnnSqlUser.Visibility;
        }

        private async void cnnTest_Click(object sender, RoutedEventArgs e)
        {
            string cnnString = "";
            cnnString = cnnServerMode.SelectedIndex == 0 ? "Data Source=(local);" : "Data Source=" + cnnIPInfo.Text + ";";
            cnnString += "Initial Catalog=ClinicaDental;";
            cnnString += cnnLoginMode.SelectedIndex == 0 ? "Integrated Security=True;" : 
                "Integrated Security=False;User Id=" + cnnSqlUser.Text + ";Password=" + cnnSqlPwd.Password;
            SqlConnection cnn = new SqlConnection(cnnString);
            try
            {
                cnn.Open();
            }
            catch (SqlException)
            {
                infoBar error = new infoBar()
                {
                    Title = "Error al conectar a la base de datos.",
                    Message = "Pueda que, las credenciales no sean las correctas; el servidor no exista o no se\n" +
                    "encuentre disponible; o incluso los servicios y/o configuracion TCP/IP de SQL Server no este\n" +
                    "habilitada. NO SE HA REALIZADO NINGUN CAMBIO.",
                    Severity = InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                ContentDiag diag = new ContentDiag()
                {
                    Title = "Conexion Exitosa.",
                    Content = "La conexion se ha realizado correctamente. ¿Deseas aplicar esta nueva configuracion " +
                    "desde ahora?\nEstos ajustes no se podra cambiar desde la aplicacion si no se logra la conexion al iniciarla.",
                    PrimBtnEnable = true,
                    PrimBtnText = "Guardar configuracion",
                    SecBtnEnable = false,
                    CloseBtnText = "No guardar",
                    DefaultBtn = 1            
                };
                ContentDialogResult result = await ContentDiag.DiagOpen(diag);
                if (result == ContentDialogResult.Primary)
                {
                    //AVERIGUAR QUE PUEDO HACER SI Enviroment.CurrentDirectory ES DE SOLO LECTURA AL MOMENTO DE EJECUCION
                    File.SetAttributes(Environment.CurrentDirectory + @"\app.config", FileAttributes.Normal);
                    File.WriteAllText(Environment.CurrentDirectory + @"\app.config", String.Empty);
                    StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + @"\app.config");
                    string pingMode = cnnServerMode.SelectedIndex == 0 ? "sqlPingMode=local" : "sqlPingMode=tcp";
                    string pingServer = cnnServerMode.SelectedIndex != 0 ? "sqlPingServer=" + cnnIPInfo + "," + cnnPortInfo : "sqlPingServer=";
                    string loginMode = cnnLoginMode.SelectedIndex == 0 ? "sqlLoginMode=Windows" : "sqlLoginMode=SQL";
                    string userPwd = cnnLoginMode.SelectedIndex != 0 ? "sqlUser=" + cnnSqlUser.Text + "\nsqlPwd=" + cnnSqlPwd.Password : "sqlUser=\nsqlPwd=";
                    writer.WriteLine(pingMode);
                    writer.WriteLine(pingServer);
                    writer.WriteLine(loginMode);
                    writer.WriteLine(userPwd);
                    HomePage.HomePageBase.Current.main.Navigate(typeof(Settings));
                    SettingsReader checker = new SettingsReader();
                    infoBar resultBar = new infoBar()
                    {
                        Title = "Datos guardados correctamente",
                        Message = "Se han guardado los datos correctamente. Esta es la nueva string de conexion:\n" +
                        SettingsReader.sqlCnnStringMaker(checker, "ClinicaDental"),
                        Severity = InfoBarSeverity.Success
                    };
                    infoBar.CreateInfoBar(resultBar);
                }
            }
        }
    }
}
