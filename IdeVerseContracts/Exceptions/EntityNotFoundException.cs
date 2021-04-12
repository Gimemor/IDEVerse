
using System;

namespace IdeVerseContracts.Exceptions
{
	public class EntityNotFoundException : ApplicationException
	{
		public EntityNotFoundException(Guid id) : base($"Сущность с Id {id} не найлена")
		{}

		public EntityNotFoundException(Guid id, Type type) : base($"Сущность типа {type} с Id {id} не найлена")
		{}
	}
}
