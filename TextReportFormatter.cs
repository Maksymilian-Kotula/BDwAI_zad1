namespace MojProgram
{
    public class TextReportFormatter : IReportFormatter
    {
        public string Format(Employee employee)
        {
            return $"{employee.FirstName} {employee.LastName} | {employee.Position} | {employee.Salary} zł"; 
        }
    }
}