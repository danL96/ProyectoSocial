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
    /// Lógica de interacción para RegistrarPromotor.xaml
    /// </summary>
    public partial class RegistrarPromotor
    {
        PromotorBL _promotorBL = new PromotorBL();
        Zona _zonaB = new Zona();
        Promotore _promotorEntity = new Promotore();

        public RegistrarPromotor()
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
            txtTelefono.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtZona.IsEnabled = false;

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtZona.Text = string.Empty;

            btnNuevo.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBuscar.IsEnabled = false;
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
            txtTelefono.IsEnabled = true;
            txtDireccion.IsEnabled = true;
            txtZona.IsEnabled = false;
            txtNombre.Focus();
            btnNuevo.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnBuscar.IsEnabled = true;
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
                if (txtTelefono.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo teléfono");
                }
                if (txtDireccion.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo dirección");
                }
                if (txtZona.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo zona");
                }
                if (!(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtTelefono.Text == string.Empty || txtDireccion.Text == string.Empty || txtZona.Text == string.Empty))
                {
                    Promotore _promotor = new Promotore();
                    _promotor.Nombre = txtNombre.Text;
                    _promotor.Apellido = txtApellido.Text;
                    _promotor.Telefono = txtTelefono.Text;
                    _promotor.Direccion = txtDireccion.Text;
                    _promotor.Zona = _zonaB;


                    if (_promotorBL.AgregarPromotores(_promotor) > 0)
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
                MessageBox.Show("Lo sentimos, algo ocurrió mal\n" + "Advertencia" + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
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
                if (txtTelefono.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo teléfono");
                }
                if (txtDireccion.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo dirección");
                }
                if (txtZona.Text == string.Empty)
                {
                    MessageBox.Show("Llene el campo zona");
                }
                if (!(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtTelefono.Text == string.Empty || txtDireccion.Text == string.Empty || txtZona.Text == string.Empty))
                {
                    _promotorEntity.Id = Convert.ToInt64(txtId.Text);
                    _promotorEntity.Nombre = txtNombre.Text;
                    _promotorEntity.Apellido = txtApellido.Text;
                    _promotorEntity.Telefono = txtTelefono.Text;
                    _promotorEntity.Direccion = txtDireccion.Text;
                    _promotorEntity.Zona = _zonaB;

                    if (_promotorBL.ModificarPromotores(_promotorEntity) > 0)
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
                    _promotorEntity.Id = Convert.ToInt64(txtId.Text);
                    _promotorEntity.Nombre = txtNombre.Text;
                    _promotorEntity.Apellido = txtApellido.Text;
                    _promotorEntity.Telefono = txtTelefono.Text;
                    _promotorEntity.Direccion = txtDireccion.Text;
                    _promotorEntity.Zona = _zonaB;

                    if (_promotorBL.EliminarPromotores(_promotorEntity) > 0)
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
                BuscarPromotor _bus = new BuscarPromotor();
                _bus.ShowDialog();

                _promotorEntity = _bus.PromotorE;
                txtId.Text = _promotorEntity.Id.ToString();
                txtNombre.Text = _promotorEntity.Nombre;
                txtApellido.Text = _promotorEntity.Apellido;
                txtTelefono.Text = _promotorEntity.Telefono;
                txtDireccion.Text = _promotorEntity.Direccion;
                txtZona.Text = _zonaB.Nombre;

                txtNombre.IsEnabled = true;
                txtApellido.IsEnabled = true;
                txtTelefono.IsEnabled = true;
                txtDireccion.IsEnabled = true;
                txtZona.IsEnabled = false;
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

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            String Cadena = "012.3456789" + (char)8;

                if (!Cadena.Contains(e.Text))
                {
                    MessageBox.Show("Solo se permiten Números", "Advertencia...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtTelefono.Text = "";
                    txtTelefono.Focus();
                    e.Handled = true;
                }
        }

        private void txtTelefono_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Conversion del sender del evento a un objeto TextBox
    TextBox txt = (TextBox)sender;
 
    //Se evalua si se a presionado la tecla de retroceso o la de borrado
    //para dejar pasar la acción de estas
    // || (e.Key == Key.Delete)
            if (e.Key == Key.Back)
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
