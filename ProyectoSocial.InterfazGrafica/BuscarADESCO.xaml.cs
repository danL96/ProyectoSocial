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
    /// Lógica de interacción para BuscarADESCO.xaml
    /// </summary>
    public partial class BuscarADESCO
    {
        ADESCOBL _adescoBL = new ADESCOBL();
        public ADESCO AdescoE { get; set; }

        public BuscarADESCO()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgADESCO.ItemsSource = _adescoBL.ObtenerADESCOS();
        }

        private void txtNombreADESCO_TextChanged(object sender, TextChangedEventArgs e)
        {
            ADESCO _adesco = new ADESCO();
            _adesco.Nombre = txtNombreADESCO.Text;

            dgADESCO.ItemsSource = _adescoBL.ObtenerADESCOSPorNombre(_adesco);
        }

        private void dgADESCO_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            AdescoE = dgADESCO.SelectedItem as ADESCO;
            DialogResult = true;
        }
    }
}
