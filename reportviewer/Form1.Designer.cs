namespace reportviewer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dBReporteGastosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBReporteGastosDataSet = new reportviewer.DBReporteGastosDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gastogeneralBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gasto_generalTableAdapter = new reportviewer.DBReporteGastosDataSetTableAdapters.gasto_generalTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dBReporteGastosDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBReporteGastosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastogeneralBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dBReporteGastosDataSetBindingSource
            // 
            this.dBReporteGastosDataSetBindingSource.DataSource = this.dBReporteGastosDataSet;
            this.dBReporteGastosDataSetBindingSource.Position = 0;
            // 
            // dBReporteGastosDataSet
            // 
            this.dBReporteGastosDataSet.DataSetName = "DBReporteGastosDataSet";
            this.dBReporteGastosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.gastogeneralBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "reportviewer.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(921, 671);
            this.reportViewer1.TabIndex = 0;
            // 
            // gastogeneralBindingSource
            // 
            this.gastogeneralBindingSource.DataMember = "gasto_general";
            this.gastogeneralBindingSource.DataSource = this.dBReporteGastosDataSetBindingSource;
            // 
            // gasto_generalTableAdapter
            // 
            this.gasto_generalTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 671);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dBReporteGastosDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBReporteGastosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastogeneralBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dBReporteGastosDataSetBindingSource;
        private DBReporteGastosDataSet dBReporteGastosDataSet;
        private System.Windows.Forms.BindingSource gastogeneralBindingSource;
        private DBReporteGastosDataSetTableAdapters.gasto_generalTableAdapter gasto_generalTableAdapter;
    }
}

