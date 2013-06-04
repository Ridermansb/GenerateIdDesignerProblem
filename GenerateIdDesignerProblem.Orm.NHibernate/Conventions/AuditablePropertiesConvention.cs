using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using GenerateIdDesignerProblem.Domain;
using System;
using System.Linq;

namespace GenerateIdDesignerProblem.Orm.NHibernate.Conventions
{
	public class CreatedAtPropertyConvention : IPropertyConvention, IPropertyConventionAcceptance
	{
		public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
		{
			criteria
				.Expect(x => x.EntityType.GetInterfaces().Any(t => t == typeof(IAuditable)))
				.Expect(x => x.Property.Name == "CreateAt" && x.Property.PropertyType == typeof(DateTime));
		}
		public void Apply(IPropertyInstance instance)
		{
			instance.ReadOnly();
			instance.Generated.Insert();
			instance.Default("getDate()");
		}
	}

	public class UpdateAtPropertyConvention : IPropertyConvention, IPropertyConventionAcceptance
	{
		public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
		{
			criteria
				.Expect(x => x.EntityType.GetInterfaces().Any(t => t == typeof(IAuditable)))
				.Expect(x => x.Property.Name == "UpdateAt" && x.Property.PropertyType == typeof(DateTime?));
		}
		public void Apply(IPropertyInstance instance)
		{
			instance.ReadOnly();
			instance.Not.Generated.Insert();
		}
	}
}
