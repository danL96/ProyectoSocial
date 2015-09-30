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
    /// Lógica de interacción para RegistrarMiembroADESCO.xaml
    /// </summary>
    public partial class RegistrarMiembroADESCO
    {
        MiembrosADESCOSBL _miembrosADESCOSBL = new MiembrosADESCOSBL();
        MiembrosADESCO _miembrosEntity = new MiembrosADESCO();

        public RegistrarMiembroADESCO()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
            else
            {
                this.Close();
            }
        }

        private void Actualizar()
        {
            txtId.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtCargo.IsEnabled = false;

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCargo.Text = string.Empty;

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
            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtCargo.IsEnabled = true;
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
                if (txtCargo.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo cargo");
                }
                if (!(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtCargo.Text == string.Empty))
                {
                    MiembrosADESCO _miembro = new MiembrosADESCO();
                    _miembro.Nombre = txtNombre.Text;
                    _miembro.Apellido = txtApellido.Text;
                    _miembro.Cargo = txtCargo.Text;

                    if (_miembrosADESCOSBL.AgregarMiembrosADESCOS(_miembro) > 0)
                    {
                        MessageBox.Show("El registro se agregó correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El registro no se pudo guardar");
                    }

                    Actualizar();
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
                if (txtCargo.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo cargo");
                }
                if (!(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtCargo.Text == string.Empty))
                {
                    MiembrosADESCO _miembro = new MiembrosADESCO();
                    _miembrosEntity.Id = Convert.ToInt64(txtId.Text);
                    _miembrosEntity.Nombre = txtNombre.Text;
                    _miembrosEntity.Apellido = txtApellido.Text;
                    _miembrosEntity.Cargo = txtCargo.Text;

                    if (_miembrosADESCOSBL.ModificarMiembrosADESCOS(_miembrosEntity) > 0)
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
                    _miembrosEntity.Id = Convert.ToInt64(txtId.Text);
                    _miembrosEntity.Nombre = txtNombre.Text;
                    _miembrosEntity.Apellido = txtApellido.Text;
                    _miembrosEntity.Cargo = txtCargo.Text;

                    if (_miembrosADESCOSBL.EliminarMiembrosADESCOS(_miembrosEntity) > 0)
                    {
                        MessageBox.Show("El registro se eliminó con éxito");
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El registro no se pudo eliminar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos, algo ocurrió mal, puede que se eliminen los datos pero no es recomendable" + "Advertencia" + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarMiembros _bus = new BuscarMiembros();
                _bus.ShowDialog();

                _miembrosEntity = _bus.MiembrosE;
                txtId.Text = _miembrosEntity.Id.ToString();
                txtNombre.Text = _miembrosEntity.Nombre;
                txtApellido.Text = _miembrosEntity.Apellido;
                txtCargo.Text = _miembrosEntity.Cargo;

                txtNombre.IsEnabled = true;
                txtApellido.IsEnabled = true;
                txtCargo.IsEnabled = true;
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
