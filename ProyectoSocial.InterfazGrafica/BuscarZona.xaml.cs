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
    /// Lógica de interacción para BuscarZona.xaml
    /// </summary>
    public partial class BuscarZona
    {
        ZonaBL _zonaBL = new ZonaBL();
        public Zona ZonaE { get; set; }

        public BuscarZona()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgZonas.ItemsSource = _zonaBL.ObtenerZonas();
        }

        private void txtBuscarZona_TextChanged(object sender, TextChangedEventArgs e)
        {
            Zona _zona = new Zona();
            _zona.Nombre = txtBuscarZona.Text;

            dgZonas.ItemsSource = _zonaBL.ObtenerZonasPorNombre(_zona);
        }

        private void dgZonas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ZonaE = dgZonas.SelectedItem as Zona;
            DialogResult = true;
        }
    }
}
