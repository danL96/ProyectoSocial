using System;
<<<<<<< HEAD
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

=======
using System.Windows;
>>>>>>> Modificaciones-Pablo
using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{
<<<<<<< HEAD
    /// <summary>
    /// Lógica de interacción para RegistrarAdministrador.xaml
    /// </summary>
    public partial class RegistrarAdministrador
    {
        
        AdministradorBL _administradorBL = new AdministradorBL();
        Administradore _administradorEntity = new Administradore();
=======

    public partial class RegistrarAdministrador
    {
        readonly AdministradorBl _administradorBl = new AdministradorBl();
        private readonly ProyectoSocialEncrypter _encrypter = new ProyectoSocialEncrypter();
>>>>>>> Modificaciones-Pablo

        public RegistrarAdministrador()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            string salir = Convert.ToString(MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question));
            if (salir == "Yes")
            {
                this.Close();
            }
=======
            var result = MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes) Close();
>>>>>>> Modificaciones-Pablo
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
<<<<<<< HEAD
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
                    MessageBox.Show("No coinciden los campos contraseña y confirmar contraseña", "Vuelva a intentar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

                        if (_administradorBL.AgregarAdministradores(_administrador) > 0)
                        {
                            MessageBox.Show("El registro se agregó correctamente");
                        }
                        //else
                        //{
                        //    MessageBox.Show("El registro no se pudo guardar");
                        //}

                        Actualizar();
                    }
                }
=======
                if (!Validate()) return;

                var administrador = new Administradore
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Nick = txtNick.Text,
                    Pass = _encrypter.EncryptString(txtPass.Password),
                    Confirmar = _encrypter.EncryptString(txtPass.Password)
                };

                if (_administradorBl.Agregar(administrador) > 0)
                {
                    MessageBox.Show("El registro se agregó correctamente");
                }

                Actualizar();

>>>>>>> Modificaciones-Pablo
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
<<<<<<< HEAD
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
                //if (txtConfirmarpass.Password == string.Empty)
                //{
                //    MessageBox.Show("Llene el campo confirmar contraseña");
                //}
                //if (!(txtPass.Password == txtConfirmarpass.Password))
                //{
                //    MessageBox.Show("No coinciden los campos contraseña y confirmar contraseña", "Vuelva a intentar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //}
                else
                {
                    if (!(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtNick.Text == string.Empty || txtPass.Password == string.Empty))
                    {
                        Administradore _administrador = new Administradore();
                        _administradorEntity.Id = Convert.ToInt64(txtId.Text);
                        _administradorEntity.Nombre = txtNombre.Text;
                        _administradorEntity.Apellido = txtApellido.Text;
                        _administradorEntity.Nick = txtNick.Text;
                        _administradorEntity.Pass = Utilidades.EncriptarClave(txtPass.Password);

                        //_administrador.Confirmar = Utilidades.EncriptarClave(txtConfirmarpass.Password);

                        if (_administradorBL.ModificarAdministradores(_administradorEntity) > 0)
                        {
                            MessageBox.Show("El registro se modificó correctamente");
                        }
                        //else
                        //{
                        //    MessageBox.Show("El registro no se pudo modificar");
                        //}

                        Actualizar();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No seleccione los últimos datos de la lista(están vacios) o pueda que se guarden pero no es recomendable\n" + "Advertencia" + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
            {
                try
                {

                    if (MessageBox.Show("Está seguro que desea eliminar", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
                    else
                    {
                        _administradorEntity.Id = Convert.ToInt64(txtId.Text);
                        _administradorEntity.Nombre = txtNombre.Text;
                        _administradorEntity.Apellido = txtApellido.Text;
                        _administradorEntity.Nick = txtNick.Text;
                        _administradorEntity.Pass = Utilidades.EncriptarClave(txtPass.Password);
                        _administradorEntity.Confirmar = Utilidades.EncriptarClave(txtConfirmarpass.Password);
                        if (_administradorBL.EliminarAdministradores(_administradorEntity) > 0)
                        {

                            MessageBox.Show("El registro se eliminó con éxito");
                            Actualizar();


                        }
                        //else { }
                        //{
                        //    MessageBox.Show("El registro no se pudo eliminar");
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lo sentimos, algo ocurrió mal, puede que se eliminen los datos pero no es recomendable" + "Advertencia" + ex.Message);
                }
            }
        

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            txtConfirmarpass.Visibility = Visibility.Hidden;
            lbConfirmar.Visibility = Visibility.Hidden;
            try
            {
                BuscarAdministrador _bus = new BuscarAdministrador();
                _bus.ShowDialog();

                _administradorEntity = _bus.AdministradorE;
                txtId.Text = _administradorEntity.Id.ToString();
                txtNombre.Text = _administradorEntity.Nombre;
                txtApellido.Text = _administradorEntity.Apellido;
                txtNick.Text = _administradorEntity.Nick;
                txtPass.Password = _administradorEntity.Pass;
                //txtPass.Clear();
                txtConfirmarpass.Password = _administradorEntity.Confirmar;
                //txtConfirmarpass.Clear();

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
            catch
            {
            }
        }
=======
                if (!Validate()) return;

                var administrador = new Administradore
                {
                    Id = Convert.ToInt64(txtId.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Nick = txtNick.Text,
                    Pass = _encrypter.EncryptString(txtPass.Password),
                    Confirmar = _encrypter.EncryptString(txtPass.Password)
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
                    Pass = _encrypter.EncryptString(txtPass.Password),
                    Confirmar = _encrypter.EncryptString(txtPass.Password)
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

            txtId.Text = bus.Administrador.Id.ToString();
            txtNombre.Text = bus.Administrador.Nombre;
            txtApellido.Text = bus.Administrador.Apellido;
            txtNick.Text = bus.Administrador.Nick;
            txtPass.Password = bus.Administrador.Pass;
            txtConfirmarpass.Password = bus.Administrador.Pass;

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
>>>>>>> Modificaciones-Pablo
    }
}
