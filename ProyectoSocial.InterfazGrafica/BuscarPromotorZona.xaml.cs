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
    /// Lógica de interacción para BuscarPromotorZona.xaml
    /// </summary>
    public partial class BuscarPromotorZona
    {
        PromotorZonaBL _promzBL = new PromotorZonaBL();
        public PromotorZona PromzE { get; set; }
        Promotore _promB = new Promotore();

        public BuscarPromotorZona()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgPromotorZona.ItemsSource = _promzBL.ObtenerPromotoresZona();
        }

        private void txtProZona_TextChanged(object sender, TextChangedEventArgs e)
        {
            PromotorZona _promzona = new PromotorZona();
            _promzona.Promotore = _promB; 

            dgPromotorZona.ItemsSource = _promzBL.ObtenerPromotoresZonaPorNombre(_promzona);
        }

        private void dgPromotorZona_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PromzE = dgPromotorZona.SelectedItem as PromotorZona;
            DialogResult = true;

            

        }
    }
}
