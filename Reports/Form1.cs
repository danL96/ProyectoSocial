//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'BDProyeccionSocialDataSet.Zonas' Puede moverla o quitarla según sea necesario.
            this.ZonasTableAdapter.Fill(this.BDProyeccionSocialDataSet.Zonas);
            this.reportViewer1.RefreshReport();
        }
    }
}