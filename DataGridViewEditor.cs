using MetroFramework.Controls;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class DataGridViewEditor
    {
        public void FillDataGridViewColumns(DataGridView dataGridview, List<string> columnsName,List<string> columnsHeader)
        {
            //dataGridview.ColumnCount = columnsHeader.Count;
            for (int i = 0; i < columnsHeader.Count; i++)
            {
                dataGridview.Columns.Add(columnsName[i], columnsHeader[i]);
            }
        }
        public void GettingSelected<T>(MetroGrid metroGrid,int columnNo,T value)
        {
            Type typeT = typeof(T);
            if(typeT== typeof(int))
            {
                for(int i = 0; i < metroGrid.RowCount; i++)
                {
                    if (Convert.ToInt32(metroGrid.Rows[i].Cells[columnNo].Value) == Convert.ToInt32(value))
                    {
                        metroGrid.Rows[i].Selected = true;
                    }
                    
                }
            }else if(typeT == typeof(string))
            {
                for (int i = 0; i < metroGrid.RowCount; i++)
                {
                    if (Convert.ToString(metroGrid.Rows[i].Cells[columnNo].Value) == Convert.ToString(value))
                    {
                        metroGrid.Rows[i].Selected = true;
                    }

                }
            }else if(typeT == typeof(DateTime))
            {
                for (int i = 0; i < metroGrid.RowCount; i++)
                {
                    if (Convert.ToDateTime(metroGrid.Rows[i].Cells[columnNo].Value) == Convert.ToDateTime(value))
                    {
                        metroGrid.Rows[i].Selected = true;
                    }
                }
            }
        }
    }
}
