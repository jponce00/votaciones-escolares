using OfficeOpenXml;
using SV.Domain.Entities;

namespace SV.Infrastructure.FileExcel
{
    public class ReadExcel : IReadExcel
    {
        public List<Student> ReadFromExcel(string filePath, int gradeId)
        {
            List<Student> students = new();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var student = new Student
                    {
                        Name = worksheet.Cells[row, 1].Value.ToString()!,
                        GradeId = gradeId,
                        CreatedYear = DateTime.Now.Year
                    };

                    students.Add(student);
                }
            }

            return students;
        }
    }
}
