using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Mantenimiento_Predictivo.Clases
{
    class VisualizarDatos
    {

        public static void MostrarPresion(DataTable DT_Presion)
        {
            Interfaz.VisualizarPresionActual PresionActual = new Interfaz.VisualizarPresionActual();
            int NumeroColumna = DT_Presion.Columns.Count;
            for (int j = 3; j < NumeroColumna; j++)
            {
                DT_Presion.Columns.Remove(DT_Presion.Columns[j]);
                NumeroColumna = DT_Presion.Columns.Count;
            }

            PresionActual.DataGridActualPresion.DataSource = DT_Presion;
            PresionActual.DataGridActualPresion.Columns[0].HeaderText = "Fecha";
            PresionActual.DataGridActualPresion.Columns[1].HeaderText = "Tiempo";
            PresionActual.DataGridActualPresion.Columns[2].HeaderText = "Milisegundos";
            PresionActual.DataGridActualPresion.Columns[3].HeaderText = "F7080_LI";
            PresionActual.DataGridActualPresion.Columns[4].HeaderText = "F7080_TI";
            PresionActual.DataGridActualPresion.Columns[5].HeaderText = "F7086_PI";
            PresionActual.DataGridActualPresion.Columns[6].HeaderText = "F7086_TI";

            PresionActual.ShowDialog();
        }

      

        public static void MostrarVibracion(DataTable DT_Vibracion)
        {
            Interfaz.VisualizarVibracionActual VibracionActual = new Interfaz.VisualizarVibracionActual();
            int NumeroColumna = DT_Vibracion.Columns.Count;
            for (int j = 3; j < NumeroColumna; j++)
            {
                DT_Vibracion.Columns.Remove(DT_Vibracion.Columns[j]);
                NumeroColumna = DT_Vibracion.Columns.Count;
            }

            VibracionActual.DataGridActualVibracion.DataSource = DT_Vibracion;
            VibracionActual.DataGridActualVibracion.Columns[0].HeaderText = "Fecha";
            VibracionActual.DataGridActualVibracion.Columns[1].HeaderText = "Tiempo";
            VibracionActual.DataGridActualVibracion.Columns[2].HeaderText = "Milisegundos";
            VibracionActual.DataGridActualVibracion.Columns[3].HeaderText = "F7001";
            VibracionActual.DataGridActualVibracion.Columns[4].HeaderText = "F7009";
            VibracionActual.DataGridActualVibracion.Columns[5].HeaderText = "F7011_X";
            VibracionActual.DataGridActualVibracion.Columns[6].HeaderText = "F7011_Y";
            VibracionActual.DataGridActualVibracion.Columns[7].HeaderText = "F7021_X";
            VibracionActual.DataGridActualVibracion.Columns[8].HeaderText = "F7021_Y";
            VibracionActual.DataGridActualVibracion.Columns[9].HeaderText = "F7031_X";
            VibracionActual.DataGridActualVibracion.Columns[10].HeaderText = "F7031_Y";
            VibracionActual.DataGridActualVibracion.Columns[11].HeaderText = "F7041_X";
            VibracionActual.DataGridActualVibracion.Columns[12].HeaderText = "F7041_Y";
            VibracionActual.DataGridActualVibracion.Columns[13].HeaderText = "F7092_X";
            VibracionActual.DataGridActualVibracion.Columns[14].HeaderText = "F7092_Y";
            VibracionActual.DataGridActualVibracion.Columns[15].HeaderText = "F7093_X";
            VibracionActual.DataGridActualVibracion.Columns[16].HeaderText = "F7093_Y";
            VibracionActual.DataGridActualVibracion.Columns[17].HeaderText = "F7096";
            VibracionActual.DataGridActualVibracion.Columns[18].HeaderText = "F7099";
            VibracionActual.DataGridActualVibracion.Columns[19].HeaderText = "F7080";
            
            VibracionActual.ShowDialog();
        }

        public static void MostrarTemperatura(DataTable DT_Temperatura)
        {
            Interfaz.VisualizarTemperaturaActual TemperaturaActual = new Interfaz.VisualizarTemperaturaActual();
            int NumeroColumna = DT_Temperatura.Columns.Count;
            for (int j = 3; j < NumeroColumna; j++)
            {
                DT_Temperatura.Columns.Remove(DT_Temperatura.Columns[j]);
                NumeroColumna = DT_Temperatura.Columns.Count;
            }

            TemperaturaActual.DataGridActualTemperatura.DataSource = DT_Temperatura;
            TemperaturaActual.DataGridActualTemperatura.Columns[0].HeaderText = "Fecha";
            TemperaturaActual.DataGridActualTemperatura.Columns[1].HeaderText = "Tiempo";
            TemperaturaActual.DataGridActualTemperatura.Columns[2].HeaderText = "Milisegundos";
            TemperaturaActual.DataGridActualTemperatura.Columns[3].HeaderText = "TI_7032";
            TemperaturaActual.DataGridActualTemperatura.Columns[4].HeaderText = "TI_7003";
            TemperaturaActual.DataGridActualTemperatura.Columns[5].HeaderText = "TI_7002";
            TemperaturaActual.DataGridActualTemperatura.Columns[6].HeaderText = "TI_7005";
            TemperaturaActual.DataGridActualTemperatura.Columns[7].HeaderText = "TI_7012";
            TemperaturaActual.DataGridActualTemperatura.Columns[8].HeaderText = "TI_7022";
            TemperaturaActual.DataGridActualTemperatura.Columns[9].HeaderText = "TI_7042";
            TemperaturaActual.DataGridActualTemperatura.Columns[10].HeaderText = "TI_7004";
            TemperaturaActual.DataGridActualTemperatura.Columns[11].HeaderText = "TI_7080";
            TemperaturaActual.DataGridActualTemperatura.Columns[12].HeaderText = "TI_7093";
            TemperaturaActual.DataGridActualTemperatura.Columns[13].HeaderText = "TI_7086";
            TemperaturaActual.DataGridActualTemperatura.Columns[14].HeaderText = "TI_7091";
            TemperaturaActual.DataGridActualTemperatura.Columns[15].HeaderText = "TI_7094_U";
            TemperaturaActual.DataGridActualTemperatura.Columns[16].HeaderText = "TI_7094_V";
            TemperaturaActual.DataGridActualTemperatura.Columns[17].HeaderText = "TI_7094_W";
            TemperaturaActual.DataGridActualTemperatura.Columns[18].HeaderText = "TI_7090";
            TemperaturaActual.DataGridActualTemperatura.Columns[19].HeaderText = "TI_7092";

            TemperaturaActual.ShowDialog();
        }
    }
        
}
