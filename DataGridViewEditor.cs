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
        public Musteri GetMusteriDataGridView(DataGridView dataGridview)
        {
            int count = dataGridview.SelectedRows.Count;
            //Prompt box

            for (int i = 0; i < count; i++)
            {
                Musteri musteri = new Musteri();
                musteri.Account_Id = Int32.Parse(dataGridview.SelectedRows[i].Cells[0].Value.ToString());
                musteri.Unvan = dataGridview.SelectedRows[i].Cells[1].Value.ToString();
                musteri.Tel = dataGridview.SelectedRows[i].Cells[2].Value.ToString();
                musteri.Adres= dataGridview.SelectedRows[i].Cells[3].Value.ToString();
                musteri.Mail= dataGridview.SelectedRows[i].Cells[4].Value.ToString();
                musteri.UpdateDate =DateTime.Parse( dataGridview.SelectedRows[i].Cells[5].Value.ToString());
                musteri.Change_Log = dataGridview.SelectedRows[i].Cells[6].Value.ToString();
            }
            return null;
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
