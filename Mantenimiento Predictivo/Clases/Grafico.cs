using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using ZedGraph; 

namespace Mantenimiento_Predictivo.Clases
{
    public class Grafico
    {
        double[] x;
        double[] y;
        double[] y_r;
        public PointPairList graficar(DataGridView dg, int indice)
        {
             x = new double[dg.Rows.Count-1];
             y = new double[dg.Rows.Count-1];
            ArrayList list = new ArrayList(); 

            // String to DateTime            
            
            for (int i = 0; i < dg.Rows.Count-1; i++)
            {

                try
                {/*
                    string hora = null;
                    DateTime MyDateTime;
                    MyDateTime = new DateTime();

                    hora = dg.Rows[i].Cells[1].Value.ToString();
                    MyDateTime = DateTime.ParseExact(hora, "HH:mm:ss", null);
                    string seg = null;
                    seg=MyDateTime.Second.ToString();
                    string min = null;
                    min=MyDateTime.Minute.ToString();
                    string hour = null;
                    hour=MyDateTime.Hour.ToString();
                    double suma = double.Parse(min) * 60 + double.Parse(hour) * 60 * 60 + double.Parse(seg);
                   */ 
                   
                    //x[i]=suma;
                    

                    x[i] = i;       
                }
                catch (Exception error){
                    MessageBox.Show("error" + error);
                }
                
            }


            



            for (int v = 0; v < dg.Rows.Count-1; v++)
            {
                
                // y[i] = Math.Sin(0.3 * x[i]);
                //z[i] = Math.Cos(0.3 * x[i]);
                try
                {
                    string valores = null;
                    valores = dg.Rows[v].Cells[indice+3].Value.ToString();
                    y[v] = double.Parse(valores);
                    //y[v] =v;
                }catch(Exception e){
                    MessageBox.Show("error" + e);
                }
                //y[i] = i + 10;
            }

            // This is to remove all plots
            

            // GraphPane object holds one or more Curve objects (or plots)
            

            // PointPairList holds the data for plotting, X and Y arrays 
            PointPairList spl1 = new PointPairList(x, y);




            return spl1;
        }

        public PointPairList alarma(int count, int indice)
        {
            PointPairList alarm = new PointPairList();
            String ConsultaSQL_2 = "SELECT alarma FROM dbo.Sensores_Maquinas WHERE ID_Sensor =" + indice;
            DataTable DataAlarma = Clases.ManejoBaseDatos.GetDataTable(ConsultaSQL_2);

            alarm.Add(0, double.Parse(DataAlarma.Rows[0][0].ToString()));
            alarm.Add(count, double.Parse(DataAlarma.Rows[0][0].ToString()));
            return alarm;
        
        }
       

    }
}
