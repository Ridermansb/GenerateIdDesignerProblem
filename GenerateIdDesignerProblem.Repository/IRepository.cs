using GenerateIdDesignerProblem.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GenerateIdDesignerProblem.Repository
{
    public interface IRepository<T>
		where T: class, IEntity
    {
		void Delete(T obj);
		void Store(T obj);
		void Commit();

		IQueryable<T> All();
		T Get(Expression<Func<T, bool>> expression);
		T Get(int id);
		object Get(Type entity, int id);
		IQueryable<T> Query(Expression<Func<T, bool>> expression);
    }
}
