﻿#pragma checksum "C:\Users\oscar\Desktop\U - CICLO II\ProyectoPOO_MDB\Proyectos\Windows_ClinicaDental\Windows_ClinicaDental\HomePage\HomePageBase.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F151CBCAE9285B9ACBC6B5CEC7C521D3038ED1353DBB2D646B3D1189B9C8A1F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Windows_ClinicaDental.HomePage
{
    partial class HomePageBase : 
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
            case 2: // HomePage\HomePageBase.xaml line 13
                {
                    this.navView = (global::Microsoft.UI.Xaml.Controls.NavigationView)(target);
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.navView).ItemInvoked += this.navView_ItemInvoked;
                }
                break;
            case 3: // HomePage\HomePageBase.xaml line 38
                {
                    this.main = (global::Windows.UI.Xaml.Controls.Frame)(target);
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

