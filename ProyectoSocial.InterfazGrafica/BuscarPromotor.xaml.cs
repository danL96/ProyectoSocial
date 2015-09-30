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
    /// Lógica de interacción para Promotor.xaml
    /// </summary>
    public partial class BuscarPromotor
    {
        PromotorBL _promotorBL = new PromotorBL();
        public Promotore PromotorE { get; set; }

        public BuscarPromotor()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgPromotor.ItemsSource = _promotorBL.ObtenerPromotores();
        }

        private void txtNombrePromotor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Promotore _promotor = new Promotore();
            _promotor.Nombre = txtNombrePromotor.Text;

            dgPromotor.ItemsSource = _promotorBL.ObtenerPromotoresPorNombre(_promotor);
        }

        private void dgPromotor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PromotorE = dgPromotor.SelectedItem as Promotore;
            DialogResult = true;
        }
    }
}
