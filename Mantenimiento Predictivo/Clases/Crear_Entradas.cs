using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Accord.MachineLearning;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics.Formats;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Mantenimiento_Predictivo.Clases
{
    class Crear_Entradas
    {
        int contador;
       public DataTable definir_clases_prueba(DataTable dt_v, DataTable dt_t,DataTable dt_p)
       {

           DataTable mitabla = new DataTable(); 
                    
           contador = 0;         
  
           int x = 0;
   
           int contador_10en10 = 0;
           mitabla.Columns.Add("1");
           mitabla.Columns.Add("2");
           mitabla.Columns.Add("3");
           mitabla.Columns.Add("4");
           mitabla.Columns.Add("5");
           mitabla.Columns.Add("6");
           mitabla.Columns.Add("7");
           mitabla.Columns.Add("8");
           mitabla.Columns.Add("9");
           mitabla.Columns.Add("10");
           mitabla.Columns.Add("11");
           mitabla.Columns.Add("12");
           mitabla.Columns.Add("13");
           mitabla.Columns.Add("14");
           mitabla.Columns.Add("15");
           mitabla.Columns.Add("16");
           mitabla.Columns.Add("17");
           mitabla.Columns.Add("18");
           mitabla.Columns.Add("19");
           mitabla.Columns.Add("20");
           mitabla.Columns.Add("21");
           mitabla.Columns.Add("22");
           mitabla.Columns.Add("23");
           mitabla.Columns.Add("24");
           mitabla.Columns.Add("25");
           mitabla.Columns.Add("26");
           mitabla.Columns.Add("27");
           mitabla.Columns.Add("28");
           mitabla.Columns.Add("29");
           mitabla.Columns.Add("30");
           mitabla.Columns.Add("31");
           mitabla.Columns.Add("32");
           mitabla.Columns.Add("33");
           mitabla.Columns.Add("34");
           mitabla.Columns.Add("35");
           mitabla.Columns.Add("36");
           mitabla.Columns.Add("37");
           mitabla.Columns.Add("38");

           //mitabla.Columns.Add("Y");

         /*  StreamWriter sw = File.CreateText("Test.txt");

           String Xs = "";
           for (int i = 0; i < 38; i++)
           {
               Xs = Xs + "X" + i + "\t";

           }
           Xs = Xs + "Y";
           sw.WriteLine(Xs);
           sw.Close();*/
           for (int i = 0; i < dt_v.Rows.Count; i++)
           {
               //String texto = "";    
               if (x < dt_p.Rows.Count)
               {

                   if ((dt_t.Rows[x][1].Equals(dt_v.Rows[i][1])) && (dt_t.Rows[x][0].Equals(dt_v.Rows[i][0])))
                   {
          
                       DataRow fila = mitabla.NewRow();
                       

                       for (int j = 3; j < 20; j++)
                       {
                           double valor = double.Parse(dt_v.Rows[i][j].ToString());                           
                           fila[j-3] = valor;

                           double valor_2 = double.Parse(dt_t.Rows[x][j].ToString());
                           fila[j + 14] = valor_2;

                           if (j < 7)
                           {
                               double valor_3 = double.Parse(dt_p.Rows[x][j].ToString());
                               fila[j + 31] = valor_3;                               
                           }
                       }

             //          fila[38] = dt_t.Rows[x][1].ToString();

                 /*      for (int num = 0; num < 39;num++)
                       {
                           texto = texto + fila[num].ToString() + "\t";                           
                       } */

                       //sw.WriteLine(texto);

                       contador_10en10 = 0;
  
                       x++;
                       mitabla.Rows.Add(fila);
                   }

                   
                   contador_10en10++;
                   if (contador_10en10 > 11)
                   {
                       contador_10en10 = 0;                     
                       x++;
                   }
               }
           }
           
           //close archivo
           return mitabla;
           
       }

       public DataTable definir_clases_prueba_turbo7(DataTable dt_v, DataTable dt_t, DataTable dt_p)
       {

           DataTable mitabla = new DataTable();

           contador = 0;                 
           mitabla.Columns.Add("1");
           mitabla.Columns.Add("2");
           mitabla.Columns.Add("3");
           mitabla.Columns.Add("4");
           mitabla.Columns.Add("5");
           mitabla.Columns.Add("6");
           mitabla.Columns.Add("7");
           mitabla.Columns.Add("8"); 

           //mitabla.Columns.Add("Y");

           /*  StreamWriter sw = File.CreateText("Test.txt");

             String Xs = "";
             for (int i = 0; i < 38; i++)
             {
                 Xs = Xs + "X" + i + "\t";

             }
             Xs = Xs + "Y";
             sw.WriteLine(Xs);
             sw.Close();*/
           for (int i = 0; i < dt_v.Rows.Count; i++)
           {
               //String texto = "";    
              
                       DataRow fila = mitabla.NewRow();
                       for (int j = 3; j < 6; j++)
                       {
                           double valor = double.Parse(dt_v.Rows[i][j].ToString());
                           fila[j - 3] = valor;

                           if (j < 6)
                           {
                               double valor_2 = double.Parse(dt_t.Rows[i][j].ToString());
                               fila[j] = valor_2;
                           }


                           if (j < 4)
                           {
                               double valor_3 = double.Parse(dt_p.Rows[i][3].ToString());
                               fila[j + 3] = valor_3;
                           }
                       }

                       //          fila[38] = dt_t.Rows[x][1].ToString();

                       /*      for (int num = 0; num < 39;num++)
                             {
                                 texto = texto + fila[num].ToString() + "\t";                           
                             } */

                       //sw.WriteLine(texto);                       
                      
                       mitabla.Rows.Add(fila);
                   }                                          
           //close archivo
           return mitabla;

       }

       public void crear_entradas(DataTable tabla_entrada,int indice_sensor) {
          
           double[] maximo_sensores = new double[38];
           maximo_sensores[0] = 0.06;
           maximo_sensores[1] = 11.74;
           maximo_sensores[2] = 22.56;
           maximo_sensores[3] = 26.82;
           maximo_sensores[4] = 29.71;
           maximo_sensores[5] = 28.19;
           maximo_sensores[6] = 11.15;
           maximo_sensores[7] = 12.56;
           maximo_sensores[8] = 9.36;
           maximo_sensores[9] = 9.05;
           maximo_sensores[10] = 106.74;
           maximo_sensores[11] = 47.57;
           maximo_sensores[12] = 15.58;
           maximo_sensores[13] = 17.81;
           maximo_sensores[14] = 0.67;
           maximo_sensores[15] = 10017.18;
           maximo_sensores[16] = 46.13;

           maximo_sensores[17] = 91.7;
           maximo_sensores[18] = 74.2;
           maximo_sensores[19] = 70.4;
           maximo_sensores[20] = 99.9;
           maximo_sensores[21] = 88.5;
           maximo_sensores[22] = 77.7;
           maximo_sensores[23] = 87.1;
           maximo_sensores[24] = 62.7;
           maximo_sensores[25] = 72.6;
           maximo_sensores[26] = 55.9;
           maximo_sensores[27] = 80;
           maximo_sensores[28] = 30.1;
           maximo_sensores[29] = 87.6;
           maximo_sensores[30] = 89.3;
           maximo_sensores[31] = 84.9;
           maximo_sensores[32] = 32;
           maximo_sensores[33] = 78.8;

           maximo_sensores[34] = 82.37;
           maximo_sensores[35] = 68.8;
           maximo_sensores[36] = 189.43;
           maximo_sensores[37] = 51.2;
           //StreamWriter sw = File.CreateText("Test_.txt");

           const string direccion_txt = @"Test.txt";
 
           System.IO.StreamWriter escribe_texto = new System.IO.StreamWriter(direccion_txt, true);
                      
           String texto="";
           
           for (int i = 0; i < tabla_entrada.Rows.Count;i++)
           {    texto="";
           if (i + 90 < tabla_entrada.Rows.Count)
           {
               for (int x = 0; x < 38;x++ )
               {    
                   string cadena=tabla_entrada.Rows[i][x].ToString();
                  
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor;
                   Double.TryParse(cadena, out valor);
                  valor = valor /  maximo_sensores[x];
                  cadena = "" + valor;
                  cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   
                    texto = texto + cadena + ",";
                   
                                         
               }

               //escribe salida
               string cadena_final=tabla_entrada.Rows[i + 90][indice_sensor].ToString();
               double valor_final;
               Double.TryParse(cadena_final, out valor_final);
               valor_final = valor_final / maximo_sensores[indice_sensor];
               cadena_final = "" + valor_final;
               cadena_final = cadena_final.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);                  
               texto=texto + " "+cadena_final;
              
               escribe_texto.WriteLine(texto);
           }
           }
           escribe_texto.Close();
       }

       public void crear_entradas_12(DataTable tabla_entrada, int indice_sensor,string nombre)
       {

           double[] maximo_sensores = new double[38];
           maximo_sensores[0] = 0.06;
           maximo_sensores[1] = 11.74;
           maximo_sensores[2] = 22.56;
           maximo_sensores[3] = 26.82;
           maximo_sensores[4] = 29.71;
           maximo_sensores[5] = 28.19;
           maximo_sensores[6] = 11.15;
           maximo_sensores[7] = 12.56;
           maximo_sensores[8] = 9.36;
           maximo_sensores[9] = 9.05;
           maximo_sensores[10] = 106.74;
           maximo_sensores[11] = 47.57;
           maximo_sensores[12] = 15.58;
           maximo_sensores[13] = 17.81;
           maximo_sensores[14] = 0.67;
           maximo_sensores[15] = 10017.18;
           maximo_sensores[16] = 46.13;

           maximo_sensores[17] = 91.7;
           maximo_sensores[18] = 74.2;
           maximo_sensores[19] = 70.4;
           maximo_sensores[20] = 99.9;
           maximo_sensores[21] = 88.5;
           maximo_sensores[22] = 77.7;
           maximo_sensores[23] = 87.1;
           maximo_sensores[24] = 62.7;
           maximo_sensores[25] = 72.6;
           maximo_sensores[26] = 55.9;
           maximo_sensores[27] = 80;
           maximo_sensores[28] = 30.1;
           maximo_sensores[29] = 87.6;
           maximo_sensores[30] = 89.3;
           maximo_sensores[31] = 84.9;
           maximo_sensores[32] = 32;
           maximo_sensores[33] = 78.8;

           maximo_sensores[34] = 82.37;
           maximo_sensores[35] = 68.8;
           maximo_sensores[36] = 189.43;
           maximo_sensores[37] = 51.2;
           //StreamWriter sw = File.CreateText("Test_.txt");

 

            string direccion_txt = @""+nombre+".txt";

           System.IO.StreamWriter escribe_texto = new System.IO.StreamWriter(direccion_txt, true);

           String texto = "";   

           for (int i = 0; i < tabla_entrada.Rows.Count; i++)
           {
               texto = "";
               if (i + 89 < tabla_entrada.Rows.Count)
               {
                  
                       string cadena = tabla_entrada.Rows[i][10].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor;
                       Double.TryParse(cadena, out valor);
                       valor = valor / maximo_sensores[10];
                       cadena = "" + valor;
                       cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena + ",";


                       string cadena1 = tabla_entrada.Rows[i][11].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor1;
                       Double.TryParse(cadena1, out valor1);
                       valor1 = valor1 / maximo_sensores[11];
                       cadena1 = "" + valor1;
                       cadena1 = cadena1.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena1 + ",";



                       string cadena2 = tabla_entrada.Rows[i][12].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor2;
                       Double.TryParse(cadena2, out valor2);
                       valor2 = valor2 / maximo_sensores[12];
                       cadena2 = "" + valor2;
                       cadena2 = cadena2.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena2 + ",";


                       string cadena3 = tabla_entrada.Rows[i][13].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor3;
                       Double.TryParse(cadena3, out valor3);
                       valor3 = valor3 / maximo_sensores[13];
                       cadena3 = "" + valor3;
                       cadena3 = cadena3.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena3 + ",";


                       string cadena4 = tabla_entrada.Rows[i][14].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor4;
                       Double.TryParse(cadena4, out valor4);
                       valor4 = valor4 / maximo_sensores[14];
                       cadena4 = "" + valor4;
                       cadena4 = cadena4.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena4 + ",";


                       string cadena5 = tabla_entrada.Rows[i][26].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor5;
                       Double.TryParse(cadena5, out valor5);
                       valor5 = valor5 / maximo_sensores[26];
                       cadena5 = "" + valor5;
                       cadena5 = cadena5.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena5 + ",";


                       string cadena6 = tabla_entrada.Rows[i][28].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor6;
                       Double.TryParse(cadena6, out valor6);
                       valor6 = valor6 / maximo_sensores[28];
                       cadena6 = "" + valor6;
                       cadena6 = cadena6.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena6 + ",";


                       string cadena7 = tabla_entrada.Rows[i][29].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor7;
                       Double.TryParse(cadena7, out valor7);
                       valor7 = valor7 / maximo_sensores[29];
                       cadena7 = "" + valor7;
                       cadena7 = cadena7.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena7 + ",";


                       string cadena8 = tabla_entrada.Rows[i][30].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor8;
                       Double.TryParse(cadena8, out valor8);
                       valor8 = valor8 / maximo_sensores[30];
                       cadena8 = "" + valor8;
                       cadena8 = cadena8.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena8 + ",";


                       string cadena9 = tabla_entrada.Rows[i][31].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor9;
                       Double.TryParse(cadena9, out valor9);
                       valor9 = valor9 / maximo_sensores[31];
                       cadena9 = "" + valor9;
                       cadena9 = cadena9.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena9 + ",";


                       string cadena10 = tabla_entrada.Rows[i][32].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor10;
                       Double.TryParse(cadena10, out valor10);
                       valor10 = valor10 / maximo_sensores[32];
                       cadena10 = "" + valor10;
                       cadena10 = cadena10.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena10 + ",";


                       string cadena11 = tabla_entrada.Rows[i][33].ToString();
                       //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       double valor11;
                       Double.TryParse(cadena11, out valor11);
                       valor11 = valor11 / maximo_sensores[33];
                       cadena11 = "" + valor11;
                       cadena11 = cadena11.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                       texto = texto + cadena11 + ",";

                   

                   //escribe salida
                   string cadena_final = tabla_entrada.Rows[i + 89][indice_sensor].ToString();
                   double valor_final;
                   Double.TryParse(cadena_final, out valor_final);
                   valor_final = valor_final / maximo_sensores[indice_sensor];
                   cadena_final = "" + valor_final;
                   cadena_final = cadena_final.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + " " + cadena_final;

                   escribe_texto.WriteLine(texto);
               }
           }
           escribe_texto.Close();
       }


       public void crear_entradas_turbo7(DataTable tabla_entrada, int indice_sensor, string nombre)
       {

           double[] maximo_sensores = new double[8];
           maximo_sensores[0] = 18.1;
           maximo_sensores[1] = 14.5;
           maximo_sensores[2] = 22;
           maximo_sensores[3] = 70.995;
           maximo_sensores[4] = 78;
           maximo_sensores[5] = 54.9679;
           maximo_sensores[6] = 1.78461;
           
          
           //StreamWriter sw = File.CreateText("Test_.txt");

           string direccion_txt = @"" + nombre + ".txt";

           System.IO.StreamWriter escribe_texto = new System.IO.StreamWriter(direccion_txt, true);

           String texto = "";

           for (int i = 0; i < tabla_entrada.Rows.Count; i++)
           {
               texto = "";
               if (i + 180 < tabla_entrada.Rows.Count)
               {

                   string cadena = tabla_entrada.Rows[i][0].ToString();
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor;
                   Double.TryParse(cadena, out valor);
                   valor = valor / maximo_sensores[0];
                   cadena = "" + valor;
                   cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + cadena + ",";


                   string cadena1 = tabla_entrada.Rows[i][1].ToString();
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor1;
                   Double.TryParse(cadena1, out valor1);
                   valor1 = valor1 / maximo_sensores[1];
                   cadena1 = "" + valor1;
                   cadena1 = cadena1.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + cadena1 + ",";



                   string cadena2 = tabla_entrada.Rows[i][2].ToString();
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor2;
                   Double.TryParse(cadena2, out valor2);
                   valor2 = valor2 / maximo_sensores[2];
                   cadena2 = "" + valor2;
                   cadena2 = cadena2.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + cadena2 + ",";


                   string cadena3 = tabla_entrada.Rows[i][3].ToString();
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor3;
                   Double.TryParse(cadena3, out valor3);
                   valor3 = valor3 / maximo_sensores[3];
                   cadena3 = "" + valor3;
                   cadena3 = cadena3.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + cadena3 + ",";


                   string cadena4 = tabla_entrada.Rows[i][4].ToString();
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor4;
                   Double.TryParse(cadena4, out valor4);
                   valor4 = valor4 / maximo_sensores[4];
                   cadena4 = "" + valor4;
                   cadena4 = cadena4.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + cadena4 + ",";


                   string cadena5 = tabla_entrada.Rows[i][5].ToString();
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor5;
                   Double.TryParse(cadena5, out valor5);
                   valor5 = valor5 / maximo_sensores[5];
                   cadena5 = "" + valor5;
                   cadena5 = cadena5.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + cadena5 + ",";


                   string cadena6 = tabla_entrada.Rows[i][6].ToString();
                   //cadena = cadena.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   double valor6;
                   Double.TryParse(cadena6, out valor6);
                   valor6 = valor6 / maximo_sensores[6];
                   cadena6 = "" + valor6;
                   cadena6 = cadena6.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + cadena6 + ",";



                  


                   //escribe salida
                   string cadena_final = tabla_entrada.Rows[i + 180][indice_sensor].ToString();
                   double valor_final;
                   Double.TryParse(cadena_final, out valor_final);
                   valor_final = valor_final / maximo_sensores[indice_sensor];
                   cadena_final = "" + valor_final;
                   cadena_final = cadena_final.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, NumberFormatInfo.CurrentInfo.NumberGroupSeparator);
                   texto = texto + " " + cadena_final;

                   escribe_texto.WriteLine(texto);
               }
           }
           escribe_texto.Close();
       }
    }
}
