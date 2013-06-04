using System;

namespace GenerateIdDesignerProblem.Domain
{
	public interface IAuditable
	{
		DateTime CreateAt { get; }
		DateTime? UpdateAt { get; }
	}
}
