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
//Extra Libraries
using Microsoft.Data.SqlClient;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.Datos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PatientsDataPage : Page
    {
        public PatientsDataPage()
        {
            this.InitializeComponent();
            (_, var ListAllergies) = sqlAllergies.GetTable();
            List<string> updatedAllergies = new List<string>();
            foreach (var item in ListAllergies)
            {
                updatedAllergies.Add(item.Name);
            }
            listAllergies.ItemsSource = updatedAllergies;
        }

        #region Add Elements
        private void addList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (addList.SelectedIndex != -1) removeFromList.IsEnabled = true;
            else removeFromList.IsEnabled = false;
        }

        List<string> toAddItems = new List<string>();
        private void addToList_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(toAdd.Text))
            {
                infoBar error = new infoBar()
                {
                    Title = "Error al añadir a la lista",
                    Message = "Debes colocar un nombre para agregarlo",
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                toAddItems.Add(toAdd.Text);
                addList.ItemsSource = null;
                addList.ItemsSource = toAddItems;
            }
        }

        private void removeFromList_Click(object sender, RoutedEventArgs e)
        {
            string remove = addList.SelectedItem as string;
            toAddItems.Remove(remove);
            addList.ItemsSource = null;
            addList.ItemsSource = toAddItems;
        }

        private async void finishAndUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (toAddItems.Count <= 0)
            {
                infoBar error = new infoBar()
                {
                    Title = "No puedes añadir elementos",
                    Message = "No puedes actualizar debido a que no has agregado ninguna alergia a la lista.",
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                string cmdStr = "IF NOT EXISTS (SELECT * FROM [Allergies] WHERE Name = @allergy)\n" +
                                "INSERT INTO[Allergies] VALUES(@allergy)";
                foreach (string item in toAddItems)
                {
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@allergy", item);
                    await cmd.ExecuteNonQueryAsync();
                }
                HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsDataPage));
            }
        }

        #endregion
        #region Remove Elements
        private async void finishAndRemove_Click(object sender, RoutedEventArgs e)
        {
            if (deleteList.Items.Count <= 0)
            {
                infoBar error = new infoBar()
                {
                    Title = "No puedes remover elementos",
                    Message = "Debe de haber al menos un elemento en la lista. Arrastra un elemento de la lista original",
                    Severity = Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error
                };
                infoBar.CreateInfoBar(error);
            }
            else
            {
                SqlConnection cnn = new SqlConnection(SettingsReader.sqlCnnStringMaker(new SettingsReader(), "ClinicaDental"));
                cnn.Open();
                List<string> items = new List<string>();
                foreach(var item in deleteList.Items)
                {
                    items.Add(item as string);
                }
                foreach (string item in items)
                {
                    string cmdStr = "IF EXISTS (SELECT * FROM [Allergies] WHERE Name = @allergy)\n" +
                        "DELETE FROM [Allergies] WHERE Name = @allergy";
                    SqlCommand cmd = new SqlCommand(cmdStr, cnn);
                    cmd.Parameters.AddWithValue("@allergy", item);
                    await cmd.ExecuteNonQueryAsync();
                }
                HomePage.HomePageBase.Current.main.Navigate(typeof(PatientsDataPage));
            }
        }
        #endregion

        string elementDrag;
        private void listAllergies_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            elementDrag = e.Items[0] as string;
        }

        private void deleteList_Drop(object sender, DragEventArgs e)
        {
            if (!deleteList.Items.Contains(elementDrag))
            {
                deleteList.Items.Add(elementDrag);
            }
        }

        private void deleteList_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            deleteList.Items.Clear();
        }
    }
}
