using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Framework;
using System.Linq;

namespace GenerateIdDesignerProblem.Repository
{
	public interface IEmployeeRepository : IRepository<Employee>
	{
		IQueryable<Employee> GetInactiveEmployees();
	}
}
