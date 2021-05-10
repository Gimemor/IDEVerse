using System.Threading.Tasks;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace IDEVerse.Controllers
{
    [Route("api/versetheft")]
    public class VerseTheftController : BaseApiContoller
    {
        private readonly IVerseTheftService _verseTheftService;

        public VerseTheftController(IVerseTheftService verseTheftService)
        {
            _verseTheftService = verseTheftService;
        }
        
        
        // GET
        [HttpGet("{name}")]
        public async Task<IActionResult> Index(string name)
        {
            var data = await _verseTheftService.GetRhymes(name);
            return Ok(data);
        }
    }
}