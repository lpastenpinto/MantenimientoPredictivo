namespace Mantenimiento_Predictivo.Interfaz
{
    partial class VisualizarPresionActual
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
            this.DataGridActualPresion = new System.Windows.Forms.DataGridView();
            this.GraficoActualPresion = new ZedGraph.ZedGraphControl();
            this.ComboBoxPresionActual = new System.Windows.Forms.ComboBox();
            this.sensoresMaquinasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensoresPresion = new Mantenimiento_Predictivo.DataSet_.SensoresPresion();
            this.sensores_MaquinasTableAdapter = new Mantenimiento_Predictivo.DataSet_.SensoresPresionTableAdapters.Sensores_MaquinasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridActualPresion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresMaquinasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresPresion)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridActualPresion
            // 
            this.DataGridActualPresion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridActualPresion.Location = new System.Drawing.Point(12, 12);
            this.DataGridActualPresion.Name = "DataGridActualPresion";
            this.DataGridActualPresion.Size = new System.Drawing.Size(555, 523);
            this.DataGridActualPresion.TabIndex = 0;
            // 
            // GraficoActualPresion
            // 
            this.GraficoActualPresion.Location = new System.Drawing.Point(573, 57);
            this.GraficoActualPresion.Name = "GraficoActualPresion";
            this.GraficoActualPresion.ScrollGrace = 0D;
            this.GraficoActualPresion.ScrollMaxX = 0D;
            this.GraficoActualPresion.ScrollMaxY = 0D;
            this.GraficoActualPresion.ScrollMaxY2 = 0D;
            this.GraficoActualPresion.ScrollMinX = 0D;
            this.GraficoActualPresion.ScrollMinY = 0D;
            this.GraficoActualPresion.ScrollMinY2 = 0D;
            this.GraficoActualPresion.Size = new System.Drawing.Size(569, 478);
            this.GraficoActualPresion.TabIndex = 1;
            // 
            // ComboBoxPresionActual
            // 
            this.ComboBoxPresionActual.DataSource = this.sensoresMaquinasBindingSource;
            this.ComboBoxPresionActual.DisplayMember = "Nombre_Sensor";
            this.ComboBoxPresionActual.FormattingEnabled = true;
            this.ComboBoxPresionActual.Location = new System.Drawing.Point(574, 30);
            this.ComboBoxPresionActual.Name = "ComboBoxPresionActual";
            this.ComboBoxPresionActual.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxPresionActual.TabIndex = 2;
            this.ComboBoxPresionActual.ValueMember = "Nombre_Sensor";
            this.ComboBoxPresionActual.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPresionSeleccionado);
            // 
            // sensoresMaquinasBindingSource
            // 
            this.sensoresMaquinasBindingSource.DataMember = "Sensores_Maquinas";
            this.sensoresMaquinasBindingSource.DataSource = this.sensoresPresion;
            // 
            // sensoresPresion
            // 
            this.sensoresPresion.DataSetName = "SensoresPresion";
            this.sensoresPresion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sensores_MaquinasTableAdapter
            // 
            this.sensores_MaquinasTableAdapter.ClearBeforeFill = true;
            // 
            // VisualizarPresionActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 561);
            this.Controls.Add(this.ComboBoxPresionActual);
            this.Controls.Add(this.GraficoActualPresion);
            this.Controls.Add(this.DataGridActualPresion);
            this.Name = "VisualizarPresionActual";
            this.Text = "VisualizarPresionActual";
            this.Load += new System.EventHandler(this.VisualizarPresionActual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridActualPresion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresMaquinasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresPresion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxPresionActual;
        public System.Windows.Forms.DataGridView DataGridActualPresion;
        public ZedGraph.ZedGraphControl GraficoActualPresion;
        private DataSet_.SensoresPresion sensoresPresion;
        private System.Windows.Forms.BindingSource sensoresMaquinasBindingSource;
        private DataSet_.SensoresPresionTableAdapters.Sensores_MaquinasTableAdapter sensores_MaquinasTableAdapter;
    }
}