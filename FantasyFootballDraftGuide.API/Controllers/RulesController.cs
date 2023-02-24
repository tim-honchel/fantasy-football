using FantasyFootballDraftGuide.Data.Entities;
using FantasyFootballDraftGuide.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FantasyFootballDraftGuide.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly IRulesRepository _repository;
        public RulesController(IRulesRepository repository) 
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult SubmitLeagueRules(Rules rules)
        {
            if (_repository.ValidateRules(rules)) 
            { 
                _repository.SaveRules(rules);
                return new OkResult();
            }
            return new BadRequestResult();
        }
    }
}
