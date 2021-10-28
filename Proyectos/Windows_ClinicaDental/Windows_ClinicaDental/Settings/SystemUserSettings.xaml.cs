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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_ClinicaDental.Settings
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SystemUserSettings : Page
    {
        public static SystemUserSettings Current;

        public SystemUserSettings()
        {
            this.InitializeComponent();
            Current = this;
            scrollView.Height = Window.Current.CoreWindow.Bounds.Height;
            Window.Current.CoreWindow.SizeChanged += (sender, args) => scrollView.Height = Window.Current.CoreWindow.Bounds.Height;
            SystemUsers.GetSystemUsersList();
            JobPositions.GetJobPositionsList();
            Roles.GetRolesList();
            sysUsersList.ItemsSource = listSysUsers;
            JobPositionsList.ItemsSource = listJobPositions;
            RolesList.ItemsSource = listRoles;
        }

        public static List<SystemUsers> listSysUsers = new List<SystemUsers>();
        public static List<JobPositions> listJobPositions = new List<JobPositions>();
        public static List<Roles> listRoles = new List<Roles>();

        public class SystemUsers
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Position { get; set; }
            public string Role { get; set; }
            public string Cellphone { get; set; }
            public string LandLinePhone { get; set; }

            public static void GetSystemUsersList()
            {
                listSysUsers = new List<SystemUsers>();
                (bool state, var sysUserList) = sqlSystemUsers.GetTable();
                if (state)
                {
                    (_, var positionList) = sqlJobPosition.GetTable();
                    (_, var roleList) = sqlRoles.GetTable();
                    foreach (var user in sysUserList)
                    {
                        SystemUsers data = new SystemUsers();
                        data.Name = user.Name;
                        data.LastName = user.LastName;
                        foreach (var position in positionList) if (position.ID == user.ID_JobPosition) data.Position = position.Position;
                        foreach (var role in roleList) if (role.ID == user.Role) data.Role = role.Name;
                        data.Cellphone = user.Cellphone;
                        data.LandLinePhone = user.LandLinePhone;
                        listSysUsers.Add(data);
                    };
                }
            }
        }

        public class JobPositions
        {
            public string Position { get; set; }

            public static void GetJobPositionsList()
            {
                listJobPositions = new List<JobPositions>();
                (bool state, var jobPositions) = sqlJobPosition.GetTable();
                if (state)
                {
                    foreach(var position in jobPositions)
                    {
                        JobPositions data = new JobPositions();
                        data.Position = position.Position;
                        listJobPositions.Add(data);
                    }
                }
            }
        }

        public class Roles
        {
            public string Name { set; get; }
            public string Description { set; get; }
            public static void GetRolesList()
            {
                listRoles = new List<Roles>();
                (bool state, var list) = sqlRoles.GetTable();
                foreach (var role in list)
                {
                    Roles data = new Roles();
                    data.Name = role.Name;
                    data.Description = role.Description;
                    listRoles.Add(data);
                }
            }
        }
    }
}
