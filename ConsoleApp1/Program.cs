// See https://aka.ms/new-console-template for more information
using Aspose.Cells;
using System.IO;

Console.WriteLine("Hello, World!");

// Загрузить файл Excel
Workbook wb = new Workbook(@"C:\Users\Ahtyamov\Desktop\Лист Microsoft Excel (3).xlsx");

// Получить все рабочие листы
WorksheetCollection collection = wb.Worksheets;

// Перебрать все рабочие листы
for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
{

    // Получить рабочий лист, используя его индекс
    Worksheet worksheet = collection[worksheetIndex];

    // Печать имени рабочего листа
    Console.WriteLine("Worksheet: " + worksheet.Name);

    // Получить количество строк и столбцов
    int rows = worksheet.Cells.MaxDataRow;
    int cols = worksheet.Cells.MaxDataColumn;

    // Цикл по строкам
    for (int i = 0; i < rows; i++)
    {

        // Перебрать каждый столбец в выбранной строке
        for (int j = 0; j < cols; j++)
        {
            // Значение ячейки Pring
            Console.Write(worksheet.Cells[i, j].Value + " | ");
        }
        // Распечатать разрыв строки
        Console.WriteLine(" ");
    }
}