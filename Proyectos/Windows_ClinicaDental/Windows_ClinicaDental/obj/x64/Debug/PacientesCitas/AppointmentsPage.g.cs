﻿#pragma checksum "C:\Users\oscar\Desktop\U - CICLO II\ProyectoPOO_MDB\Proyectos\Windows_ClinicaDental\Windows_ClinicaDental\PacientesCitas\AppointmentsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "026EE3F94E6AC6791A4F605C3467C65711BC7923926182E2CAE37F3FC4BAACA2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Windows_ClinicaDental.PacientesCitas
{
    partial class AppointmentsPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // PacientesCitas\AppointmentsPage.xaml line 57
                {
                    this.infoA = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // PacientesCitas\AppointmentsPage.xaml line 61
                {
                    this.patientA = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 4: // PacientesCitas\AppointmentsPage.xaml line 71
                {
                    this.systemUserA = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // PacientesCitas\AppointmentsPage.xaml line 81
                {
                    this.treatmentA = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 6: // PacientesCitas\AppointmentsPage.xaml line 82
                {
                    this.observationA = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // PacientesCitas\AppointmentsPage.xaml line 88
                {
                    this.save = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.save).Click += this.save_Click;
                }
                break;
            case 8: // PacientesCitas\AppointmentsPage.xaml line 85
                {
                    this.dateA = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                }
                break;
            case 9: // PacientesCitas\AppointmentsPage.xaml line 86
                {
                    this.hourA = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 12: // PacientesCitas\AppointmentsPage.xaml line 38
                {
                    this.appList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.appList).SelectionChanged += this.appList_SelectionChanged;
                }
                break;
            case 14: // PacientesCitas\AppointmentsPage.xaml line 34
                {
                    this.viewMode = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.viewMode).Toggled += this.viewMode_Toggled;
                }
                break;
            case 15: // PacientesCitas\AppointmentsPage.xaml line 18
                {
                    this.add = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 16: // PacientesCitas\AppointmentsPage.xaml line 20
                {
                    this.viewEdit = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 17: // PacientesCitas\AppointmentsPage.xaml line 21
                {
                    this.delete = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

