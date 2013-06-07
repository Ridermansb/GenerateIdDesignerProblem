using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Domain.Enum;
using GenerateIdDesignerProblem.Orm;
using System;
using System.Linq;

namespace GenerateIdDesignerProblem.Repository
{
	public class EmployeeRepository : Repository<Employee>, IEmployeeRepository // TODO: I have a dependency with ORM  at this point in Repository<Employee>. How to solve? How to test the GetInactiveEmployees method
	{
		public IQueryable<Employee> GetInactiveEmployees()
		{
			return Query(p => p.Status != StatusEmployeeEnum.Active || p.StartDate < DateTime.Now);
		}
	}
}
