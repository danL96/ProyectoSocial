﻿#pragma checksum "..\..\PantallaLogin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "167CDE31783C15C99185EC6995EA7349"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ProyectoSocial.InterfazGrafica {
    
    
    /// <summary>
    /// PantallaLogin
    /// </summary>
    public partial class PantallaLogin : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\PantallaLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNick;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\PantallaLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwPass;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\PantallaLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\PantallaLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistro;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProyectoSocial.InterfazGrafica;component/pantallalogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PantallaLogin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\PantallaLogin.xaml"
            ((ProyectoSocial.InterfazGrafica.PantallaLogin)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MetroWindow_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtNick = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.pwPass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\PantallaLogin.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 31 "..\..\PantallaLogin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRegistro = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\PantallaLogin.xaml"
            this.btnRegistro.Click += new System.Windows.RoutedEventHandler(this.btnRegistro_Click);
            
            #line default
            #line hidden
            
            #line 32 "..\..\PantallaLogin.xaml"
            this.btnRegistro.Loaded += new System.Windows.RoutedEventHandler(this.btnRegistro_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

