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
    /// Lógica de interacción para Miembros.xaml
    /// </summary>
    public partial class BuscarMiembros
    {
        MiembrosADESCOSBL _miembrosADESCOSBL = new MiembrosADESCOSBL();
        public MiembrosADESCO MiembrosE { get; set; }

        public BuscarMiembros()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgMiembros.ItemsSource = _miembrosADESCOSBL.ObtenerMiembrosADESCOS();
        }

        private void txtNombreMiembros_TextChanged(object sender, TextChangedEventArgs e)
        {
            MiembrosADESCO _miembro = new MiembrosADESCO();
            _miembro.Nombre = txtNombreMiembros.Text;

            dgMiembros.ItemsSource = _miembrosADESCOSBL.ObtenerMiembrosADESCOSPorNombre(_miembro);
        }

        private void dgMiembros_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MiembrosE = dgMiembros.SelectedItem as MiembrosADESCO;
            DialogResult = true;
        }
    }
}
