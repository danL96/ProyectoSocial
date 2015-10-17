using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class BuscarAdministrador
    {
        private readonly AdministradorBl _administradorBl = new AdministradorBl();

        public AdministradorViewModel Administrador { get; set; }

        public BuscarAdministrador()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgAdministrador.ItemsSource = _administradorBl.ObtenerTodos().Select(a => new AdministradorViewModel(a));
        }

        private void txtNombreAdministrador_TextChanged(object sender, TextChangedEventArgs e)
        {
            var administrador = new Administradore {Nombre = txtNombreAdministrador.Text};
            dgAdministrador.ItemsSource = _administradorBl.ObtenerAdministradoresPorNombre(administrador.Nombre);
        }

        private void dgAdministrador_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var adminViewModel = dgAdministrador.SelectedItem as AdministradorViewModel;
            if (adminViewModel != null)
            {
                Administrador = adminViewModel;
            }

            DialogResult = true;
        }
    }
}
