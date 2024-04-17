using Aspose.Cells;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDiagram
{
    internal class FileService
    {
        public List<MyPropery> GetMyProperies(string  path)
        {

            List<MyPropery> myProperies = new List<MyPropery>();

            // Загрузить файл Excel
            Workbook wb = new Workbook(path);

            // Получить все рабочие листы
            WorksheetCollection collection = wb.Worksheets;

           
                // Получить рабочий лист, используя его индекс
                Worksheet worksheet = collection[0];

                // Печать имени рабочего листа
              

                // Получить количество строк и столбцов
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;


            for (int i = 0; i < rows; i++)
            {



                for (int j = 0; j < cols; j++)
                {
                    if (worksheet.Cells[0, j].Value != null)
                    {
                        MyPropery myPropery = new MyPropery();
                        myPropery.Name = worksheet.Cells[i, j].Value.ToString();
                        try
                        {
                            myPropery.Value = Convert.ToDouble(worksheet.Cells[i+1, j].Value);
                            myPropery.Color = "Без цвета";
                            myPropery.Id = j + 1;
                            myProperies.Add(myPropery);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
                  
            
            return myProperies;
        }
    }
}
