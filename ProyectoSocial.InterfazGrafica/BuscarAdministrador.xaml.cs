<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

=======
﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
>>>>>>> Modificaciones-Pablo
using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class BuscarAdministrador
    {
<<<<<<< HEAD
        AdministradorBL _administradorBL = new AdministradorBL();
        public Administradore AdministradorE { get; set; }
=======
        private readonly AdministradorBl _administradorBl = new AdministradorBl();

        public AdministradorViewModel Administrador { get; set; }
>>>>>>> Modificaciones-Pablo

        public BuscarAdministrador()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            dgAdministrador.ItemsSource = _administradorBL.ObtenerAdministradores();
=======
            dgAdministrador.ItemsSource = _administradorBl.ObtenerTodos().Select(a => new AdministradorViewModel(a));
>>>>>>> Modificaciones-Pablo
        }

        private void txtNombreAdministrador_TextChanged(object sender, TextChangedEventArgs e)
        {
<<<<<<< HEAD
            Administradore _administrador = new Administradore();
            _administrador.Nombre = txtNombreAdministrador.Text;

            dgAdministrador.ItemsSource = _administradorBL.ObtenerAdministradoresPorNombre(_administrador);
=======
            var administrador = new Administradore {Nombre = txtNombreAdministrador.Text};
            dgAdministrador.ItemsSource = _administradorBl.ObtenerAdministradoresPorNombre(administrador.Nombre);
>>>>>>> Modificaciones-Pablo
        }

        private void dgAdministrador_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
<<<<<<< HEAD
            AdministradorE = dgAdministrador.SelectedItem as Administradore;
=======
            var adminViewModel = dgAdministrador.SelectedItem as AdministradorViewModel;
            if (adminViewModel != null)
            {
                Administrador = adminViewModel;
            }
>>>>>>> Modificaciones-Pablo
            DialogResult = true;
        }
    }
}
