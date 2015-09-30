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
    /// Lógica de interacción para RegistrarADESCO.xaml
    /// </summary>
    public partial class RegistrarADESCO
    {
        //Instancias BL y acceso a datos
        ADESCOBL _adescoBL = new ADESCOBL();
        AccesoADatos.ADESCO _adescoEntity = new AccesoADatos.ADESCO();

        public RegistrarADESCO()
        {
            InitializeComponent();
        }

        //Boton salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            string salir = Convert.ToString(MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question));
            if (salir == "Yes")
            {
                this.Close();
            }
        }


        //Mètodo actualizar
        private void Actualizar()
        {
            txtId.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtTipo.IsEnabled = false;

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTipo.Text = string.Empty;

            btnNuevo.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }


        //Evento load
        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        //Boton Nuevo
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.IsEnabled = true;
            txtTipo.IsEnabled = true;
            txtNombre.Focus();
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }


        //Boton Guardar datos
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNombre.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo nombre");
                }
                if (txtTipo.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo tipo");
                }
                if (!(txtNombre.Text == string.Empty || txtTipo.Text == string.Empty))
                {
                    AccesoADatos.ADESCO _adesco = new AccesoADatos.ADESCO();
                    _adesco.Nombre = txtNombre.Text;
                    _adesco.TipoADESCO = txtTipo.Text;

                    if (_adescoBL.AgregarADESCOS(_adesco) > 0)
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


        //Boton Modificar datos
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNombre.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo nombre");
                }
                if (txtTipo.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo tipo");
                }
                if (!(txtNombre.Text == string.Empty || txtTipo.Text == string.Empty))
                {
                    AccesoADatos.ADESCO _adesco = new AccesoADatos.ADESCO();
                    _adescoEntity.Id = Convert.ToInt64(txtId.Text);
                    _adescoEntity.Nombre = txtNombre.Text;
                    _adescoEntity.TipoADESCO = txtTipo.Text;

                    if (_adescoBL.ModificarADESCOS(_adescoEntity) > 0)
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

        //Boton Eliminar Datos
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Está seguro que desea eliminar", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
                else
                {
                    _adescoEntity.Id = Convert.ToInt64(txtId.Text);
                    _adescoEntity.Nombre = txtNombre.Text;
                    _adescoEntity.TipoADESCO = txtTipo.Text;

                    if (_adescoBL.EliminarADESCOS(_adescoEntity) > 0)
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
        

        //Boton consultar
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarADESCO _bus = new BuscarADESCO();
                _bus.ShowDialog();

                _adescoEntity = _bus.AdescoE;
                txtId.Text = _adescoEntity.Id.ToString();
                txtNombre.Text = _adescoEntity.Nombre;
                txtTipo.Text = _adescoEntity.TipoADESCO;

                txtNombre.IsEnabled = true;
                txtTipo.IsEnabled = true;
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
