using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Extra libraries
using Microsoft.UI.Xaml.Controls;

namespace Windows_ClinicaDental
{
    public class InfoBar
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public InfoBarSeverity Severity { get; set; }

        public static void CreateInfoBar(InfoBar info)
        {
            var notifBar = MainPage.Current.notifBar;
            if (notifBar.IsOpen) notifBar.IsOpen = false;
            notifBar.Title = info.Title;
            notifBar.Content = info.Message + "\n";
            notifBar.Severity = info.Severity;
            notifBar.IsOpen = true;
        }
    }
}
