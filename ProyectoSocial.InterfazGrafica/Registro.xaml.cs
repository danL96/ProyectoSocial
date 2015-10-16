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
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro
    {
        AdministradorBl _administradorBL = new AdministradorBl();
        Administradore _administradorEntity = new Administradore();

        public Registro()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            string salir = Convert.ToString(MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question));
            if (salir == "Yes")
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtNombre.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo nombre");
                }
                if (txtApellido.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo apellido");
                }
                if (txtNick.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo de Nick");
                }
                if (txtPass.Password == string.Empty)
                {
                    MessageBox.Show("Llene el campo password");
                }
                if (txtConfirmarpass.Password == string.Empty)
                {
                    MessageBox.Show("Llene el campo confirmar contraseña");
                }
                if (!(txtPass.Password == txtConfirmarpass.Password))
                {
                    MessageBox.Show("No coinciden los campos contraseña y confirmar contraseña\n" + "Vuelva a intentar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    if (!(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtNick.Text == string.Empty || txtPass.Password == string.Empty || txtConfirmarpass.Password == string.Empty))
                    {
                        Administradore _administrador = new Administradore();
                        _administrador.Nombre = txtNombre.Text;
                        _administrador.Apellido = txtApellido.Text;
                        _administrador.Nick = txtNick.Text;
                        _administrador.Pass = Utilidades.EncriptarClave(txtPass.Password);
                        _administrador.Confirmar = Utilidades.EncriptarClave(txtConfirmarpass.Password);
                        if (_administradorBL.Agregar(_administrador) > 0)
                        {
                            MessageBox.Show("El registro se agregó correctamente");
                            txtNombre.Clear();
                            txtApellido.Clear();
                            txtNick.Clear();
                            txtPass.Clear();
                            txtConfirmarpass.Clear();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos algo ocurrió mal" + "Advertencia" + ex.Message);
            }

        }
    }
        }
