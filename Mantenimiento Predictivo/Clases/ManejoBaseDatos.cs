using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mantenimiento_Predictivo.Clases
{
    public class ManejoBaseDatos
    {
        //static string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Mantenimiento Predictivo\BaseDatos.mdf;Integrated Security=True";
        static string ConnectionString = @"Data Source=(LocalDB)\v11.0;Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\BaseDatos.mdf;Integrated Security=True;Connect Timeout=30";

       public static void Insertar_Fallas(DateTime fecha,string nombre_falla,
            int id, string set_sensores)
        {
            
            string sel;
            
             sel = "INSERT INTO dbo.Historial_Fallas (Fecha, Nombre_Falla, Id_Maquina,Set_Sensores) " +
                 "VALUES " + "(@Fecha, @Nombre_Falla, @Id_Maquina,@Set_Sensores) " ;
                 

             using (SqlConnection con = new SqlConnection(ConnectionString))
             {
                 SqlCommand cmd = new SqlCommand(sel, con);
                 cmd.Parameters.AddWithValue("@Fecha", fecha);
                 cmd.Parameters.AddWithValue("@Nombre_Falla", nombre_falla);
                 cmd.Parameters.AddWithValue("@Id_Maquina", id);
                 cmd.Parameters.AddWithValue("@Set_Sensores", set_sensores);                     
                 con.Open();
                 cmd.ExecuteNonQuery();
                 //Convert.ToInt32(cmd.ExecuteScalar());
                 con.Close();
                
             }
            /*SqlConnection con = new SqlConnection(ConnectionString);
            sel = "INSERT INTO Historial_Fallas (Fecha, Nombre_Falla, Id_Maquina,Set_Sensores) Values (" + fecha + ",'" + nombre_falla + "'," + id + ",'" + set_sensores + "')";

        SqlCommand myCommand = new SqlCommand(sel, con);

 

        //Ejecucion del comando en el servidor de BD

        myCommand.ExecuteNonQuery();*/

        }
        
        
        public static void AlmacenarFallas(string nombre_tabla, DataTable Data_t)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);     
            try
            {
                conn.Open();
                SqlBulkCopy CopiaDatos = new SqlBulkCopy(conn);
                // CopiaDatos.DestinationTableName = "dbo.Vibracion_Compresor";
                CopiaDatos.DestinationTableName = nombre_tabla;
                CopiaDatos.WriteToServer(Data_t);
                //MessageBox.Show("Datos Almacenados Exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }    
        public static void AlmacenarDatos(string nombre_tabla, DataTable Data_t)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            
            
             int NumeroColumna = Data_t.Columns.Count;
             for (int j = 3; j < NumeroColumna; j++)
             {
                 Data_t.Columns.Remove(Data_t.Columns[j]);
                 NumeroColumna = Data_t.Columns.Count;
             }

             try
             {
                 conn.Open();
                 SqlBulkCopy CopiaDatos = new SqlBulkCopy(conn);
                // CopiaDatos.DestinationTableName = "dbo.Vibracion_Compresor";
                  CopiaDatos.DestinationTableName = nombre_tabla; 
                 CopiaDatos.WriteToServer(Data_t);
                 //MessageBox.Show("Datos Almacenados Exitosamente");
             }
             catch (Exception e)
             {
                 MessageBox.Show("ERROR: " + e.Message );
             }
             finally
             {
                 conn.Close();
             }
        }

       

        public static DateTime ReturnFecha(String ConsultaSQL)
        {
            DateTime Fecha = new DateTime();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString);

            try
            {
                conn.Open();
                SqlCommand Consulta = new SqlCommand(ConsultaSQL, conn);
                SqlDataReader DataReader = Consulta.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                        Fecha = DataReader.GetDateTime(0);
                }
                else
                    Console.WriteLine("No rows returned.");

            }

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }

            finally
            {
                conn.Close();
            }
            return Fecha;
        }

        public static DataTable GetDataTable(String ConsultaSQL)
        {
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                SqlCommand Consulta = new SqlCommand(ConsultaSQL, conn);
                SqlDataReader Lector = Consulta.ExecuteReader();
                dt.Load(Lector);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source"+ex);
                
            }

            finally
            {
                conn.Close();    
            }
            return dt;
        }

        
    }
}
