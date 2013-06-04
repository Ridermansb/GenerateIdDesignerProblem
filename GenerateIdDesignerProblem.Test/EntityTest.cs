using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Test.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenerateIdDesignerProblem.Test
{
	[TestClass]
	public abstract class EntityTest<T>
		where T: class, IEntity
	{
		public Repository<T> Repository { get; private set; }

		[TestInitialize]
		public void SetUp()
		{
			Repository = new Repository<T>();
			FillInitialData();
		}

		protected virtual void FillInitialData()
		{

		}
	}
}
