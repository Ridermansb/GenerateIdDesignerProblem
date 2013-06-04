using GenerateIdDesignerProblem.Domain;
using System;
using System.Linq.Expressions;

namespace GenerateIdDesignerProblem.Test
{
	internal static class Extensions
	{
		public static TEntity SetValue<TEntity, TProperty>(this TEntity entity, Expression<Func<TEntity, TProperty>> property, TProperty value)
		{
			var expression = (MemberExpression)property.Body;
			var name = expression.Member.Name;
			entity.GetType().GetProperty(name).SetValue(entity, value);
			return entity;
		}
	}
}
