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
    /// Lógica de interacción para Actividad.xaml
    /// </summary>
    public partial class BuscarActividad 
    {
        ActividadBL _actividadBL = new ActividadBL();
        public Actividade ActividadE { get; set; }

        public BuscarActividad()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgActividad.ItemsSource = _actividadBL.ObtenerActividades();
        }

        private void txtNombreActividad_TextChanged(object sender, TextChangedEventArgs e)
        {
            Actividade _actividad = new Actividade();
            _actividad.Nombre = txtNombreActividad.Text;

            dgActividad.ItemsSource = _actividadBL.ObtenerActividadesPorNombre(_actividad);
        }

        private void dgActividad_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ActividadE = dgActividad.SelectedItem as Actividade;
            DialogResult = true;
        }
    }
}
