namespace Gn.Domain.Entities
{
    public class Cafe
    {
        public required string Name { get; set; }
        public required List<Employee> Employees { get; set; }
        public void AddEmploye(Employee e) => Employees.Add(e);

        public IEnumerator<Employee> GetEnumerator()
        {
            return Employees.GetEnumerator();
        }

        public IEnumerable<Employee> GetEmployeesIterator()
        {
            foreach (var employee in Employees)
            {
                yield return employee;
            }
        }
    }
}
