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
    /// Lógica de interacción para BuscarProyecto.xaml
    /// </summary>
    public partial class BuscarProyecto
    {
        ProyectoBL _proyectoBL = new ProyectoBL();
        public Proyecto ProyectoE { get; set; }

        public BuscarProyecto()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgProyecto.ItemsSource = _proyectoBL.ObtenerProyectos();
        }

        private void txtBuscarProyecto_TextChanged(object sender, TextChangedEventArgs e)
        {
            Proyecto _proyecto = new Proyecto();
            _proyecto.Nombre = txtBuscarProyecto.Text;

            dgProyecto.ItemsSource = _proyectoBL.ObtenerProyectosPorNombre(_proyecto);
        }

        private void dgProyecto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProyectoE = dgProyecto.SelectedItem as Proyecto;
            DialogResult = true;
        }
    }
}
