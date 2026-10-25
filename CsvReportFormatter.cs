namespace MojProgram
{
    public class CsvReportFormatter : IReportFormatter
    {
        public string Format(Employee employee)
        {
            return $"{employee.Id},{employee.FirstName},{employee.LastName},{employee.Position},{employee.Salary}"; 
        }
    }
}