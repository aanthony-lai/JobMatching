using JobMatching.Application.Interfaces.Services;
using JobMatching.Domain.Entities.Language;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        
        public LanguagesController(ILanguageService languageService) 
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<Language>> GetAsync()
        {
            return Ok(await _languageService.GetAsync());
        }
    }
}
