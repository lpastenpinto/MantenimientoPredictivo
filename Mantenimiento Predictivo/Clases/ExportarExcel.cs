using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Mantenimiento_Predictivo.Clases
{
    public class ExportarExcel
    {

        public void exportar(System.Windows.Forms.DataGridView dataGridView1)
        {

            //Excel.Application ExcelApp;
            //Excel.Workbook Workbooks;
            Excel.Application ExcelApp = new Excel.Application();
            //ExcelApp.Columns.ColumnWidth = 1;
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 12;

            dataGridView1.Columns[0].HeaderText.ToString();
            dataGridView1.Columns[1].HeaderText.ToString();
            dataGridView1.Columns[2].HeaderText.ToString();

            ExcelApp.Cells[1, 1] = dataGridView1.Columns[0].HeaderText.ToString();
            ExcelApp.Cells[1, 2] = dataGridView1.Columns[1].HeaderText.ToString();
            ExcelApp.Cells[1, 3] = dataGridView1.Columns[2].HeaderText.ToString();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow Fila = dataGridView1.Rows[i];
                for (int j = 0; j < Fila.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = Fila.Cells[j].Value;
                }
            }
            // ---------- cuadro de dialogo para Guardar
            SaveFileDialog CuadroDialogo = new SaveFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xls";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Guardar";
            CuadroDialogo.InitialDirectory = @"c:\";
            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                CuadroDialogo.Dispose();
                CuadroDialogo = null;
                ExcelApp.Quit();
            }
            else
            {
                MessageBox.Show("No se pudo guardar Datos .. ");
            }



        }




    }
}
