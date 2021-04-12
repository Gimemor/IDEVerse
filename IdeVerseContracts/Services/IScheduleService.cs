using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;

namespace IdeVerseContracts.Services
{
	public interface IScheduleService
	{
        public Task<IList<ScheduleEntryDto>> GetScheduleEntries();
        public Task<ScheduleEntryDto> GetScheduleEntry(Guid id);
        public Task PutScheduleEntry(Guid id, ScheduleEntryDto scheduleEntry);
        public Task PostScheduleEntry(ScheduleEntryDto scheduleEntry);
        public Task<ScheduleEntryDto> DeleteScheduleEntry(Guid id);
    }
}
