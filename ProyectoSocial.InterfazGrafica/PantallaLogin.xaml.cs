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
    /// Lógica de interacción para PantallaLogin.xaml
    /// </summary>
    public partial class PantallaLogin
    {
        public bool Aceptado { get; set; }


        //Instancias bl y acceso a datos
        AdministradorBl _adminBL = new AdministradorBl();
        Administradore _adminEntity = new Administradore();

        public PantallaLogin()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
    
        {
            txtNick.Focus();
        }


        //Boton inicio de sesiòn
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtNick.Text == string.Empty)
            {
                string error = Convert.ToString(MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
            }
            if (pwPass.Password == string.Empty)
            {
                string error = Convert.ToString(MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
            }

            if (!(txtNick.Text == string.Empty || pwPass.Password == string.Empty))
            {

                if (_adminBL.ValidarAcceso(txtNick.Text ,pwPass.Password))
                {
                    Aceptado = true;
                    DialogResult = true;
                }
                else
                {
                    string error = Convert.ToString(MessageBox.Show("Usuario y/o clave no son correctos", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                    txtNick.Text = string.Empty;
                    pwPass.Password = string.Empty;
                    txtNick.Focus();
                }
            }
        }


        //Boton Cancelar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aceptado = false;
            DialogResult = true;
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            btnRegistro.Visibility = Visibility.Hidden;

            var regis = new Registro();
            regis.Show();
        }

        private void btnRegistro_Loaded(object sender, RoutedEventArgs e)
        {
            btnRegistro.Visibility = _adminBL.ObtenerTodos().Any() ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
