using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO;

namespace Mantenimiento_Predictivo
{   
    public partial class MainMantenimiento : Form
    {
        private String RutaVibracion;
        private String RutaPresion;
        private String RutaTemperatura;
        private String RutaTurbo7;
        
        
   
        DataTable DatosTemperatura;
        DataTable DatosVibracion;
        DataTable DatosPresion;
        DataTable Turbo7;
        
        //int IndexVibracion, IndexMaquinaVibracion;
        //int IndexPresion, IndexMaquinaPresion;
        //int IndexTemperatura, IndexMaquinaTemperatura;
        
        

        Clases.Grafico Puntos = new Clases.Grafico();
        
        public MainMantenimiento()
        {
            InitializeComponent();

            BotonVisualizarVibracion.Enabled = false;
            BotonVisualizarTemperatura.Enabled = false;
            BotonVisualizarPresion.Enabled = false;
            BotonVisualizarTurbo.Enabled = false;
           // btn_prediccion.Enabled = false;
            GraphPane PanelVibracion = GraficoHistoricoVibr.GraphPane;
            PanelVibracion.Title.Text = "Grafico Historico";
            PanelVibracion.XAxis.Title.Text = "Tiempo";
            PanelVibracion.YAxis.Title.Text = "Valor Sensor";

            GraphPane PanelTemperatura = GraficoHistoricoVibr.GraphPane;
            PanelTemperatura.Title.Text = "Grafico Historico";
            PanelTemperatura.XAxis.Title.Text = "Tiempo";
            PanelTemperatura.YAxis.Title.Text = "Valor Sensor";
            
            GraphPane PanelPresion = GraficoHistoricoVibr.GraphPane;
            PanelPresion.Title.Text = "Grafico Historico";
            PanelPresion.XAxis.Title.Text = "Tiempo";
            PanelPresion.YAxis.Title.Text = "Valor Sensor";
        }

