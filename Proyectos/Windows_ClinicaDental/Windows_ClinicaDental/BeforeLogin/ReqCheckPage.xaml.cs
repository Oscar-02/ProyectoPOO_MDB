using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Extra librarys
using Microsoft.Win32;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Drawing.Text;
using System.Diagnostics;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.BeforeLogin
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ReqCheckPage : Page
    {
        public static ReqCheckPage Current;
        public ReqCheckPage()
        {
            this.InitializeComponent();
            Current = this;
            checker();
        }

        public static async void checker()
        {
            Current.actualProcessInfo.Text = "Verificando si SQL Server se encuentra instalado";
            await Task.Delay(1000);
            if (SQLServerCheck())
            {
                Current.actualProcessInfo.Text = "Verificando integridad de conexion a SQL Server";
                await Task.Delay(1000);
                (bool result, SqlException err) = sqlDataConnector.SQLServerCnnTest();
                if (result)
                {
                    Current.actualProcessInfo.Text = "Verificando la existencia de la base de datos";
                    await Task.Delay(1000);
                    (bool cnnState, bool dbState) = sqlDataConnector.SSdbChecker();
                    if (cnnState)
                    {
                        if (dbState)
                        {
                            Current.actualProcessInfo.Text = "Verificando si existen las fuentes requeridas";
                            await Task.Delay(1000);
                            //Verifica si las fuentes estan correctamente instaladas
                            bool fontState = false;
                            var fonts = Microsoft.Graphics.Canvas.Text.CanvasTextFormat.GetSystemFontFamilies();
                            foreach (var font in fonts)
                            {
                                if (font == "Segoe Fluent Icons") fontState = true;
                            }
                            if (!fontState)
                            {
                                Process.Start(Environment.CurrentDirectory + @"\SegoeIcons.ttf");
                                ContentDialog dialog = new ContentDialog();
                                dialog.Title = "Instalar nueva fuente";
                                dialog.Content = "Antes de continuar...\n" +
                                    "En estos momentos se acaba de mostrar una ventana de vista previa de fuentes. " +
                                    "Esto significa que en estos momentos no tienes la fuente requerida instalada en tu " +
                                    "PC / Cuenta de Usuario.\n" +
                                    "Para que puedas ver los iconos de la aplicacion de manera completa, necesitamos que instales la fuente requerida en la ventana.";
                                dialog.CloseButtonText = "Listo";
                                dialog.IsPrimaryButtonEnabled = false;
                                dialog.IsSecondaryButtonEnabled = false;
                                var close = await dialog.ShowAsync();
                                Current.actualProcessInfo.Text = "Finalizando e iniciando aplicacion";
                                await Task.Delay(1000);
                                MainPage.Current.content.Navigate(typeof(LoginPage.LoginPage));
                            }
                            Current.actualProcessInfo.Text = "Finalizando e iniciando aplicacion";
                            await Task.Delay(1000);
                            MainPage.Current.content.Navigate(typeof(LoginPage.LoginPage));
                        }
                        else
                        {
                            Current.actualProcessInfo.Text = "Creando base de datos. Puede que tarde un poco.";
                            await Task.Delay(1000);
                            cnnState = sqlDataConnector.SSdbCreator();
                            if (cnnState)
                            {
                                (_, dbState) = sqlDataConnector.SSdbChecker();
                                if (dbState)
                                {
                                    Current.actualProcessInfo.Text = "Verificando si existen las fuentes requeridas";
                                    await Task.Delay(1000);
                                    //Verifica si las fuentes estan correctamente instaladas
                                    bool fontState = false;
                                    var allFonts = new InstalledFontCollection();
                                    foreach (var font in allFonts.Families)
                                    {
                                        if (font.Name == "Segoe Fluent Icons") fontState = true;
                                    }
                                    if (!fontState)
                                    {
                                        Process.Start(Environment.CurrentDirectory + @"\SegoeIcons.ttf");
                                        ContentDialog dialog = new ContentDialog();
                                        dialog.Title = "Instalar nueva fuente";
                                        dialog.Content = "Antes de continuar...\n" +
                                            "En estos momentos se acaba de mostrar una ventana de vista previa de fuentes. " +
                                            "Esto significa que en estos momentos no tienes la fuente requerida instalada en tu " +
                                            "PC / Cuenta de Usuario.\n" +
                                            "Para que puedas ver los iconos de la aplicacion de manera completa, necesitamos que instales la fuente requerida en la ventana.";
                                        dialog.CloseButtonText = "Listo";
                                        dialog.IsPrimaryButtonEnabled = false;
                                        dialog.IsSecondaryButtonEnabled = false;
                                        var close = await dialog.ShowAsync();
                                        Current.actualProcessInfo.Text = "Finalizando e iniciando aplicacion";
                                        await Task.Delay(1000);
                                        MainPage.Current.content.Navigate(typeof(LoginPage.LoginPage));
                                    }
                                    Current.actualProcessInfo.Text = "Finalizando e iniciando aplicacion";
                                    await Task.Delay(1000);
                                    MainPage.Current.content.Navigate(typeof(LoginPage.LoginPage));
                                }
                                else
                                {
                                    Current.progressBar.ShowError = true;
                                    Current.errorInfo.Text = "No se ha logrado crear la base de datos.\n" +
                                        "Notifica al desarrollador de la aplicacion del inconveniente.";
                                    Current.errorBox.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                Current.progressBar.ShowError = true;
                                Current.errorInfo.Text = "No se ha logrado establecer conexion a SQL Server.\n" +
                                    "Verifica si los servicios relacionados a SQL Server han sido iniciados o\n" +
                                    "verifica desde SQL Server Configuration Manager si esta habilitada la conexion por TCP/IP.";
                                Current.errorBox.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    else
                    {
                        Current.progressBar.ShowError = true;
                        Current.errorInfo.Text = "No se ha logrado establecer conexion a SQL Server.\n" +
                            "Verifica si los servicios relacionados a SQL Server han sido iniciados o\n" +
                            "verifica desde SQL Server Configuration Manager si esta habilitada la conexion por TCP/IP.";
                        Current.errorBox.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    Current.progressBar.ShowError = true;
                    Current.errorInfo.Text = "No se ha logrado establecer conexion a SQL Server.\n" +
                        "Verifica si los servicios relacionados a SQL Server han sido iniciados o\n" +
                        "verifica desde SQL Server Configuration Manager si esta habilitada la conexion por TCP/IP.";
                    Current.errorBox.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Current.progressBar.ShowError = true;
                Current.errorInfo.Text = "Actualmente no tienes instalado SQL Server o tu instalacion esta incorrecta\n" +
                    "Intenta instalar o reinstalar SQL Server con su ultima version.\n";
                Current.errorBox.Visibility = Visibility.Visible;
            }
        }

        public static bool SQLServerCheck() //Revisando si SQL Server se encuentra instalado en la PC
        {
            
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server", false);
                if (instanceKey != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
