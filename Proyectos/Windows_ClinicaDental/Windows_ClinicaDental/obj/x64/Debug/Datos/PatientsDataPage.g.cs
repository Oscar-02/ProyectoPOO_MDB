﻿#pragma checksum "C:\Users\oscar\Desktop\U - CICLO II\ProyectoPOO_MDB\Proyectos\Windows_ClinicaDental\Windows_ClinicaDental\Datos\PatientsDataPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F360B9D701A35126FA5D4E265F1C70B45D56F3D5FB7F04E5BDF88AFC40853EE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Windows_ClinicaDental.Datos
{
    partial class PatientsDataPage : 
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
            case 2: // Datos\PatientsDataPage.xaml line 88
                {
                    this.deleteList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.deleteList).Drop += this.deleteList_Drop;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.deleteList).DragOver += this.deleteList_DragOver;
                }
                break;
            case 3: // Datos\PatientsDataPage.xaml line 99
                {
                    this.clear = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.clear).Click += this.clear_Click;
                }
                break;
            case 4: // Datos\PatientsDataPage.xaml line 106
                {
                    this.finishAndRemove = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.finishAndRemove).Click += this.finishAndRemove_Click;
                }
                break;
            case 6: // Datos\PatientsDataPage.xaml line 68
                {
                    this.addList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.addList).SelectionChanged += this.addList_SelectionChanged;
                }
                break;
            case 8: // Datos\PatientsDataPage.xaml line 60
                {
                    this.finishAndUpdate = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.finishAndUpdate).Click += this.finishAndUpdate_Click;
                }
                break;
            case 9: // Datos\PatientsDataPage.xaml line 42
                {
                    this.toAdd = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // Datos\PatientsDataPage.xaml line 43
                {
                    this.addToList = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.addToList).Click += this.addToList_Click;
                }
                break;
            case 11: // Datos\PatientsDataPage.xaml line 50
                {
                    this.removeFromList = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.removeFromList).Click += this.removeFromList_Click;
                }
                break;
            case 12: // Datos\PatientsDataPage.xaml line 24
                {
                    this.listAllergies = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.listAllergies).DragItemsStarting += this.listAllergies_DragItemsStarting;
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

