using SV.Domain.Entities;

namespace SV.Infrastructure.FileExcel
{
    public interface IReadExcel
    {
        List<Student> ReadFromExcel(string filePath, int gradeId);
    }
}
