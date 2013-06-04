using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GenerateIdDesignerProblem.Domain;
using GenerateIdDesignerProblem.Orm.NHibernate.Conventions;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;

namespace GenerateIdDesignerProblem.Orm.NHibernate
{
	internal class StaticSessionManager
	{
		public static readonly ISessionFactory SessionFactory;

		static StaticSessionManager()
		{
			try
			{
				if (SessionFactory != null)
					throw new ApplicationException("Trying to init SessionFactory twice!");

				var mapConfig = new AutomappingConfiguration();
				var _configuration = Fluently.Configure()
						.Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("Data")).ShowSql())
						.Mappings(m =>
						{
							m.AutoMappings.Add(
								AutoMap.AssemblyOf<Employee>(mapConfig)
									.UseOverridesFromAssemblyOf<EnumConvention>()
									.Conventions.AddFromAssemblyOf<EnumConvention>()
							);
						})
						.ExposeConfiguration((cnf) => new SchemaExport(cnf).Execute(true, true, false)) // HACK: In GenerateIdDesignerProblem.Orm.NHibernate.Test project, okay generate the database, but it is a good approach to put this code in my GenerateIdDesignerProblem.Orm.NHibernate?
						.BuildConfiguration();

				StaticSessionManager.SessionFactory = _configuration.BuildSessionFactory();
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex);
				throw new ApplicationException("NHibernate initialization failed", ex);
			}
		}

		public static ISession OpenSession()
		{
			return StaticSessionManager.SessionFactory.OpenSession();
		}
	}
}
