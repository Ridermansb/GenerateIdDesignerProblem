using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using System;
using System.ComponentModel.DataAnnotations;

namespace GenerateIdDesignerProblem.Orm.NHibernate.Conventions
{
	public class NullablesConvention : IPropertyConvention, IPropertyConventionAcceptance, IReferenceConvention, IReferenceConventionAcceptance
	{
		public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
		{
			criteria.Expect(p => p.Nullable, Is.Not.Set);
		}

		public void Apply(IPropertyInstance instance)
		{
			if (instance.Property.MemberInfo.IsDefined(typeof(RequiredAttribute), false))
				instance.Not.Nullable();
			else if (Nullable.GetUnderlyingType(instance.Property.PropertyType) != null || instance.Property.PropertyType == typeof(string))
				instance.Nullable();
			else
				instance.Not.Nullable();
		}

		public void Accept(IAcceptanceCriteria<IManyToOneInspector> criteria)
		{
			criteria.Expect(p => p.Nullable, Is.Not.Set);
		}

		public void Apply(IManyToOneInstance instance)
		{
			if (instance.Property.MemberInfo.IsDefined(typeof(RequiredAttribute), false))
				instance.Not.Nullable();
			else
				instance.Nullable();
		}
	}
}
