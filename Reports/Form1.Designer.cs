//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
namespace Reports
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">True si los recursos administrados se deben eliminar; en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por Windows Form Designer

        /// <summary>
        /// Se requiere el método para la compatibilidad con Designer: no modifique
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BDProyeccionSocialDataSet = new Reports.BDProyeccionSocialDataSet();
            this.ZonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ZonasTableAdapter = new Reports.BDProyeccionSocialDataSetTableAdapters.ZonasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BDProyeccionSocialDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZonasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = this.ZonasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // BDProyeccionSocialDataSet
            // 
            this.BDProyeccionSocialDataSet.DataSetName = "BDProyeccionSocialDataSet";
            this.BDProyeccionSocialDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ZonasBindingSource
            // 
            this.ZonasBindingSource.DataMember = "Zonas";
            this.ZonasBindingSource.DataSource = this.BDProyeccionSocialDataSet;
            // 
            // ZonasTableAdapter
            // 
            this.ZonasTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BDProyeccionSocialDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZonasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ZonasBindingSource;
        private BDProyeccionSocialDataSet BDProyeccionSocialDataSet;
        private BDProyeccionSocialDataSetTableAdapters.ZonasTableAdapter ZonasTableAdapter;
    }
}

