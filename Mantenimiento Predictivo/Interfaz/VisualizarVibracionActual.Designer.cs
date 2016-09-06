namespace Mantenimiento_Predictivo.Interfaz
{
    partial class VisualizarVibracionActual
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
            this.DataGridActualVibracion = new System.Windows.Forms.DataGridView();
            this.GraficoActualVibracion = new ZedGraph.ZedGraphControl();
            this.ComboBoxVibracionActual = new System.Windows.Forms.ComboBox();
            this.sensoresMaquinasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensoresVibracion = new Mantenimiento_Predictivo.DataSet_.SensoresVibracion();
            this.sensores_MaquinasTableAdapter = new Mantenimiento_Predictivo.DataSet_.SensoresVibracionTableAdapters.Sensores_MaquinasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridActualVibracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresMaquinasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresVibracion)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridActualVibracion
            // 
            this.DataGridActualVibracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridActualVibracion.Location = new System.Drawing.Point(12, 12);
            this.DataGridActualVibracion.Name = "DataGridActualVibracion";
            this.DataGridActualVibracion.Size = new System.Drawing.Size(555, 523);
            this.DataGridActualVibracion.TabIndex = 0;
            // 
            // GraficoActualVibracion
            // 
            this.GraficoActualVibracion.Location = new System.Drawing.Point(573, 57);
            this.GraficoActualVibracion.Name = "GraficoActualVibracion";
            this.GraficoActualVibracion.ScrollGrace = 0D;
            this.GraficoActualVibracion.ScrollMaxX = 0D;
            this.GraficoActualVibracion.ScrollMaxY = 0D;
            this.GraficoActualVibracion.ScrollMaxY2 = 0D;
            this.GraficoActualVibracion.ScrollMinX = 0D;
            this.GraficoActualVibracion.ScrollMinY = 0D;
            this.GraficoActualVibracion.ScrollMinY2 = 0D;
            this.GraficoActualVibracion.Size = new System.Drawing.Size(569, 478);
            this.GraficoActualVibracion.TabIndex = 1;
            // 
            // ComboBoxVibracionActual
            // 
            this.ComboBoxVibracionActual.DataSource = this.sensoresMaquinasBindingSource;
            this.ComboBoxVibracionActual.DisplayMember = "Nombre_Sensor";
            this.ComboBoxVibracionActual.FormattingEnabled = true;
            this.ComboBoxVibracionActual.Location = new System.Drawing.Point(574, 30);
            this.ComboBoxVibracionActual.Name = "ComboBoxVibracionActual";
            this.ComboBoxVibracionActual.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxVibracionActual.TabIndex = 2;
            this.ComboBoxVibracionActual.ValueMember = "Nombre_Sensor";
            this.ComboBoxVibracionActual.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVibracionSeleccionado);
            // 
            // sensoresMaquinasBindingSource
            // 
            this.sensoresMaquinasBindingSource.DataMember = "Sensores_Maquinas";
            this.sensoresMaquinasBindingSource.DataSource = this.sensoresVibracion;
            // 
            // sensoresVibracion
            // 
            this.sensoresVibracion.DataSetName = "SensoresVibracion";
            this.sensoresVibracion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sensores_MaquinasTableAdapter
            // 
            this.sensores_MaquinasTableAdapter.ClearBeforeFill = true;
            // 
            // VisualizarVibracionActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 561);
            this.Controls.Add(this.ComboBoxVibracionActual);
            this.Controls.Add(this.GraficoActualVibracion);
            this.Controls.Add(this.DataGridActualVibracion);
            this.Name = "VisualizarVibracionActual";
            this.Text = "VisualizarVibracionActual";
            this.Load += new System.EventHandler(this.VisualizarVibracionActual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridActualVibracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresMaquinasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensoresVibracion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DataGridActualVibracion;
        public ZedGraph.ZedGraphControl GraficoActualVibracion;
        private DataSet_.SensoresVibracion sensoresVibracion;
        private System.Windows.Forms.BindingSource sensoresMaquinasBindingSource;
        private DataSet_.SensoresVibracionTableAdapters.Sensores_MaquinasTableAdapter sensores_MaquinasTableAdapter;
        public System.Windows.Forms.ComboBox ComboBoxVibracionActual;
    }
}