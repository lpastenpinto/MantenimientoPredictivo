using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Mantenimiento_Predictivo.Interfaz
{
    public partial class VisualizarVibracionActual : Form
    {
        Clases.Grafico Puntos = new Clases.Grafico();
        int SensorSeleccionado;
        
        public VisualizarVibracionActual()
        {
            InitializeComponent();
            GraphPane Panel = GraficoActualVibracion.GraphPane;
            
            Panel.Title.Text = "Grafico Datos Cargados";
            Panel.XAxis.Title.Text = "Tiempo";
            Panel.YAxis.Title.Text = "Valor Sensor";
        }

        private void VisualizarVibracionActual_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sensoresVibracion.Sensores_Maquinas' Puede moverla o quitarla según sea necesario.
            this.sensores_MaquinasTableAdapter.Fill(this.sensoresVibracion.Sensores_Maquinas);

        }

        private void ComboBoxVibracionSeleccionado(object sender, EventArgs e)
        {
            SensorSeleccionado = ComboBoxVibracionActual.SelectedIndex;
            GraphPane Panel = GraficoActualVibracion.GraphPane;
            Panel.CurveList.Clear();
            Panel.Title.Text = "Grafico Datos Cargados";
            Panel.XAxis.Title.Text = "Tiempo";
            Panel.YAxis.Title.Text = "Valor Sensor";

            PointPairList val = Puntos.graficar(DataGridActualVibracion, SensorSeleccionado);
            LineItem myCurve1 = Panel.AddCurve("Valores Sensor", val, Color.Blue, SymbolType.None);
            myCurve1.Line.Width = 1;


            
            //graficar alarma
            PointPairList alarm = Puntos.alarma(DataGridActualVibracion.RowCount,SensorSeleccionado);
            LineItem myCurve2 = Panel.AddCurve("Alarma", alarm, Color.Red, SymbolType.Circle);
            myCurve2.Line.Width = 3;

            GraficoActualVibracion.AxisChange();
            GraficoActualVibracion.Invalidate();
            GraficoActualVibracion.Refresh();
        } 
    }
}
