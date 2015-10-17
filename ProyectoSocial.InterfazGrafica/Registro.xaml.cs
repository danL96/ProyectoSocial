using System;
using System.Windows;
using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{

    public partial class Registro
    {

        public Registro()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) Close();         
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!Validate()) return;

                var pass = new ProyectoSocialEncrypter().EncryptString(txtPass.Password);

                var admin = new Administradore
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Nick = txtNick.Text,
                    Pass = pass,
                    Confirmar = pass
                };

                var adminBl = new AdministradorBl();

                if (adminBl.Agregar(admin) > 0)
                {
                    MessageBox.Show("El registro se agregó correctamente");
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtNick.Clear();
                    txtPass.Clear();
                    txtConfirmarpass.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos algo ocurrió mal" + "Advertencia" + ex.Message);
            }

        }

        private bool Validate()
        {
            var mensaje = string.Empty;
            if (txtNombre.Text == string.Empty)
            {
                mensaje = "Llene el campo nombre";
            }
            if (txtApellido.Text == string.Empty)
            {
                mensaje = "Llene el campo apellido";
            }
            if (txtNick.Text == string.Empty)
            {
                mensaje = "Llene el campo de Nick";
            }
            if (txtPass.Password == string.Empty)
            {
                mensaje = "Llene el campo password";
            }
            if (txtConfirmarpass.Password == string.Empty)
            {
                mensaje = "Llene el campo confirmar contraseña";
            }
            if (txtPass.Password != txtConfirmarpass.Password)
            {
                mensaje = "No coinciden los campos contraseña y confirmar contraseña\n Vuelva a intentar";
            }

            if (string.IsNullOrEmpty(mensaje)) return true;

            MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }
}
