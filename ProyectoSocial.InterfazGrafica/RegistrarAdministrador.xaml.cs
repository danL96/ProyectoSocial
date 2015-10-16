using System;
using System.Windows;
using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para RegistrarAdministrador.xaml
    /// </summary>
    public partial class RegistrarAdministrador
    {
        readonly AdministradorBl _administradorBl = new AdministradorBl();

        public RegistrarAdministrador()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes) Close();
        }

        private void Actualizar()
        {
            txtId.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtNick.IsEnabled = false;
            txtPass.IsEnabled = false;
            txtConfirmarpass.IsEnabled = false;

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNick.Text = string.Empty;
            txtPass.Password = string.Empty;
            txtConfirmarpass.Password = string.Empty;

            btnNuevo.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtConfirmarpass.Visibility = Visibility.Visible;
            lbConfirmar.Visibility = Visibility.Visible;

            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtNick.IsEnabled = true;
            txtPass.IsEnabled = true;
            txtConfirmarpass.IsEnabled = true;
            txtNombre.Focus();
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Validate()) return;

                var administrador = new Administradore
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Nick = txtNick.Text,
                    Pass = Utilidades.EncriptarClave(txtPass.Password),
                    Confirmar = Utilidades.EncriptarClave(txtConfirmarpass.Password)
                };

                if (_administradorBl.Agregar(administrador) > 0)
                {
                    MessageBox.Show("El registro se agregó correctamente");
                }

                Actualizar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el registro" + "Advertencia" + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Validate()) return;

                var administrador = new Administradore
                {
                    Id = Convert.ToInt64(txtId.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Nick = txtNick.Text,
                    Pass = Utilidades.EncriptarClave(txtPass.Password)
                };


                if (_administradorBl.Modificar(administrador) > 0)
                {
                    MessageBox.Show("El registro se modificó correctamente");
                }

                Actualizar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar el registro\n" + "Advertencia" + ex.Message);
            }
        }

        private bool Validate()
        {
            var msgError = string.Empty;

            if (txtNombre.Text == string.Empty)
            {
                msgError = "Llene el campo nombre";
            }
            if (txtApellido.Text == string.Empty)
            {
                msgError = "Llene el campo apellido";
            }
            if (txtNick.Text == string.Empty)
            {
                msgError = "Llene el campo de Nick";
            }
            if (txtPass.Password == string.Empty)
            {
                msgError = "Llene el campo password";
            }

            if (txtConfirmarpass.Visibility == Visibility.Visible)
            {
                if (txtConfirmarpass.Password == string.Empty)
                {
                    msgError = "Llene el campo confirmar contraseña";
                }
                if (txtPass.Password != txtConfirmarpass.Password)
                {
                    msgError = "No coinciden los campos contraseña y confirmar contraseña";
                }
            }

            if (string.IsNullOrEmpty(msgError)) return true;

            MessageBox.Show(msgError, "Vuelva a intentar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var confirmDelete = MessageBox.Show("Está seguro que desea eliminar", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;

                if (!confirmDelete) return;

                var administrador = new Administradore
                {
                    Id = Convert.ToInt64(txtId.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Nick = txtNick.Text,
                    Pass = Utilidades.EncriptarClave(txtPass.Password),
                    Confirmar = Utilidades.EncriptarClave(txtConfirmarpass.Password)
                };

                if (_administradorBl.Eliminar(administrador) > 0)
                {
                    MessageBox.Show("El registro se eliminó con éxito");
                    Actualizar();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos, algo ocurrió mal, no se pudo realizar la operación" + "Advertencia" + ex.Message);
            }
        }


        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            txtConfirmarpass.Visibility = Visibility.Hidden;
            lbConfirmar.Visibility = Visibility.Hidden;

            var bus = new BuscarAdministrador();
            bus.ShowDialog();

            txtId.Text = bus.AdministradorE.Id.ToString();
            txtNombre.Text = bus.AdministradorE.Nombre;
            txtApellido.Text = bus.AdministradorE.Apellido;
            txtNick.Text = bus.AdministradorE.Nick;
            txtPass.Password = bus.AdministradorE.Pass;
            txtConfirmarpass.Password = bus.AdministradorE.Confirmar;

            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtNick.IsEnabled = true;
            txtPass.IsEnabled = true;
            txtConfirmarpass.IsEnabled = true;
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;

        }
    }
}
