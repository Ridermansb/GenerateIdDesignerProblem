using GenerateIdDesignerProblem.Domain.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GenerateIdDesignerProblem.Domain
{
	public class Employee : IEntity, IAuditable
    {
		[Required]
		public virtual string Name { get; set; }
		public virtual DateTime StartDate { get; set; }
		[DefaultValue(2)]
		public virtual StatusEmployeeEnum Status { get; set; }

		#region Implements IEntity
		public virtual int Id { get; protected set; }
		#endregion

		#region Implements IAuditable
		public virtual DateTime CreateAt { get; protected set; }
		public virtual DateTime? UpdateAt { get; protected set; }
		#endregion

		public Employee()
		{
			Status = StatusEmployeeEnum.WaitingConfirmation;
			// Can to set CreateAt here smoothly. But and UpdateAt and the Id ?
			CreateAt = DateTime.Now; // TODO: This way I do not need the database Default('getDate()')
		}
    }
}
