using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class ExcelEditor
    {
        public ExcelEditor(string filePath)
        {
            _filePath = filePath;
        }


        
        private static DataSet ds;
        public string sheetName;
        private string _filePath; 
        public void ReadFile(bool UseHeaderRow)
        {
            try
            {
                var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                var sw = new Stopwatch();
                sw.Start();

                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

                var openTiming = sw.ElapsedMilliseconds;
                // reader.IsFirstRowAsColumnNames = firstRowNamesCheckBox.Checked;
                ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    UseColumnDataType = false,
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = UseHeaderRow
                    }
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public List<string> GetTablenames()
        {
            var tableList = new List<string>();
            foreach (var table in ds.Tables)
            {
                tableList.Add(table.ToString());
            }

            return tableList;
        }
        public List<object> GetValues()
        {
            List<object> list = new List<object>();
            foreach (DataRow row in ds.Tables[sheetName].Rows)
            {
                foreach (var value in row.ItemArray)
                {
                    list.Add(value);
                }
            }
            return list;
        }
        
        public void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
            }
        }
    }
}
