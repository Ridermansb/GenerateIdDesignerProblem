using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Test.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System;

namespace GenerateIdDesignerProblem.Test
{
	[TestClass]
	public class RepositoryFakeTest
	{
		[TestMethod]
		public void New_employee_Id_shouldbe_generate()
		{
			// Arrange
			var fix = new Fixture();
			var repo = new Repository<Employee>();
			var employee = fix.Build<Employee>()
					.With(p => p.Name)
					.With(p => p.StartDate)
					.OmitAutoProperties()
					.Create();
			
			// Act
			repo.Store(employee);
			var employeeDb = repo.Get(p => p.Name == employee.Name);

			// Assert
			Assert.IsNotNull(employeeDb);
			Assert.IsTrue(employeeDb.Id > 0);
		}

		[TestMethod]
		public void New_employee_UpdateAt_shouldbe_null()
		{
			// Arrange
			var fix = new Fixture();
			var repo = new Repository<Employee>();
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

		[TestMethod]
		public void New_employee_should_with_CreateAt_today()
		{
			// Arrange
			var fix = new Fixture();
			var repo = new Repository<Employee>();
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
}
