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

namespace ProyectoSocial.InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal
    {
        public PantallaPrincipal()
        {
            InitializeComponent();

            PantallaLogin _login = new PantallaLogin();
            _login.ShowDialog();
            if (_login.Aceptado)
            {
                MessageBox.Show("Bienvenido!! :D");
            }
            else
            {
                Close();
            }
        }


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        //Boton Registro Promotor

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrarPromotor _prom = new RegistrarPromotor();
            _prom.ShowDialog();
        }


        //Boton Registro Proyecto
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            RegistrarProyecto _pro = new RegistrarProyecto();
            _pro.ShowDialog();

        }


        //Boton Registro Adesco
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            RegistrarADESCO _ades = new RegistrarADESCO();
            _ades.ShowDialog();

        }


        //Boton Registro Administrador
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            RegistrarAdministrador _adm = new RegistrarAdministrador();
            _adm.ShowDialog();

        }


        //Boton Registro Admin
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            BuscarAdministrador _admi = new BuscarAdministrador();
            _admi.ShowDialog();

        }


        //Boton Registro Actividad
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            RegistrarActividad _act = new RegistrarActividad();
            _act.ShowDialog();

        }


        //Boton Registro Actividad
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            BuscarActividad _acti = new BuscarActividad();
            _acti.ShowDialog();
        }


        //Boton Registro Zona
        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            RegistrarZona _zon = new RegistrarZona();
            _zon.ShowDialog();
        }

        //Boton Buscar Zona

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            BuscarZona _zona = new BuscarZona();
            _zona.ShowDialog();
        }


        //Boton Registro PromProyecto
        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            RegistrarPromotorProyecto _regproy = new RegistrarPromotorProyecto();
            _regproy.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
            else
            {
                Close();
            }
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            FrmReportePromotor _rep = new FrmReportePromotor();
            _rep.ShowDialog();
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            BuscarPromotorProyecto _prompro = new BuscarPromotorProyecto();
            _prompro.ShowDialog();

        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            RegistrarPromotorZona _zonpro = new RegistrarPromotorZona();
            _zonpro.ShowDialog();
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            BuscarPromotorZona _zonprom = new BuscarPromotorZona();
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            RegistrarMiembroADESCO _miem = new RegistrarMiembroADESCO();
            _miem.ShowDialog();
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            BuscarMiembros _miemb = new BuscarMiembros();
            _miemb.ShowDialog();

        }

        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            RegistrarPromotor _promo = new RegistrarPromotor();
            _promo.ShowDialog();

        }

        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
            BuscarPromotor _prob = new BuscarPromotor();
            _prob.ShowDialog();

        }

        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            RegistrarProyecto _proye = new RegistrarProyecto();
            _proye.ShowDialog();

        }


        private void MenuItem_Click_21(object sender, RoutedEventArgs e)
        {
            BuscarProyecto _proyec = new BuscarProyecto();
            _proyec.ShowDialog();
        }

        private void MenuItem_Click_20(object sender, RoutedEventArgs e)
        {
            RegistrarADESCO _adesc = new RegistrarADESCO();
            _adesc.ShowDialog();

        }

        private void MenuItem_Click_22(object sender, RoutedEventArgs e)
        {
            BuscarADESCO _adescos = new BuscarADESCO();
            _adescos.ShowDialog();

        }

    

        }
    }

