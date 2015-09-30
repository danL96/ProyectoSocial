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
    /// Lógica de interacción para RegistrarProyecto.xaml
    /// </summary>
    public partial class RegistrarProyecto
    {
        //Instancias BL y acceso a datos
        ProyectoBL _proyectoBL = new ProyectoBL();
        Proyecto _proyectoEntity = new Proyecto();
        Promotore _promotorB = new Promotore();
        Actividade _actividadB = new Actividade();
        ADESCO _adescoB = new ADESCO();
        Zona _zonaB = new Zona();
        

        public RegistrarProyecto()
        {
            InitializeComponent();
        }

        //Boton salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
            else
            {
                Close();
            }
        }


        //Mètodo de actualizaciòn
        private void Actualizar()
        {
            txtId.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtTipo.IsEnabled = false;
            txtPromotor.IsEnabled = false;
            txtActividad.IsEnabled =false;
            txtAdesco.IsEnabled = false;
            txtZona.IsEnabled = false;

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtPromotor.Text = string.Empty;
            txtActividad.Text = string.Empty;
            txtAdesco.Text = string.Empty;
            txtZona.Text = string.Empty;

            btnNuevo.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBuscarPromotor.IsEnabled = false;
            btnBuscarActividad.IsEnabled = false;
            btnBuscarAdesco.IsEnabled = false;
            btnBuscarZona.IsEnabled = false;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }

        //Boton nuevo
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            

            txtNombre.IsEnabled = true;
            txtTipo.IsEnabled = true;
            txtPromotor.IsEnabled = false;
            txtActividad.IsEnabled = false;
            txtAdesco.IsEnabled = false;
            txtZona.IsEnabled = false;
            txtNombre.Focus();
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBuscarPromotor.IsEnabled = true;
            btnBuscarActividad.IsEnabled = true;
            btnBuscarAdesco.IsEnabled = true;
            btnBuscarZona.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }

        //Evento load
        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
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
                if (txtPromotor.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo promotor");
                }
                if (txtActividad.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo actividad");
                }
                if (txtAdesco.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo adesco");
                }
                if (txtZona.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo zona");
                }


                if (!(txtNombre.Text == string.Empty || txtTipo.Text == string.Empty || txtPromotor.Text == string.Empty || txtZona.Text == string.Empty || txtActividad.Text == string.Empty || txtAdesco.Text == string.Empty))
                {
                    Proyecto _proyecto = new Proyecto();
                    _proyecto.Nombre = txtNombre.Text;
                    _proyecto.TipoProyecto = txtTipo.Text;
                    _proyecto.Promotore = _promotorB;
                    _proyecto.Actividade = _actividadB;
                    _proyecto.ADESCO = _adescoB;
                    _proyecto.Zona = _zonaB;


                    if (_proyectoBL.AgregarProyectos(_proyecto) > 0)
                    {
                        MessageBox.Show("El registro se agregó con éxito");
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser agregado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el registro\n" + "Advertencia" + ex.Message);
            }
        }


        //Boton de busqueda de promotor
        private void btnBuscarPromotor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarPromotor _bus = new BuscarPromotor();
                _bus.ShowDialog();

                _promotorB = _bus.PromotorE;
                txtPromotor.Text = _promotorB.Nombre;
            }
            catch
            {
            }

        }


        //Boton busqueda actividad
        private void btnBuscarActividad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarActividad _bus = new BuscarActividad();
                _bus.ShowDialog();

                _actividadB = _bus.ActividadE;
                txtActividad.Text = _actividadB.Nombre;
            }
            catch
            {
            }

        }


        //Boton busqueda adesco
        private void btnBuscarAdesco_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarADESCO _bus = new BuscarADESCO();
                _bus.ShowDialog();

                _adescoB = _bus.AdescoE;
                txtAdesco.Text = _adescoB.Nombre;
            }
            catch
            {
            }
        }


        //Boton busqueda zona
        private void btnBuscarZona_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarZona _bus = new BuscarZona();
                _bus.ShowDialog();

                _zonaB = _bus.ZonaE;
                txtZona.Text = _zonaB.Nombre;
            }
            catch
            {
            }
        }


        //Boton modificar
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
                if (txtPromotor.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo promotor");
                }
                if (txtActividad.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo actividad");
                }
                if (txtAdesco.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo adesco");
                }
                if (txtZona.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo zona");
                }


                if (!(txtNombre.Text == string.Empty || txtTipo.Text == string.Empty || txtPromotor.Text == string.Empty || txtZona.Text == string.Empty || txtActividad.Text == string.Empty || txtAdesco.Text == string.Empty))
                {
                    _proyectoEntity.Id = Convert.ToInt64(txtId.Text);
                    _proyectoEntity.Nombre = txtNombre.Text;
                    _proyectoEntity.TipoProyecto = txtTipo.Text;
                    _proyectoEntity.Promotore = _promotorB;
                    _proyectoEntity.Actividade = _actividadB;
                    _proyectoEntity.ADESCO = _adescoB;
                    _proyectoEntity.Zona = _zonaB;

                    if (_proyectoBL.ModificarProyectos(_proyectoEntity) > 0)
                    {
                        MessageBox.Show("El resgitro se modificó con éxito");
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


        //Boton ELiminar
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Está seguro que desea eliminar", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
                else
                {
                    _proyectoEntity.Id = Convert.ToInt64(txtId.Text);
                _proyectoEntity.Nombre = txtNombre.Text;
                _proyectoEntity.TipoProyecto = txtTipo.Text;
                _proyectoEntity.Promotore = _promotorB;
                _proyectoEntity.Actividade = _actividadB;
                _proyectoEntity.ADESCO = _adescoB;
                _proyectoEntity.Zona = _zonaB;

                if (_proyectoBL.EliminarProyectos(_proyectoEntity) > 0)
                {
                    MessageBox.Show("El resgitro se eliminó con éxito");
                }
                else
                {
                    MessageBox.Show("El registro no se pudo eliminar");
                }

                Actualizar();
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
                Actualizar();

                BuscarProyecto _bus = new BuscarProyecto();
                _bus.ShowDialog();

                _proyectoEntity = _bus.ProyectoE;
                txtId.Text = _proyectoEntity.Id.ToString();
                txtNombre.Text = _proyectoEntity.Nombre;
                txtTipo.Text = _proyectoEntity.TipoProyecto;
                txtPromotor.Text = _promotorB.Nombre;
                txtActividad.Text = _actividadB.Nombre;
                txtAdesco.Text = _adescoB.Nombre;
                txtZona.Text = _zonaB.Nombre;

                txtNombre.IsEnabled = true;
                txtTipo.IsEnabled = true;
                txtPromotor.IsEnabled = false;
                txtActividad.IsEnabled = false;
                txtAdesco.IsEnabled = false;
                txtZona.IsEnabled = false;
                btnNuevo.IsEnabled = false;
                btnGuardar.IsEnabled = false;
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnBuscarPromotor.IsEnabled = true;
                btnBuscarActividad.IsEnabled = true;
                btnBuscarAdesco.IsEnabled = true;
                btnBuscarZona.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSalir.IsEnabled = true;
            }
            catch
            {
            }
        }
    }
}
