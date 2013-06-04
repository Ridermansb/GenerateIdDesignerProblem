using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Domain.Enum;
using Ploeh.AutoFixture;

namespace GenerateIdDesignerProblem.Test
{
	[TestClass]
	public class EmployeeTest : EntityTest<Employee>
	{
		[TestMethod]
		public void Initial_status_of_the_employee_shold_be_WaitingConfirmation()
		{
			// Arrange
			var emp = new Employee();

			// Assert
			Assert.AreEqual(StatusEmployeeEnum.WaitingConfirmation, emp.Status);
		}

		[TestMethod]
		public void New_employee_should_be_UpdateAt_date_null_in_database()
		{
			// Arrange
			var fix = new Fixture();
			var employee = fix.Build<Employee>()
					.With(p => p.Name)
					.With(p => p.StartDate)
					.OmitAutoProperties()
					.Create();
			Repository.Store(employee);
			
			// Act
			var employeeDb = Repository.Get(p => p.Name == employee.Name);

			// Assert
			Assert.IsNotNull(employeeDb);
			Assert.IsNull(employeeDb.UpdateAt);
		}
	}
}