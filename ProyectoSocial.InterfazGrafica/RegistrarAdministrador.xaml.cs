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
    /// Lógica de interacción para RegistrarAdministrador.xaml
    /// </summary>
    public partial class RegistrarAdministrador
    {
        
        AdministradorBL _administradorBL = new AdministradorBL();
        Administradore _administradorEntity = new Administradore();

        public RegistrarAdministrador()
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
    }
}
