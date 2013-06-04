using FluentNHibernate.Automapping;
using GenerateIdDesignerProblem.Domain;
using System;
using System.Linq;

namespace GenerateIdDesignerProblem.Orm.NHibernate
{
	public class AutomappingConfiguration : DefaultAutomappingConfiguration
	{
		public override bool ShouldMap(Type type)
		{
			return type.GetInterfaces().Any(y => y == typeof(IEntity));
		}
	}
}
