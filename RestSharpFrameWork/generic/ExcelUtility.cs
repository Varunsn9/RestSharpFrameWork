using Bytescout.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.generic
{
/// <summary>
/// ExcelUtility to fetch the data from Excel
/// </summary>
    public class ExcelUtility
    {
        

        public string GetCellValue(string sheetName, int rowNumber, int cellNumber, string filePath)
    {
        // Load the spreadsheet from the specified file path
        using (var document = new Spreadsheet())
        {
            document.LoadFromFile(filePath);

            // Get the specified worksheet by name
            var worksheet = document.Workbook.Worksheets.ByName(sheetName);

            // Get the cell value at the specified row and cell numbers
            var cellValue = worksheet.Cell(rowNumber, cellNumber).Value;

            return cellValue.ToString();
        }
    }

}
}
