using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Domain.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System;

namespace GenerateIdDesignerProblem.Orm.NHibernate.Test.Conventions
{
	[TestClass]
	public class EmployeeTest
	{
		[TestMethod]
		public void New_employee_should_with_CreateAt_today()
		{
			// Arrange
			var fix = new Fixture();
			using (var repo = new Repository<Employee>())
			{
				var employee = fix.Build<Employee>()
						.With(p => p.Name)
						.With(p => p.StartDate)
						.OmitAutoProperties()
						.Create();
				repo.Store(employee);

				// Act
				var employeeDb = repo.Get(p => p.Name == employee.Name);

				// Assert
				Assert.IsNotNull(employeeDb);
				Assert.IsNotNull(employeeDb.CreateAt);
				Assert.AreEqual(DateTime.Now.ToShortDateString(), employeeDb.CreateAt.ToShortDateString());
			}
		}

		[TestMethod]
		public void New_employee_UpdateAt_shouldbe_null()
		{
			// Arrange
			var fix = new Fixture();
			using (var repo = new Repository<Employee>())
			{
				var employee = fix.Build<Employee>()
						.With(p => p.Name)
						.With(p => p.StartDate)
						.OmitAutoProperties()
						.Create();
				repo.Store(employee);

				// Act
				var employeeDb = repo.Get(p => p.Name == employee.Name);

				// Assert
				Assert.IsNotNull(employeeDb);
				Assert.IsNull(employeeDb.UpdateAt);
			}
		}

		[TestMethod]
		public void New_employee_Id_shouldbe_generate()
		{
			// Arrange
			var fix = new Fixture();
			using (var repo = new Repository<Employee>())
			{
				var employee = fix.Build<Employee>()
						.With(p => p.Name)
						.With(p => p.StartDate)
						.OmitAutoProperties()
						.Create();
				repo.Store(employee);

				// Act
				var employeeDb = repo.Get(p => p.Name == employee.Name);

				// Assert
				Assert.IsNotNull(employeeDb);
				Assert.IsTrue(employeeDb.Id > 0);
			}
		}

		[TestMethod]
		public void New_employee_Status_shouldbe_WaitingConfirmation()
		{
			// Arrange
			var fix = new Fixture();
			using (var repo = new Repository<Employee>())
			{
				var employee = fix.Build<Employee>()
						.With(p => p.Name)
						.With(p => p.StartDate)
						.OmitAutoProperties()
						.Create();
				repo.Store(employee);

				// Act
				var employeeDb = repo.Get(p => p.Name == employee.Name);

				// Assert
				Assert.IsNotNull(employeeDb);
				Assert.AreEqual(employeeDb.Status, StatusEmployeeEnum.WaitingConfirmation);
			}
		}
	}
}
