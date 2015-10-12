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
        private readonly AdministradorBL _administradorBl = new AdministradorBL();

        public Administradore AdministradorE { get; set; }

        public BuscarAdministrador()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgAdministrador.ItemsSource = _administradorBl.ObtenerAdministradores();
        }

        private void txtNombreAdministrador_TextChanged(object sender, TextChangedEventArgs e)
        {
            var administrador = new Administradore {Nombre = txtNombreAdministrador.Text};
            dgAdministrador.ItemsSource = _administradorBl.ObtenerAdministradoresPorNombre(administrador);
        }

        private void dgAdministrador_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AdministradorE = dgAdministrador.SelectedItem as Administradore;
            DialogResult = true;
        }
    }
}
