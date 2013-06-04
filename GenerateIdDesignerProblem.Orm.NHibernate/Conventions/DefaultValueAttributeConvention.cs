using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System.ComponentModel;

namespace GenerateIdDesignerProblem.Orm.NHibernate.Conventions
{
	public class DefaultValueAttributeConvention : AttributePropertyConvention<DefaultValueAttribute>
	{
		protected override void Apply(DefaultValueAttribute attribute, IPropertyInstance instance)
		{
			instance.Default(attribute.Value.ToString());
		}
	}
}
