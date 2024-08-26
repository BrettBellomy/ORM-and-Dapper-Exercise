using Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class DepartmentRepo : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DepartmentRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@newDepName)", new { newDepName = newDepartmentName });
        }
    }
}