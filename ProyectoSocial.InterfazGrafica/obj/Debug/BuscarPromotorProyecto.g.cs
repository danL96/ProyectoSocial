﻿#pragma checksum "..\..\BuscarPromotorProyecto.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1F28FC735760083833B70F18829735BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    /// BuscarPromotorProyecto
    /// </summary>
    public partial class BuscarPromotorProyecto : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\BuscarPromotorProyecto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPromProy;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\BuscarPromotorProyecto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgPromotorProy;
        
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
            System.Uri resourceLocater = new System.Uri("/ProyectoSocial.InterfazGrafica;component/buscarpromotorproyecto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BuscarPromotorProyecto.xaml"
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
            
            #line 5 "..\..\BuscarPromotorProyecto.xaml"
            ((ProyectoSocial.InterfazGrafica.BuscarPromotorProyecto)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MetroWindow_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtPromProy = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\BuscarPromotorProyecto.xaml"
            this.txtPromProy.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPromProy_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dgPromotorProy = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\BuscarPromotorProyecto.xaml"
            this.dgPromotorProy.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dgPromotorProy_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

