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
    /// Lógica de interacción para RegistrarPromotorZona.xaml
    /// </summary>
    public partial class RegistrarPromotorZona
    {
        PromotorZonaBL _promZonBL = new PromotorZonaBL();
        PromotorZona _promzEntity = new PromotorZona();
        Proyecto _proyectoB = new Proyecto();
        Promotore _promotorB = new Promotore();
        Zona _zonaB = new Zona();
        Actividade _actividadB = new Actividade();
        ADESCO _adescoB = new ADESCO();

        public RegistrarPromotorZona()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
            else
            {
                Close();
            }
        }

        private void Actualizar()
        {
            txtId.IsEnabled = false;
            txtProyecto.IsEnabled = false;
            txtPromotor.IsEnabled = false;
            txtZona.IsEnabled = false;
            txtActividad.IsEnabled = false;
            txtAdesco.IsEnabled = false;

            txtId.Text = string.Empty;
            txtProyecto.Text = string.Empty;
            txtPromotor.Text = string.Empty;
            txtZona.Text = string.Empty;
            txtActividad.Text = string.Empty;
            txtAdesco.Text = string.Empty;

            btnNuevo.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBusProyecto.IsEnabled = false;
            btnBusPromotor.IsEnabled = false;
            btnBusZona.IsEnabled = false;
            btnBusActividad.IsEnabled = false;
            btnBusAdesco.IsEnabled = false;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }

        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtProyecto.IsEnabled = false;
            txtPromotor.IsEnabled = false;
            txtZona.IsEnabled = false;
            txtActividad.IsEnabled = false;
            txtAdesco.IsEnabled = false;
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBusProyecto.IsEnabled = true;
            btnBusPromotor.IsEnabled = true;
            btnBusZona.IsEnabled = true;
            btnBusActividad.IsEnabled = true;
            btnBusAdesco.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProyecto.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo proyecto");
                }
                if (txtPromotor.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo promotor");
                }
                if (txtZona.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo zona");
                }
                if (txtActividad.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo actividad");
                }
                if (txtAdesco.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo adesco");
                }
                if (!(txtProyecto.Text == string.Empty || txtPromotor.Text == string.Empty || txtZona.Text == string.Empty || txtActividad.Text == string.Empty || txtAdesco.Text == string.Empty))
                {
                    PromotorZona _promzona = new PromotorZona();
                    _promzona.Proyecto = _proyectoB;
                    _promzona.Promotore = _promotorB;
                    _promzona.Zona = _zonaB;
                    _promzona.Actividade = _actividadB;
                    _promzona.ADESCO = _adescoB;


                    if (_promZonBL.AgregaPromotoresZona(_promzona) > 0)
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
                MessageBox.Show("No se pudo agregar el registro" + "Advertencia" + ex.Message);
            }
        }

        private void btnBusProyecto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarProyecto _bus = new BuscarProyecto();
                _bus.ShowDialog();

                _proyectoB = _bus.ProyectoE;
                txtProyecto.Text = _proyectoB.Nombre;
            }
            catch
            {
            }
        }

        private void btnBusPromotor_Click(object sender, RoutedEventArgs e)
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

        private void btnBusZona_Click(object sender, RoutedEventArgs e)
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

        private void btnBusActividad_Click(object sender, RoutedEventArgs e)
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

        private void btnBusAdesco_Click(object sender, RoutedEventArgs e)
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProyecto.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo proyecto");
                }
                if (txtPromotor.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo promotor");
                }
                if (txtZona.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo zona");
                }
                if (txtActividad.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo actividad");
                }
                if (txtAdesco.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo adesco");
                }
                if (!(txtProyecto.Text == string.Empty || txtPromotor.Text == string.Empty || txtZona.Text == string.Empty || txtActividad.Text == string.Empty || txtAdesco.Text == string.Empty))
                {
                    _promzEntity.Id = Convert.ToInt64(txtId.Text);
                    _promzEntity.Proyecto = _proyectoB;
                    _promzEntity.Promotore = _promotorB;
                    _promzEntity.Zona = _zonaB;
                    _promzEntity.Actividade = _actividadB;
                    _promzEntity.ADESCO = _adescoB;

                    if (_promZonBL.ModificarPromotoresZona(_promzEntity) > 0)
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Está seguro que desea eliminar", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
                else
                {
                    _promzEntity.Id = Convert.ToInt64(txtId.Text);
                    _promzEntity.Proyecto = _proyectoB;
                    _promzEntity.Promotore = _promotorB;
                    _promzEntity.Zona = _zonaB;
                    _promzEntity.Actividade = _actividadB;
                    _promzEntity.ADESCO = _adescoB;

                    if (_promZonBL.EliminarPromotoresZona(_promzEntity) > 0)
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
                BuscarPromotorZona _bus = new BuscarPromotorZona();
                _bus.ShowDialog();

                _promzEntity = _bus.PromzE;
                txtId.Text = _promzEntity.Id.ToString();
                txtProyecto.Text = _proyectoB.Nombre;
                txtPromotor.Text = _promotorB.Nombre;
                txtZona.Text = _zonaB.Nombre;
                txtActividad.Text = _actividadB.Nombre;
                txtAdesco.Text = _adescoB.Nombre;

                txtProyecto.IsEnabled = false;
                txtPromotor.IsEnabled = false;
                txtZona.IsEnabled = false;
                txtActividad.IsEnabled = false;
                txtAdesco.IsEnabled = false;
                btnNuevo.IsEnabled = false;
                btnGuardar.IsEnabled = false;
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnBusProyecto.IsEnabled = true;
                btnBusPromotor.IsEnabled = true;
                btnBusZona.IsEnabled = true;
                btnBusActividad.IsEnabled = true;
                btnBusAdesco.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSalir.IsEnabled = true;
            }
            catch
            {
            }
        }
    }
}
