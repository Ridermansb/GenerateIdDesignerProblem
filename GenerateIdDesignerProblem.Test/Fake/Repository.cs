﻿using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GenerateIdDesignerProblem.Test.Fake
{
	public class Repository<T> : IRepository<T>
		where T : class, IEntity
	{
		private readonly IDictionary<int, T> _context = new Dictionary<int, T>();

		public void Delete(T obj)
		{
			_context.Remove(obj.Id);
		}

		public void Store(T obj)
		{
			if (obj.Id > 0)
			{
				_context[obj.Id] = obj;
				if (obj is IAuditable) // TODO: Not the best designer, How to improve it?
				{
					var objAuditable = (IAuditable)obj;
					objAuditable.SetValue(p => p.UpdateAt, DateTime.Now);
				}
			}
			else
			{
				var generateId = _context.Values.Any() ? _context.Values.Max(p => p.Id) + 1 : 1;

				if (obj is IAuditable) // TODO: Not the best designer, How to improve it?
				{
					var objAuditable = (IAuditable)obj;
					objAuditable.SetValue(p => p.CreateAt, DateTime.Now);
				}


				// HACK: The Id is generated by the database; The three options were found to set an Id protected.

				// Setting the Id with reflection
				obj.SetValue(p => p.Id, generateId);
				_context.Add(generateId, obj);

				/*
				// Setting the Id with Mock
				var stub = Mock.Get<T>(obj);
				stub.Setup(s => s.Id).Returns(generateId);
				_context.Add(generateId, stub.Object);

				// Setting the Id with property
				 obj.Id = generateId;
				_context.Add(generateId, obj);
				 */
			}
		}

		public IQueryable<T> All()
		{
			return _context.Values.AsQueryable();
		}

		public object Get(Type entity, int id)
		{
			throw new NotImplementedException();
		}

		public T Get(Expression<Func<T, bool>> expression)
		{
			return Query(expression).SingleOrDefault();
		}

		public T Get(int id)
		{
			T obj = null;
			_context.TryGetValue(id, out obj);
			return obj;
		}

		public IQueryable<T> Query(Expression<Func<T, bool>> expression)
		{
			return All().Where(expression).AsQueryable();
		}

		public void Commit()
		{
			throw new NotSupportedException();
		}
	}
}
