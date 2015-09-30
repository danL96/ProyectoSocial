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

using Microsoft.Reporting.WinForms;
using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para FrmReportePromotor.xaml
    /// </summary>
    public partial class FrmReportePromotor
    {
        //Instancia promotor BL
        PromotorBL _rep = new PromotorBL();


        public FrmReportePromotor()
        {
            InitializeComponent();
        }

        PromotorBL _prombl = new PromotorBL();

        private void WindowsFormsHost_Loaded(object sender, RoutedEventArgs e)
        {
               
        }

        //Boton para generar todos los reportes
        private void btnreporte_Click(object sender, RoutedEventArgs e)
        {


            if (txtreporte.Text == string.Empty)
            {
                viewerInstance.LocalReport.DataSources.Clear();
                viewerInstance.LocalReport.DataSources.Add(new ReportDataSource("DSReportePromotor", _rep.ObtenerPromotoresPorNombres()));
                viewerInstance.LocalReport.ReportPath = "..\\..\\ReportePromotor.rdlc";
                viewerInstance.RefreshReport();

            }

            else
            {
                //Filtrado por fecha de actividaddes
                ReportePromotor _reppro = new ReportePromotor();
                _reppro.Fecha_Actividad = txtreporte.Text;
                viewerInstance.LocalReport.DataSources.Clear();
                viewerInstance.LocalReport.DataSources.Add(new ReportDataSource("DSReportePromotor", _rep.ObtenerPromotoresPorFechasDeActividades(_reppro)));
                viewerInstance.LocalReport.ReportPath = "..\\..\\ReportePromotor.rdlc";
                viewerInstance.RefreshReport();

            }
               
        }

    }
}


 