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
    /// Lógica de interacción para RegistrarActividad.xaml
    /// </summary>
    public partial class RegistrarActividad
    {
        //Instancias BL y acceso a datos
        ActividadBL _actividadBL = new ActividadBL();
        Actividade _actividadEntity = new Actividade();

        public RegistrarActividad()
        {
            InitializeComponent();
        }

        //Boton Salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            string salir = Convert.ToString(MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question));
            if(salir == "Yes")
            {
                this.Close();
            }
        }

        //Metodo actualizar
        private void Actualizar()
        {
            txtId.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtTipo.IsEnabled = false;
            dpFecha.IsEnabled = false;

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTipo.Text = string.Empty;
            dpFecha.Text = string.Empty;

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

        //Boton nuevo
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.IsEnabled = true;
            txtTipo.IsEnabled = true;
            dpFecha.IsEnabled = true;
            txtNombre.Focus();
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }

        //Boton guardar
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
                if (dpFecha.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campofecha");
                }
                if (!(txtNombre.Text == string.Empty || txtTipo.Text == string.Empty || dpFecha.Text == string.Empty))
                {
                    Actividade _actividad = new Actividade();
                    _actividad.Nombre = txtNombre.Text;
                    _actividad.Tipo = txtTipo.Text;
                    _actividad.Fecha = dpFecha.Text;


                    if (_actividadBL.AgregarActividades(_actividad) > 0)
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
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar el registro" + "Advertencia" + ex.Message);
                }
                }


        //Boton Modificar
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
                if (dpFecha.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campofecha");
                }
                if (!(txtNombre.Text == string.Empty || txtTipo.Text == string.Empty || dpFecha.Text == string.Empty))
                {
                    Actividade _actividad = new Actividade();
                    _actividadEntity.Id = Convert.ToInt64(txtId.Text);
                    _actividadEntity.Nombre = txtNombre.Text;
                    _actividadEntity.Tipo = txtTipo.Text;
                    _actividadEntity.Fecha = dpFecha.Text;

                    if (_actividadBL.ModificarActividades(_actividadEntity) > 0)
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

        //Boton Eliminar
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Está seguro que desea elimina", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
                else
                {
                _actividadEntity.Id = Convert.ToInt64(txtId.Text);
                _actividadEntity.Nombre = txtNombre.Text;
                _actividadEntity.Tipo = txtTipo.Text;
                _actividadEntity.Fecha = dpFecha.Text;

                if (_actividadBL.EliminarActividades(_actividadEntity) > 0)
                {
                    MessageBox.Show("El registro se eliminó con éxito");
                    Actualizar();
                }
                //else
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

        //Boton consultar
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarActividad _bus = new BuscarActividad();
                _bus.ShowDialog();

                _actividadEntity = _bus.ActividadE;
                txtId.Text = _actividadEntity.Id.ToString();
                txtNombre.Text = _actividadEntity.Nombre;
                txtTipo.Text = _actividadEntity.Tipo;
                dpFecha.Text = _actividadEntity.Fecha;

                txtNombre.IsEnabled = true;
                txtTipo.IsEnabled = true;
                dpFecha.IsEnabled = true;
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

        private void dpFecha_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = new TextBox();

            if (e.Key == Key.Back || e.Key == Key.Delete)
                return;

            //Evaluamos el valor de la tecla presionada de acuerdo al
            //enumerador Key, donde los números están en el rango de
            // 34 a 43 en el teclado y de 74 a 83 en el teclado numérico
            if ((int)e.Key < 74)
            {
                if (((int)e.Key < 34 || (int)e.Key > 43))
                    e.Handled = true;
            }
            else if ((int)e.Key > 83
                //Evaluamos si se ha presionado la tecla de punto
                //para interpretarlo como punto decimal
                && !((e.Key == Key.OemPeriod || e.Key == Key.Decimal)
                //Evaluamos que el TextBox no contenga ya un
                //punto decimal en la propiedad Text.
                && !txt.Text.Contains(".")))
                e.Handled = true;     
        }
    }
}
