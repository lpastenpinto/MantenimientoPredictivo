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
    public partial class VisualizarTemperaturaActual : Form
    {
       Clases.Grafico Puntos = new Clases.Grafico();
        int SensorSeleccionado;
        
        public VisualizarTemperaturaActual()
        {
            InitializeComponent();
            GraphPane Panel = GraficoActualTemperatura.GraphPane;
            
            Panel.Title.Text = "Grafico Datos Cargados";
            Panel.XAxis.Title.Text = "Tiempo";
            Panel.YAxis.Title.Text = "Valor Sensor";
        }

        

        private void ComboBoxTemperaturaSeleccionado(object sender, EventArgs e)
        {
            SensorSeleccionado = ComboBoxTemperaturaActual.SelectedIndex;
            GraphPane Panel = GraficoActualTemperatura.GraphPane;
            Panel.CurveList.Clear();
            Panel.Title.Text = "Grafico Datos Cargados";
            Panel.XAxis.Title.Text = "Tiempo";
            Panel.YAxis.Title.Text = "Valor Sensor";

            PointPairList val = Puntos.graficar(DataGridActualTemperatura, SensorSeleccionado);
            LineItem myCurve1 = Panel.AddCurve("Valores Sensor", val, Color.Blue, SymbolType.None);
            myCurve1.Line.Width = 1;

            GraficoActualTemperatura.AxisChange();
            GraficoActualTemperatura.Invalidate();
            GraficoActualTemperatura.Refresh();
            
            //graficar alarma
            /*PointPairList alarm = Puntos.alarma(DataGridVibracion);
            LineItem myCurve2 = Panel.AddCurve("Alarma", alarm, Color.Red, SymbolType.Circle);
            myCurve2.Line.Width = 3;
             */

        }

        private void VisualizarTemperaturaActual_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sensoresTemperatura.Sensores_Maquinas' Puede moverla o quitarla según sea necesario.
            this.sensores_MaquinasTableAdapter.Fill(this.sensoresTemperatura.Sensores_Maquinas);

        } 
    }
}
