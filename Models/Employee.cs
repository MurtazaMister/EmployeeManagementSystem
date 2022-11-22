namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department department { get; set; }
        public int DepartmentId { get; set; }
    }
}
