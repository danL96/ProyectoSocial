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
    /// Lógica de interacción para BuscarPromotorProyecto.xaml
    /// </summary>
    public partial class BuscarPromotorProyecto
    {
        PromotorProyectoBL _prompBL = new PromotorProyectoBL();
        public PromotorProyecto PromPE { get; set; }
        Promotore _promB = new Promotore();

        public BuscarPromotorProyecto()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgPromotorProy.ItemsSource = _prompBL.ObtenerPromotoresProyecto();
        }

        private void txtPromProy_TextChanged(object sender, TextChangedEventArgs e)
        {
            PromotorProyecto _promproy = new PromotorProyecto();
            _promproy.Promotore = _promB;

            dgPromotorProy.ItemsSource = _prompBL.ObtenerPromotoresProyectoPorNombre(_promproy);
        }

        private void dgPromotorProy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PromPE = dgPromotorProy.SelectedItem as PromotorProyecto;
            DialogResult = true;
        }
    }
}
