﻿#pragma checksum "C:\Users\oscar\Desktop\U - CICLO II\ProyectoPOO_MDB\Proyectos\Windows_ClinicaDental\Windows_ClinicaDental\Settings\Settings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6C9516377923730C6AF37371B0F62462ED2E575A0ACABB0B3A99A7B9CEDFD048"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Windows_ClinicaDental.Settings
{
    partial class Settings : 
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
            case 2: // Settings\Settings.xaml line 58
                {
                    this.cnnTest = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.cnnTest).Click += this.cnnTest_Click;
                }
                break;
            case 3: // Settings\Settings.xaml line 16
                {
                    this.cnnServerMode = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cnnServerMode).SelectionChanged += this.cnnServerMode_SelectionChanged;
                }
                break;
            case 4: // Settings\Settings.xaml line 20
                {
                    this.cnnIPInfo = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Settings\Settings.xaml line 28
                {
                    this.cnnPortInfo = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Settings\Settings.xaml line 36
                {
                    this.cnnLoginMode = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cnnLoginMode).SelectionChanged += this.cnnLoginMode_SelectionChanged;
                }
                break;
            case 7: // Settings\Settings.xaml line 41
                {
                    this.cnnSqlUser = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Settings\Settings.xaml line 49
                {
                    this.cnnSqlPwd = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
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

