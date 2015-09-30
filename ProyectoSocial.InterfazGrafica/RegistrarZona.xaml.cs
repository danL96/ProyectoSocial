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
    /// Lógica de interacción para RegistrarZona.xaml
    /// </summary>
    public partial class RegistrarZona
    {
        //Instancias bl y acceso a datos
        ZonaBL _zonaBL = new ZonaBL();
        ADESCO _adescoB = new ADESCO();
        Zona _zonaEntity = new Zona();

        public RegistrarZona()
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

        //Mètodo actualizar
        private void Actualizar()
        {
            txtId.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtAdesco.IsEnabled = false;

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtAdesco.Text = string.Empty;

            btnNuevo.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBuscar.IsEnabled = false;
            btnConsultar.IsEnabled = false;
            btnSalir.IsEnabled = true;
        }


        //Evento Load
        private void MetroWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        //Boton Nuevo
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.IsEnabled = true;
            txtAdesco.IsEnabled = false;
            txtNombre.Focus();
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBuscar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnSalir.IsEnabled = false;
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
                if (txtAdesco.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo adesco");
                }

                if (!(txtNombre.Text == string.Empty || txtAdesco.Text == string.Empty))
                {
                    Zona _zona = new Zona();
                    _zona.Nombre = txtNombre.Text;
                    _zona.ADESCO = _adescoB;


                    if (_zonaBL.AgregarZonas(_zona) > 0)
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

        //Boton Buscar Adesco
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarADESCO _bus = new BuscarADESCO();
            _bus.ShowDialog();

            _adescoB = _bus.AdescoE;
            txtAdesco.Text = _adescoB.Nombre;
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
                if (txtAdesco.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo adesco");
                }

                if (!(txtNombre.Text == string.Empty || txtAdesco.Text == string.Empty))
                {
                    _zonaEntity.Id = Convert.ToInt64(txtId.Text);
                    _zonaEntity.Nombre = txtNombre.Text;
                    _zonaEntity.ADESCO = _adescoB;

                    if (_zonaBL.ModificarZonas(_zonaEntity) > 0)
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

        //Boton elimminar datos
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Está seguro que desea eliminar", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { }
                else
                {
                    _zonaEntity.Id = Convert.ToInt64(txtId.Text);
                    _zonaEntity.Nombre = txtNombre.Text;
                    _zonaEntity.ADESCO = _adescoB;

                    if (_zonaBL.EliminarZonas(_zonaEntity) > 0)
                    {
                        MessageBox.Show("El resgitro se eliminó con éxito");
                    }
                    //else
                    //{
                    //    MessageBox.Show("El registro no se pudo eliminar");
                    //}

                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lo sentimos, algo ocurrió mal, puede que se eliminen los datos pero no es recomendable" + "Advertencia" + ex.Message);
            }
        }

        //Boton buscar zona
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarZona _bus = new BuscarZona();
                _bus.ShowDialog();

                _zonaEntity = _bus.ZonaE;
                txtId.Text = _zonaEntity.Id.ToString();
                txtNombre.Text = _zonaEntity.Nombre;
                txtAdesco.Text = _adescoB.Nombre;

                txtNombre.IsEnabled = true;
                txtAdesco.IsEnabled = true;
                btnNuevo.IsEnabled = false;
                btnGuardar.IsEnabled = false;
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnBuscar.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSalir.IsEnabled = true;
            }
            catch
            {
            }
        }
    }
}
