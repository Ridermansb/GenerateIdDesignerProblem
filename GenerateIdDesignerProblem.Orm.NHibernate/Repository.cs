using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Framework;
using GenerateIdDesignerProblem.Orm.NHibernate;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace GenerateIdDesignerProblem.Orm
{
	// The transaction is coupled to the repository only to simplify the code. 
	// I know it is not a good abordage. In my projects, I use UnitOfWork
	public class Repository<T> : IRepository<T>, IDisposable
		where T: class, IEntity
	{
		private readonly ISession _session;
		private readonly ITransaction _transaction;
		public Repository()
		{
			_session = StaticSessionManager.OpenSession();
			_transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		public void Delete(T obj)
		{
			_session.Delete(obj);
		}

		public void Store(T obj)
		{
			if (obj.Id <= 0)
				_session.Save(obj);
			else
				_session.Update(obj);
		}

		public IQueryable<T> All()
		{
			return _session.Query<T>();
		}

		public object Get(Type entity, int id)
		{
			return _session.Get(entity, id);
		}

		public T Get(Expression<Func<T, bool>> expression)
		{
			return Query(expression).Single();
		}

		public T Get(int id)
		{
			return _session.Get<T>(id);
		}

		public IQueryable<T> Query(Expression<Func<T, bool>> expression)
		{
			return All().Where(expression).AsQueryable();
		}

		public void Dispose()
		{
			if (_session.IsOpen)
				_session.Close();
		}

		public void Commit()
		{
			_transaction.Commit();
		}
	}
}
