using System.Threading.Tasks;

namespace IdeVerseContracts.Services
{
    public interface IVerseTheftService
    {
        public Task<string[]> GetRhymes(string originalLine, int? stressPosition = null);
    }
}