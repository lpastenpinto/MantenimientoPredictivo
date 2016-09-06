namespace Mantenimiento_Predictivo.Interfaz
{
    partial class VisualizarTemperaturaActual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DataGridActualTemperatura = new System.Windows.Forms.DataGridView();
            this.GraficoActualTemperatura = new ZedGraph.ZedGraphControl();
            this.ComboBoxTemperaturaActual = new System.Windows.Forms.ComboBox();
            this.sensoresTemperatura = new Mantenimiento_Predictivo.DataSet_.SensoresTemperatura();
            this.sensoresMaquinasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensores_MaquinasTableAdapter = new Mantenimiento_Predictivo.DataSet_.SensoresTemperaturaTableAdapters.Sensores_MaquinasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridActualTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresMaquinasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridActualTemperatura
            // 
            this.DataGridActualTemperatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridActualTemperatura.Location = new System.Drawing.Point(12, 12);
            this.DataGridActualTemperatura.Name = "DataGridActualTemperatura";
            this.DataGridActualTemperatura.Size = new System.Drawing.Size(555, 523);
            this.DataGridActualTemperatura.TabIndex = 0;
            // 
            // GraficoActualTemperatura
            // 
            this.GraficoActualTemperatura.Location = new System.Drawing.Point(573, 57);
            this.GraficoActualTemperatura.Name = "GraficoActualTemperatura";
            this.GraficoActualTemperatura.ScrollGrace = 0D;
            this.GraficoActualTemperatura.ScrollMaxX = 0D;
            this.GraficoActualTemperatura.ScrollMaxY = 0D;
            this.GraficoActualTemperatura.ScrollMaxY2 = 0D;
            this.GraficoActualTemperatura.ScrollMinX = 0D;
            this.GraficoActualTemperatura.ScrollMinY = 0D;
            this.GraficoActualTemperatura.ScrollMinY2 = 0D;
            this.GraficoActualTemperatura.Size = new System.Drawing.Size(569, 478);
            this.GraficoActualTemperatura.TabIndex = 1;
            // 
            // ComboBoxTemperaturaActual
            // 
            this.ComboBoxTemperaturaActual.DataSource = this.sensoresMaquinasBindingSource;
            this.ComboBoxTemperaturaActual.DisplayMember = "Nombre_Sensor";
            this.ComboBoxTemperaturaActual.FormattingEnabled = true;
            this.ComboBoxTemperaturaActual.Location = new System.Drawing.Point(574, 30);
            this.ComboBoxTemperaturaActual.Name = "ComboBoxTemperaturaActual";
            this.ComboBoxTemperaturaActual.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxTemperaturaActual.TabIndex = 2;
            this.ComboBoxTemperaturaActual.ValueMember = "Nombre_Sensor";
            this.ComboBoxTemperaturaActual.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTemperaturaSeleccionado);
            // 
            // sensoresTemperatura
            // 
            this.sensoresTemperatura.DataSetName = "SensoresTemperatura";
            this.sensoresTemperatura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sensoresMaquinasBindingSource
            // 
            this.sensoresMaquinasBindingSource.DataMember = "Sensores_Maquinas";
            this.sensoresMaquinasBindingSource.DataSource = this.sensoresTemperatura;
            // 
            // sensores_MaquinasTableAdapter
            // 
            this.sensores_MaquinasTableAdapter.ClearBeforeFill = true;
            // 
            // VisualizarTemperaturaActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 561);
            this.Controls.Add(this.ComboBoxTemperaturaActual);
            this.Controls.Add(this.GraficoActualTemperatura);
            this.Controls.Add(this.DataGridActualTemperatura);
            this.Name = "VisualizarTemperaturaActual";
            this.Text = "VisualizarTemperaturaActual";
            this.Load += new System.EventHandler(this.VisualizarTemperaturaActual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridActualTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresMaquinasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxTemperaturaActual;
        public System.Windows.Forms.DataGridView DataGridActualTemperatura;
        public ZedGraph.ZedGraphControl GraficoActualTemperatura;
        private DataSet_.SensoresTemperatura sensoresTemperatura;
        private System.Windows.Forms.BindingSource sensoresMaquinasBindingSource;
        private DataSet_.SensoresTemperaturaTableAdapters.Sensores_MaquinasTableAdapter sensores_MaquinasTableAdapter;
    }
}