        private void CargaDBFvibracion(object sender, EventArgs e)
        {
            try
            {
                RutaVibracion = CargarArchivo();
                if(RutaVibracion!=null){
                check_vibracion.Checked = true;
                check_vibracion.Text = "Cargado";
                DatosVibracion = Clases.ParseDBF.ReadDBF(RutaVibracion);
                BotonVisualizarVibracion.Enabled = true;}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargaDBFtemperatura(object sender, EventArgs e)
        {
            try
            {
                RutaTemperatura = CargarArchivo();
                if(RutaTemperatura!=null){
                    check_temperatura.Checked = true;
                    check_temperatura.Text = "Cargado";
                    DatosTemperatura = Clases.ParseDBF.ReadDBF(RutaTemperatura);
                    BotonVisualizarTemperatura.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargaDBFpresion(object sender, EventArgs e)
        {
            try
            {
                RutaPresion = CargarArchivo();

                if (RutaPresion != null)
                {
                    check_presion.Checked = true;
                    check_presion.Text = "Cargado";
                    DatosPresion = Clases.ParseDBF.ReadDBF(RutaPresion);
                    BotonVisualizarPresion.Enabled = true;
                    //MessageBox.Show("" + DatosPresion.Columns.Count);
                    for (int i = 0; i < DatosPresion.Rows.Count; i++)
                    {
                        for (int j = 4; j < DatosPresion.Columns.Count - 1; j = j + 2)
                        {
                            if (j.Equals(8))
                            {
                                string valor = DatosPresion.Rows[i][j].ToString();
                                string valor_nuevo = valor.Insert(3, ",");
                                DatosPresion.Rows[i][j] = valor_nuevo;
                            }
                            else
                            {
                                string valor = DatosPresion.Rows[i][j].ToString();
                                string valor_nuevo = valor.Insert(2, ",");

                                DatosPresion.Rows[i][j] = valor_nuevo;

                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargaDBFturbo7(object sender, EventArgs e)
        {
            try
            {
                RutaTurbo7 = CargarArchivo();
                if (RutaTurbo7 != null)
                {
                    check_turbo7.Checked = true;
                    check_turbo7.Text = "Cargado";
                    Turbo7 = Clases.ParseDBF.ReadDBF(RutaTurbo7);
                    /*
                    Turbo7.Columns.Add(temp.Columns[0]);
                    Turbo7.Columns.Add(temp.Columns[1]);
                    Turbo7.Columns.Add(temp.Columns[2]);
                    Turbo7.Columns.Add(temp.Columns[0]);
                    Turbo7.Columns.Add(temp.Columns[0]);
                    */
                    
                    BotonVisualizarTurbo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void VisualizarVibracion(object sender, EventArgs e)
        {
            Clases.VisualizarDatos.MostrarVibracion(DatosVibracion);
        }

        private void VisualizarTemperatura(object sender, EventArgs e)
        {
            Clases.VisualizarDatos.MostrarTemperatura(DatosTemperatura);
        }

        private void VisualizarPresion(object sender, EventArgs e)
        {
            Clases.VisualizarDatos.MostrarPresion(DatosPresion);
        }

       
        private void AlmacenarDatos(object sender, EventArgs e)
        {   
            
            if (DatosVibracion.Rows[4][0].Equals(DatosTemperatura.Rows[4][0]) && DatosVibracion.Rows[4][0].Equals(DatosPresion.Rows[4][0]))
            {
                Clases.ManejoBaseDatos.AlmacenarDatos("dbo.Vibracion_Compresor", DatosVibracion);
                Clases.ManejoBaseDatos.AlmacenarDatos("dbo.Temperatura_Compresor", DatosTemperatura);
                Clases.ManejoBaseDatos.AlmacenarDatos("dbo.Presion_Compresor", DatosPresion);
            }
            else {

                MessageBox.Show("Imposible Guardar.Los archivos no corresponden a las mismas fechas");
            }
        }


        private void SeleccionActivoVibracion(object sender, EventArgs e)
        {
            ComboBoxVibr.Enabled = false;
            

            if (ActivoVibracion.SelectedIndex == 0)
            {
                DateTime FechaInicio = Clases.ManejoBaseDatos.ReturnFecha("SELECT MIN(Date) AS FechaInicio FROM Vibracion_Compresor;");
                DateTime FechaFinal = Clases.ManejoBaseDatos.ReturnFecha("SELECT Max(Date) AS FechaFinal FROM Vibracion_Compresor;");
                FechaInicioVibracion.MinDate = FechaInicio;
                FechaInicioVibracion.MaxDate = FechaFinal;
                FechaFinalVibracion.MinDate = FechaInicio;
                FechaFinalVibracion.MaxDate = FechaFinal;

                this.sensores_MaquinasTableAdapter.Fill(this.sensoresVibracion.Sensores_Maquinas);
            }
            else
            {
                //DateTime FechaInicio = Clases.ManejoBaseDatos.ReturnFecha("SELECT MIN(Date) AS FechaInicio FROM Vibracion_Turbo7;");
                //DateTime FechaFinal = Clases.ManejoBaseDatos.ReturnFecha("SELECT MAX(Date) AS FechaFinal FROM Vibracion_Turbo7;");
                //FechaInicioVibracion.MinDate = FechaInicio;
                //FechaInicioVibracion.MaxDate = FechaFinal;
                //FechaFinalVibracion.MinDate = FechaInicio;
                //FechaFinalVibracion.MaxDate = FechaFinal;
            }
            
        }

        private void SeleccionActivoTemperatura(object sender, EventArgs e)
        {
            ComboBoxTemp.Enabled = false;
            

            if (ActivoTemperatura.SelectedIndex == 0)
            {
                DateTime FechaInicio = Clases.ManejoBaseDatos.ReturnFecha("SELECT MIN(Date) AS FechaInicio FROM Temperatura_Compresor;");
                DateTime FechaFinal = Clases.ManejoBaseDatos.ReturnFecha("SELECT Max(Date) AS FechaFinal FROM Temperatura_Compresor;");
                FechaInicioTemperatura.MinDate = FechaInicio;
                FechaInicioTemperatura.MaxDate = FechaFinal;
                FechaFinalTemperatura.MinDate = FechaInicio;
                FechaFinalTemperatura.MaxDate = FechaFinal;

                this.sensores_MaquinasTableAdapter1.Fill(this.sensoresTemperatura.Sensores_Maquinas);
            }
            else
            {
                //DateTime FechaInicio = Clases.ManejoBaseDatos.ReturnFecha("SELECT MIN(Date) AS FechaInicio FROM Temperatura_Turbo7;");
                //DateTime FechaFinal = Clases.ManejoBaseDatos.ReturnFecha("SELECT MAX(Date) AS FechaFinal FROM Temperatura_Turbo7;");
                //FechaInicioTemperatura.MinDate = FechaInicio;
                //FechaInicioTemperatura.MaxDate = FechaFinal;
                //FechaFinalTemperatura.MinDate = FechaInicio;
                //FechaFinalTemperatura.MaxDate = FechaFinal;
            }
        }

        private void SeleccionActivoPresion(object sender, EventArgs e)
        {
           
            ComboBoxPres.Enabled = false;


            if (comboBox_presion.SelectedIndex == 0)
            {
                DateTime FechaInicio = Clases.ManejoBaseDatos.ReturnFecha("SELECT MIN(Date) AS FechaInicio FROM dbo.Presion_Compresor;");
                DateTime FechaFinal = Clases.ManejoBaseDatos.ReturnFecha("SELECT Max(Date) AS FechaFinal FROM dbo.Presion_Compresor;");
                FechaInicioPresion.MinDate = FechaInicio;
                FechaInicioPresion.MaxDate = FechaFinal;
                FechaFinalPresion.MinDate = FechaInicio;
                FechaFinalPresion.MaxDate = FechaFinal;
               

                this.sensores_MaquinasTableAdapter2.Fill(this.sensoresPresion.Sensores_Maquinas);
            }
            else
            {
                //DateTime FechaInicio = Clases.ManejoBaseDatos.ReturnFecha("SELECT MIN(Date) AS FechaInicio FROM Presion_Turbo7;");
                //DateTime FechaFinal = Clases.ManejoBaseDatos.ReturnFecha("SELECT MAX(Date) AS FechaFinal FROM Presion_Turbo7;");
                //FechaInicioPresion.MinDate = FechaInicio;
                //FechaInicioPresion.MaxDate = FechaFinal;
                //FechaFinalPresion.MinDate = FechaInicio;
                //FechaFinalPresion.MaxDate = FechaFinal;
            }
        }

        // voy aca


        private void ComboBoxVibracion(object sender, EventArgs e)
        {

            if (ComboBoxVibr.Enabled == true)
            {
                int IndexVibracion = ComboBoxVibr.SelectedIndex;

                GraficoHistoricoVibr.GraphPane.CurveList.Clear();
                GraphPane PanelVibracion = GraficoHistoricoVibr.GraphPane;

                PointPairList val = Puntos.graficar(DataGridVibr, IndexVibracion);
                LineItem myCurve1 = PanelVibracion.AddCurve("Valores Sensor", val, Color.Blue, SymbolType.None);
                myCurve1.Line.Width = 1;

                PointPairList alarm = Puntos.alarma(DataGridVibr.RowCount, IndexVibracion+1);
                LineItem myCurve2 = PanelVibracion.AddCurve("Alarma", alarm, Color.Red, SymbolType.Circle);
                myCurve2.Line.Width = 3;

                GraficoHistoricoVibr.AxisChange();
                GraficoHistoricoVibr.Invalidate();
                GraficoHistoricoVibr.Refresh();
            }
        }

        private void ComboBoxTemperatura(object sender, EventArgs e)
        {
            if (ComboBoxTemp.Enabled == true)
            {
                int IndexTemperatura = ComboBoxTemp.SelectedIndex;

                GraficoHistoricoTemp.GraphPane.CurveList.Clear();
                GraphPane PanelTemperatura = GraficoHistoricoTemp.GraphPane;

                PointPairList val = Puntos.graficar(DataGridTemp, IndexTemperatura);
                LineItem myCurve1 = PanelTemperatura.AddCurve("Valores Sensor", val, Color.Blue, SymbolType.None);
                myCurve1.Line.Width = 1;
                
                PointPairList alarm = Puntos.alarma(DataGridTemp.RowCount, IndexTemperatura+18);
                LineItem myCurve2 = PanelTemperatura.AddCurve("Alarma", alarm, Color.Red, SymbolType.Circle);
                myCurve2.Line.Width = 3;

                GraficoHistoricoTemp.AxisChange();
                GraficoHistoricoTemp.Invalidate();
                GraficoHistoricoTemp.Refresh();

            }
        }

        private void ComboBoxPresion(object sender, EventArgs e)
        {
            if (ComboBoxPres.Enabled == true)
            {
                int IndexPresion = ComboBoxPres.SelectedIndex;

                GraficoHistoricoPres.GraphPane.CurveList.Clear();
                GraphPane PanelPresion = GraficoHistoricoPres.GraphPane;

                PointPairList val = Puntos.graficar(DataGridPres, IndexPresion);
                LineItem myCurve1 = PanelPresion.AddCurve("Valores Sensor", val, Color.Blue, SymbolType.None);
                myCurve1.Line.Width = 1;

                PointPairList alarm = Puntos.alarma(DataGridPres.RowCount, IndexPresion+35);
                LineItem myCurve2 = PanelPresion.AddCurve("Alarma", alarm, Color.Red, SymbolType.Circle);
                myCurve2.Line.Width = 3;

                GraficoHistoricoPres.AxisChange();
                GraficoHistoricoPres.Invalidate();
                GraficoHistoricoPres.Refresh();
            }
        }

        private void CargarGraficarVibracion(object sender, EventArgs e)
        {
            ComboBoxVibr.Enabled = true;

            DateTime Inicio = FechaInicioVibracion.SelectionStart;
            DateTime Termino = FechaFinalVibracion.SelectionStart;
            String ConsultaSQL = "SELECT * FROM Vibracion_Compresor WHERE Date BETWEEN '"+Inicio.Year+"-"+Inicio.Month+"-"+Inicio.Day+"' AND '"+Termino.Year+"-"+Termino.Month+"-"+Termino.Day+"'";

            DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
            DataGridVibr.DataSource = DataVibracion;

            DataGridVibr.Columns[0].HeaderText = "Fecha";
            DataGridVibr.Columns[1].HeaderText = "Tiempo";
            DataGridVibr.Columns[2].HeaderText = "Milisegundos";
            DataGridVibr.Columns[3].HeaderText = "F7001";
            DataGridVibr.Columns[4].HeaderText = "F7009";
            DataGridVibr.Columns[5].HeaderText = "F7011_X";
            DataGridVibr.Columns[6].HeaderText = "F7011_Y";
            DataGridVibr.Columns[7].HeaderText = "F7021_X";
            DataGridVibr.Columns[8].HeaderText = "F7021_Y";
            DataGridVibr.Columns[9].HeaderText = "F7031_X";
            DataGridVibr.Columns[10].HeaderText = "F7031_Y";
            DataGridVibr.Columns[11].HeaderText = "F7041_X";
            DataGridVibr.Columns[12].HeaderText = "F7041_Y";
            DataGridVibr.Columns[13].HeaderText = "F7092_X";
            DataGridVibr.Columns[14].HeaderText = "F7092_Y";
            DataGridVibr.Columns[15].HeaderText = "F7093_X";
            DataGridVibr.Columns[16].HeaderText = "F7093_Y";
            DataGridVibr.Columns[17].HeaderText = "F7096";
            DataGridVibr.Columns[18].HeaderText = "F7099";
            DataGridVibr.Columns[19].HeaderText = "F7080";
        }

        private void CargarGraficarTemperatura(object sender, EventArgs e)
        {
            ComboBoxTemp.Enabled = true;

            DateTime Inicio = FechaInicioTemperatura.SelectionStart;
            DateTime Termino = FechaFinalTemperatura.SelectionStart;
            String ConsultaSQL = "SELECT * FROM Temperatura_Compresor WHERE Date BETWEEN '" + Inicio.Year + "-" + Inicio.Month + "-" + Inicio.Day + "' AND '" + Termino.Year + "-" + Termino.Month + "-" + Termino.Day + "'";

            DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
            DataGridTemp.DataSource = DataTemperatura;

            DataGridTemp.Columns[0].HeaderText = "Fecha";
            DataGridTemp.Columns[1].HeaderText = "Tiempo";
            DataGridTemp.Columns[2].HeaderText = "Milisegundos";
            DataGridTemp.Columns[3].HeaderText = "F7032";
            DataGridTemp.Columns[4].HeaderText = "F7003";
            DataGridTemp.Columns[5].HeaderText = "F7002";
            DataGridTemp.Columns[6].HeaderText = "F7005";
            DataGridTemp.Columns[7].HeaderText = "F7012";
            DataGridTemp.Columns[8].HeaderText = "F7022";
            DataGridTemp.Columns[9].HeaderText = "F7042";
            DataGridTemp.Columns[10].HeaderText = "F7004";
            DataGridTemp.Columns[11].HeaderText = "F7080";
            DataGridTemp.Columns[12].HeaderText = "F7086";
            DataGridTemp.Columns[13].HeaderText = "F7093";           
            DataGridTemp.Columns[14].HeaderText = "F7091";
            DataGridTemp.Columns[15].HeaderText = "F7094_U";
            DataGridTemp.Columns[16].HeaderText = "F7094_V";
            DataGridTemp.Columns[17].HeaderText = "F7094_W";
            DataGridTemp.Columns[18].HeaderText = "F7090";
            DataGridTemp.Columns[19].HeaderText = "F7092";
        }

        private void CargaGraficarPresion(object sender, EventArgs e)
        {
            ComboBoxPres.Enabled = true;
            
            DateTime Inicio = FechaInicioPresion.SelectionStart;
            DateTime Termino = FechaFinalPresion.SelectionStart;
            String ConsultaSQL = "SELECT * FROM Presion_Compresor WHERE Date BETWEEN '" + Inicio.Year + "-" + Inicio.Month + "-" + Inicio.Day + "' AND '" + Termino.Year + "-" + Termino.Month + "-" + Termino.Day + "'";

            DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
            DataGridPres.DataSource = DataPresion;

            DataGridPres.Columns[0].HeaderText = "Fecha";
            DataGridPres.Columns[1].HeaderText = "Tiempo";
            DataGridPres.Columns[2].HeaderText = "Milisegundos";
            DataGridPres.Columns[3].HeaderText = "F7080_LI";
            DataGridPres.Columns[4].HeaderText = "F7080_TI";
            DataGridPres.Columns[5].HeaderText = "F7086_PI";
            DataGridPres.Columns[6].HeaderText = "F7086_TI";
            
        }



        private void btn_buscar_todo_Click(object sender, EventArgs e)
        {
            DateTime f_inicio = fecha_inicio.Value;
            DateTime f_final = fecha_final.Value;

            String ConsultaSQL = "SELECT Fecha,Set_Sensores,Nombre_Falla FROM dbo.Historial_Fallas WHERE Id_Maquina =" + (comboBox_act_hist_falla.SelectedIndex + 1);

            DataTable Data_Historicos = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
            dt_hist_alarm.DataSource = Data_Historicos;
        }

        private void btn_buscar_hist_alarm_Click(object sender, EventArgs e)
        {
            DateTime f_inicio = fecha_inicio.Value;
            DateTime f_final = fecha_final.Value;


            String ConsultaSQL = "SELECT Fecha,Set_Sensores,Nombre_Falla FROM dbo.Historial_Fallas WHERE Fecha BETWEEN '" + f_inicio.Year + "-" + f_inicio.Month + "-" + f_inicio.Day + "' AND '" + f_final.Year + "-" + f_final.Month + "-" + f_final.Day + "' AND Id_Maquina =" + (comboBox_act_hist_falla.SelectedIndex + 1);

            DataTable Data_Historicos = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
            dt_hist_alarm.DataSource = Data_Historicos;
            //string fecha = Convert.ToString(fecha_inicio.Value.ToShortDateString());
            //this.Text = result.ToString();
            // Metodos.ExportarExcel exp = new Metodos.ExportarExcel();
            //exp.buscar(dt_hist_alarm, f_inicio, f_final);
        }

        

   

        private void btn_exportar_Click(object sender, EventArgs e)
        {
             Clases.ExportarExcel XML = new Clases.ExportarExcel();
            XML.exportar(dt_hist_alarm);
        }

        private String CargarArchivo()
        {
            String Ruta = null;
            OpenFileDialog file_dialog = new OpenFileDialog();
            file_dialog.Title = "Seleccione Archivo dbf";
            file_dialog.InitialDirectory = @"D:\Datos";
            file_dialog.Filter = "DBF Files(*.dbf)|*.dbf";

            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                Ruta = file_dialog.FileName;
            }
            return Ruta;
        }

        private void CrearArchivos_Click(object sender, EventArgs e)
        {
            /*
            StreamWriter peso_in = File.CreateText("Pesos_ini.txt");
            
            peso_in.WriteLine("12");
            peso_in.WriteLine("1");
            Random r = new Random();
            
            for(int i = 0; i < 169; i++)
            {
                double aleatorio = r.NextDouble();
                peso_in.WriteLine(aleatorio);
                
            }
            peso_in.Close();*/
            
            try
            {

                
                Clases.Crear_Entradas entradas = new Clases.Crear_Entradas();
                DataTable data = new DataTable();

                StreamWriter sw1 = File.CreateText("Test_VI7093X.txt");

                String Xs = "";
                for (int i = 0; i < 12; i++)
                {
                    Xs = Xs + "X" + i + ",";

                }
                Xs = Xs + " Y";
                sw1.WriteLine(Xs);
                sw1.Close();
                for (int i = 1; i < 32; i++)
                {
                    String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                    String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                    String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                    data = entradas.definir_clases_prueba(DataVibracion, DataTemperatura, DataPresion);
                    entradas.crear_entradas_12(data,12,"Test_VI7093X");
                }

                StreamWriter sw2 = File.CreateText("Test_VI7093Y.txt");

                String Xs2 = "";
                for (int i = 0; i < 12; i++)
                {
                    Xs2 = Xs2 + "X" + i + ",";

                }
                Xs2 = Xs2 + " Y";
                sw2.WriteLine(Xs2);
                sw2.Close();
                for (int i = 1; i < 32; i++)
                {
                    String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                    String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                    String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                    data = entradas.definir_clases_prueba(DataVibracion, DataTemperatura, DataPresion);
                    entradas.crear_entradas_12(data, 13,"Test_VI7093Y");
                }

                StreamWriter sw3 = File.CreateText("Test_TI7093.txt");

                String Xs3 = "";
                for (int i = 0; i < 12; i++)
                {
                    Xs3 = Xs3 + "X" + i + ",";

                }
                Xs3 = Xs3 + " Y";
                sw3.WriteLine(Xs3);
                sw3.Close();
                for (int i = 1; i < 32; i++)
                {
                    String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                    String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                    String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                    data = entradas.definir_clases_prueba(DataVibracion, DataTemperatura, DataPresion);
                    entradas.crear_entradas_12(data, 26,"Test_TI7093");
                }

                StreamWriter sw4 = File.CreateText("Test_TI7092.txt");

                String Xs4 = "";
                for (int i = 0; i < 12; i++)
                {
                    Xs4 = Xs4 + "X" + i + ",";

                }
                Xs4 = Xs4 + " Y";
                sw4.WriteLine(Xs4);
                sw4.Close();
                for (int i = 1; i < 32; i++)
                {
                    String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                    String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                    String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                    data = entradas.definir_clases_prueba(DataVibracion, DataTemperatura, DataPresion);
                    entradas.crear_entradas_12(data, 33,"Test_TI7092");
                }


                StreamWriter sw5 = File.CreateText("Test_VI7092X.txt");

                String Xs5 = "";
                for (int i = 0; i < 12; i++)
                {
                    Xs5 = Xs5 + "X" + i + ",";

                }
                Xs5 = Xs5 + " Y";
                sw5.WriteLine(Xs5);
                sw5.Close();
                for (int i = 1; i < 32; i++)
                {
                    String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                    String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                    String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                    data = entradas.definir_clases_prueba(DataVibracion, DataTemperatura, DataPresion);
                    entradas.crear_entradas_12(data, 10,"Test_VI7092X");
                }

                StreamWriter sw6 = File.CreateText("Test_VI7092Y.txt");

                String Xs6 = "";
                for (int i = 0; i < 12; i++)
                {
                    Xs6 = Xs6 + "X" + i + ",";

                }
                Xs6 = Xs6 + " Y";
                sw6.WriteLine(Xs6);
                sw6.Close();
                for (int i = 1; i < 32; i++)
                {
                    String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                    String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                    String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Compresor WHERE Date BETWEEN '2011-01-" + i + "' AND '2011-01-" + i + "'";
                    DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                    data = entradas.definir_clases_prueba(DataVibracion, DataTemperatura, DataPresion);
                    entradas.crear_entradas_12(data, 11,"Test_VI7092Y");
                }
                MessageBox.Show("Exito");


            }
            catch (Exception exx)
            {
                MessageBox.Show("" + exx);
            }
        }

        private void btn_prediccion_Click(object sender, EventArgs e)
        {
                int numeroEntradas_compresor = 12;
               // int numeroRedes_compresor=6;
                //PerceptronMulticapa RNA;

                List<PerceptronMulticapa> RNAs = new List<PerceptronMulticapa>();

                RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
                RNAs[0].cargarPesos(".\\Pesos_VI7092X.txt");
                RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
                RNAs[1].cargarPesos(".\\Pesos_VI7092Y.txt");
                RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
                RNAs[2].cargarPesos(".\\Pesos_VI7093X.txt");
                RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
                RNAs[3].cargarPesos(".\\Pesos_VI7093Y.txt");
                RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
                RNAs[4].cargarPesos(".\\Pesos_TI7093.txt");
                RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
                RNAs[5].cargarPesos(".\\Pesos_TI7092.txt");


                try
                {
                    double[] entrada = new double[numeroEntradas_compresor];
                    entrada[0] =  (double.Parse(text_box_vi7092x.Text.Replace('.', ','))) / 106.74;
                    entrada[1] =  (double.Parse(text_box_vi7092y.Text.Replace('.', ','))) / 47.57;
                    entrada[2] =  (double.Parse(text_box_vi7093x.Text.Replace('.', ','))) / 15.58;
                    entrada[3] =  (double.Parse(text_box_vi7093y.Text.Replace('.', ','))) / 17.81;
                    entrada[4] =  (double.Parse(text_box_vi7096.Text.Replace('.', ','))) / 0.67;
                    entrada[5] =  (double.Parse(text_box_ti7093.Text.Replace('.', ','))) / 80;
                    entrada[6] =  (double.Parse(text_box_ti7091.Text.Replace('.', ','))) / 30.1;
                    entrada[7] =  (double.Parse(text_box_7094u.Text.Replace('.', ','))) / 87.6;
                    entrada[8] =  (double.Parse(text_box_ti7094v.Text.Replace('.', ','))) / 89.3;
                    entrada[9] =  (double.Parse(text_box_ti7094w.Text.Replace('.', ','))) / 84.9;
                    entrada[10] =  (double.Parse(text_box_ti7090.Text.Replace('.', ','))) / 32;
                    entrada[11] =  (double.Parse(text_box_ti7092.Text.Replace('.', ','))) / 78.8;

                    RNAs[0].entradaX = entrada;
                    RNAs[1].entradaX = entrada;
                    RNAs[2].entradaX = entrada;
                    RNAs[3].entradaX = entrada;
                    RNAs[4].entradaX = entrada;
                    RNAs[5].entradaX = entrada;

                    if (RNAs[0] != null) text_box_salida_vi7092x.Text = (RNAs[0].funcionActivacion() *106.74).ToString();// 106.74* 32.800000000000004
                    if (RNAs[1] != null) text_box_salida_vi7092y.Text = (0.5 + RNAs[1].funcionActivacion() * 47.57).ToString();//* 47.5732.800000000000004
                    if (RNAs[2] != null) text_box_salida_vi7093x.Text = (-1 + RNAs[2].funcionActivacion() * 15.58).ToString();//* 32.800000000000004
                    if (RNAs[3] != null) text_box_salida_vi7093y.Text = (-1 + RNAs[3].funcionActivacion() * 17.81).ToString();//* 32.800000000000004
                    if (RNAs[4] != null) text_box_salida_ti7093.Text = (2 + RNAs[4].funcionActivacion() * 80).ToString();//* 55.932.800000000000004
                    if (RNAs[5] != null) text_box_salida_ti7092.Text = (RNAs[5].funcionActivacion() * 78.8).ToString();//*77.7 32.800000000000004*/                    
                    
                    string salida_prediccion = "";

                    DateTime Hoy = DateTime.Today;
                    //string fecha_actual = Hoy.ToString("yyyy-MM-dd");
                   
                    if ((RNAs[0].funcionActivacion() * 106.74) > 90) 
                    {
                        String ConsultaSQL = "SELECT * FROM dbo.Fallas WHERE Id=1";
                        DataTable consulta = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
                        salida_prediccion = salida_prediccion + "\nFalla Sensor VI7092X:    " + consulta.Rows[0][1].ToString() + "\nPosible causa:  " + consulta.Rows[0][2].ToString() + "\nAccion: " + consulta.Rows[0][3].ToString()+"\n";

                        Clases.ManejoBaseDatos.Insertar_Fallas(Hoy, consulta.Rows[0][1].ToString(), 1, "VI7092X");
                    }
                    if ((RNAs[1].funcionActivacion() * 47.57) > 40)
                    {
                        String ConsultaSQL = "SELECT * FROM dbo.Fallas WHERE Id=1";
                        DataTable consulta = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
                        salida_prediccion = salida_prediccion + "\nFalla Sensor VI7092Y:    " + consulta.Rows[0][1].ToString() + "\nPosible causa:  " + consulta.Rows[0][2].ToString() + "\nAccion: " + consulta.Rows[0][3].ToString() + "\n";
                        Clases.ManejoBaseDatos.Insertar_Fallas(Hoy, consulta.Rows[0][1].ToString(), 1, "VI7092Y");
                    }

                    if ((RNAs[2].funcionActivacion() * 15.58) > 15){
                        String ConsultaSQL = "SELECT * FROM dbo.Fallas WHERE Id=1";
                        DataTable consulta = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
                        salida_prediccion = salida_prediccion + "\nFalla Sensor VI7093X:    " + consulta.Rows[0][1].ToString() + "\nPosible causa:  " + consulta.Rows[0][2].ToString() + "\nAccion: " + consulta.Rows[0][3].ToString() + "\n";
                        Clases.ManejoBaseDatos.Insertar_Fallas(Hoy, consulta.Rows[0][1].ToString(), 1, "VI7093X");
                    }

                    if ((RNAs[3].funcionActivacion() * 17.81) > 15)
                    {
                        String ConsultaSQL = "SELECT * FROM dbo.Fallas WHERE Id=1";
                        DataTable consulta = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
                        salida_prediccion = salida_prediccion + "\nFalla Sensor VI7093Y:    " + consulta.Rows[0][1].ToString() + "\nPosible causa:  " + consulta.Rows[0][2].ToString() + "\nAccion: " + consulta.Rows[0][3].ToString() + "\n";
                        Clases.ManejoBaseDatos.Insertar_Fallas(Hoy, consulta.Rows[0][1].ToString(), 1, "VI7093Y");
                    }

                    if ((RNAs[4].funcionActivacion() * 80) > 78.5 )
                    {
                        String ConsultaSQL = "SELECT * FROM dbo.Fallas WHERE Id=2";
                        DataTable consulta = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
                        salida_prediccion = salida_prediccion + "\nFalla Sensor TI7093: " + consulta.Rows[0][1].ToString() + "\nPosible causa:   " + consulta.Rows[0][2].ToString() + "\nAccion:    " + consulta.Rows[0][3].ToString() + "\n";
                        Clases.ManejoBaseDatos.Insertar_Fallas(Hoy, consulta.Rows[0][1].ToString(), 1, "TI7093");
                    }


                    if ((RNAs[5].funcionActivacion() * 78.8) > 77.5)
                    {
                        String ConsultaSQL = "SELECT * FROM dbo.Fallas WHERE Id=2";
                        DataTable consulta = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL);
                        salida_prediccion = salida_prediccion + "\nFalla Sensor TI7092: " + consulta.Rows[0][1].ToString() + "\nPosible causa:  " + consulta.Rows[0][2].ToString() + "\nAccion: " + consulta.Rows[0][3].ToString() + "\n";

                        Clases.ManejoBaseDatos.Insertar_Fallas(Hoy, consulta.Rows[0][1].ToString(), 1, "TI7092");
                    }

                    if (salida_prediccion.Equals(""))
                    {
                       AreaTexto.Text = "";
                    }
                    else 
                    {
                        AreaTexto.Text = salida_prediccion;
                        //salida_prediccion_label.Text = salida_prediccion;
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error:" + ex.Message);
                }


        }

        private void BotonVisualizarTurbo_Click(object sender, EventArgs e)
        {

        }

        private void btn_Almacenar_Turbo7_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tabla_vibracion = new DataTable();
                DataTable tabla_temperatura = new DataTable();
                DataTable tabla_presion = new DataTable();

                tabla_vibracion.Columns.Add("Date");
                tabla_vibracion.Columns.Add("Time");
                tabla_vibracion.Columns.Add("Millitm");
                tabla_vibracion.Columns.Add("1");
                tabla_vibracion.Columns.Add("2");
                tabla_vibracion.Columns.Add("3");
                tabla_vibracion.Columns.Add("4");
                tabla_vibracion.Columns.Add("5");
                tabla_vibracion.Columns.Add("6");


                
                foreach (DataRow row in Turbo7.Rows)
                {
                    //tabla_vibracion.ImportRow(row);
                    DataRow destRow = tabla_vibracion.NewRow();
                    destRow["Date"] = row["Date"];
                    destRow["Time"] = row["Time"];
                    destRow["Millitm"] = row["Millitm"];
                    destRow["1"] = row["65"];
                    destRow["2"] = row["65"];
                    destRow["3"] = row["66"];
                    destRow["4"] = row["66"];
                    destRow["5"] = row["67"];
                    destRow["6"] = row["67"];

                    tabla_vibracion.Rows.Add(destRow);
                }

                for (int i = 0; i < tabla_vibracion.Rows.Count; i++)
                {
                    for (int j = 4; j < tabla_vibracion.Columns.Count; j = j + 2)
                    {
                        string valor = tabla_vibracion.Rows[i][j].ToString();
                        valor= valor.Substring(0, 6);
                            string valor_nuevo = valor.Insert(2, ",");

                            tabla_vibracion.Rows[i][j] = valor_nuevo;                        
                    }

                }
                //vibracion


                tabla_temperatura.Columns.Add("Date");
                tabla_temperatura.Columns.Add("Time");
                tabla_temperatura.Columns.Add("Millitm");
                tabla_temperatura.Columns.Add("1");
                tabla_temperatura.Columns.Add("2");
                tabla_temperatura.Columns.Add("3");
                tabla_temperatura.Columns.Add("4");
                tabla_temperatura.Columns.Add("5");
                tabla_temperatura.Columns.Add("6");

                foreach (DataRow row in Turbo7.Rows)
                {
                    DataRow destRow = tabla_temperatura.NewRow();
                    destRow["Date"] = row["Date"];
                    destRow["Time"] = row["Time"];
                    destRow["Millitm"] = row["Millitm"];
                    destRow["1"] = row["48"];
                    destRow["2"] = row["48"];
                    destRow["3"] = row["49"];
                    destRow["4"] = row["49"];
                    destRow["5"] = row["50"];
                    destRow["6"] = row["50"];            
                    tabla_temperatura.Rows.Add(destRow);
                }
                for (int i = 0; i < tabla_temperatura.Rows.Count; i++)
                {
                    for (int j = 4; j < tabla_temperatura.Columns.Count; j = j + 2)
                    {
                        string valor = tabla_temperatura.Rows[i][j].ToString();
                        valor = valor.Substring(0, 6);
                        string valor_nuevo = valor.Insert(2, ",");

                        tabla_temperatura.Rows[i][j] = valor_nuevo;
                    }

                }



                tabla_presion.Columns.Add("Date");
                tabla_presion.Columns.Add("Time");
                tabla_presion.Columns.Add("Millitm");
                tabla_presion.Columns.Add("1");
                tabla_presion.Columns.Add("2");
               

                foreach (DataRow row in Turbo7.Rows)
                {
                    DataRow destRow = tabla_presion.NewRow();
                    destRow["Date"] = row["Date"];
                    destRow["Time"] = row["Time"];
                    destRow["Millitm"] = row["Millitm"];
                    destRow["1"] = row["30"];
                    destRow["2"] = row["30"];
                               
                    tabla_presion.Rows.Add(destRow);
                }
                for (int i = 0; i < tabla_presion.Rows.Count; i++)
                {
                    for (int j = 4; j < tabla_presion.Columns.Count; j = j + 2)
                    {
                        string valor = tabla_presion.Rows[i][j].ToString();
                        valor = valor.Substring(0, 6);
                        string valor_nuevo = valor.Insert(1, ",");

                        tabla_presion.Rows[i][j] = valor_nuevo;
                    }
                }

                dt_hist_alarm.DataSource = tabla_presion;
                
                //temp
                
               
                Clases.ManejoBaseDatos.AlmacenarDatos("dbo.Vibracion_Turbo7", tabla_vibracion); 
               Clases.ManejoBaseDatos.AlmacenarDatos("dbo.Temperatura_Turbo7", tabla_temperatura);
                Clases.ManejoBaseDatos.AlmacenarDatos("dbo.Presion_Turbo7", tabla_presion);
                MessageBox.Show("Datos almacenados");

            }catch(Exception EX){
                MessageBox.Show("Error"+EX);
            }
        }

        private void boton_prediccion_turbo7_Click(object sender, EventArgs e)
        {
            int numeroEntradas_compresor = 7;
            // int numeroRedes_compresor=6;
            //PerceptronMulticapa RNA;

            List<PerceptronMulticapa> RNAs = new List<PerceptronMulticapa>();

            RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
            RNAs[0].cargarPesos(".\\Pesos_TT508.txt");
            RNAs.Add(new PerceptronMulticapa(numeroEntradas_compresor));
            RNAs[1].cargarPesos(".\\Pesos_PT509.txt");
       

            try
            {
                double[] entrada = new double[numeroEntradas_compresor];
                entrada[0] = (double.Parse(text_box_ve523c.Text.Replace('.', ','))) / 18.1  ;
                entrada[1] = (double.Parse(text_box_523d.Text.Replace('.', ','))) / 14.5;
                entrada[2] = (double.Parse(text_box_ve523j.Text.Replace('.', ','))) / 22;
                entrada[3] = (double.Parse(text_box_te523a.Text.Replace('.', ','))) / 70.995;
                entrada[4] = (double.Parse(text_box_te523b.Text.Replace('.', ','))) / 78;
                entrada[5] = (double.Parse(text_box_tt508.Text.Replace('.', ','))) / 54.9679;
                entrada[6] = (double.Parse(text_box_pt509.Text.Replace('.', ','))) / 1.78461;
               

                RNAs[0].entradaX = entrada;
                RNAs[1].entradaX = entrada;


                if (RNAs[0] != null) text_box_salida_tt580.Text = (RNAs[0].funcionActivacion() * 54.9679).ToString();// 106.74* 32.800000000000004
                if (RNAs[1] != null) text_box_salida_pt509.Text = (RNAs[1].funcionActivacion() * 1.78461).ToString();//* 47.5732.800000000000004
               
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.Message);
            }

        }

        private void entradaTurbo7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {

                StreamWriter peso_in = File.CreateText("Pesos_ini_turbo7.txt");
            
            peso_in.WriteLine("7");
            peso_in.WriteLine("1");
            Random r = new Random();
            
            for(int i = 0; i < 64; i++)
            {
                double aleatorio = r.NextDouble();
                peso_in.WriteLine(aleatorio);
                
            }
            peso_in.Close();


                Clases.Crear_Entradas entradas = new Clases.Crear_Entradas();
                DataTable data = new DataTable();

                StreamWriter sw1 = File.CreateText("Test_PT509.txt");

                String Xs = "";
                for (int i = 0; i < 7; i++)
                {
                    Xs = Xs + "X" + i + ",";

                }
                Xs = Xs + " Y";
                sw1.WriteLine(Xs);
                sw1.Close();
                for (int i = 1; i < 32; i++)
                {
                    if (i!=8)
                    {
                        //MessageBox.Show("" + i);
                        String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Turbo7 WHERE Date BETWEEN '2012-01-" + i + "' AND '2012-01-" + i + "'";
                        DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                        String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Turbo7 WHERE Date BETWEEN '2012-01-" + i + "' AND '2012-01-" + i + "'";
                        DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                        String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Turbo7 WHERE Date BETWEEN '2012-01-" + i + "' AND '2012-01-" + i + "'";
                        DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                        data = entradas.definir_clases_prueba_turbo7(DataVibracion, DataTemperatura, DataPresion);
                        entradas.crear_entradas_turbo7(data, 6, "Test_PT509");
                        
                    }
                }

                StreamWriter sw2 = File.CreateText("Test_TT508.txt");

                String Xs2 = "";
                for (int i = 0; i < 7; i++)
                {
                    Xs2 = Xs2 + "X" + i + ",";

                }
                Xs2 = Xs2 + " Y";
                sw2.WriteLine(Xs2);
                sw2.Close();
                for (int i = 1; i < 32; i++)
                {
                    if (i != 8)
                    {
                        
                        String ConsultaSQL_1 = "SELECT * FROM dbo.Vibracion_Turbo7 WHERE Date BETWEEN '2012-01-" + i + "' AND '2012-01-" + i + "'";
                        DataTable DataVibracion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_1);
                        String ConsultaSQL_2 = "SELECT * FROM dbo.Temperatura_Turbo7 WHERE Date BETWEEN '2012-01-" + i + "' AND '2012-01-" + i + "'";
                        DataTable DataTemperatura = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);
                        String ConsultaSQL_3 = "SELECT * FROM dbo.Presion_Turbo7 WHERE Date BETWEEN '2012-01-" + i + "' AND '2012-01-" + i + "'";
                        DataTable DataPresion = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_3);
                        data = entradas.definir_clases_prueba_turbo7(DataVibracion, DataTemperatura, DataPresion);
                        entradas.crear_entradas_turbo7(data, 5, "Test_TT508");
                        //MessageBox.Show("2" + i);
                    }
                }               
                MessageBox.Show("Exito");

            }
            catch (Exception exx)
            {
                MessageBox.Show("" + exx);
            }
        }





        private void Ingreso_soloNum(object sender, KeyPressEventArgs e)
        { 
        
            String Aceptados = "0123456789," +Convert.ToChar(8);

            if (Aceptados.Contains(""+e.KeyChar)){   
                    e.Handled=false;
               }
            else
            {
                e.Handled = true;
            }
                                
        }

    

     
      

     
        
    }
}
