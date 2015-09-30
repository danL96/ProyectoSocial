using System;
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

using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class BuscarAdministrador
    {
        AdministradorBL _administradorBL = new AdministradorBL();
        public Administradore AdministradorE { get; set; }

        public BuscarAdministrador()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgAdministrador.ItemsSource = _administradorBL.ObtenerAdministradores();
        }

        private void txtNombreAdministrador_TextChanged(object sender, TextChangedEventArgs e)
        {
            Administradore _administrador = new Administradore();
            _administrador.Nombre = txtNombreAdministrador.Text;

            dgAdministrador.ItemsSource = _administradorBL.ObtenerAdministradoresPorNombre(_administrador);
        }

        private void dgAdministrador_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AdministradorE = dgAdministrador.SelectedItem as Administradore;
            DialogResult = true;
        }
    }
}
