using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Search.Queries.Contracts.Teams;

namespace TeamManager.Search.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IGetTeamsQuery _getTeamsQuery;

        public TeamsController(IGetTeamsQuery getTeamsQuery)
        {
            _getTeamsQuery = getTeamsQuery ?? throw new ArgumentNullException(nameof(getTeamsQuery));
        }

        [HttpGet]
        public IActionResult Get(GetTeamsQueryParameters parameters)
        {
            var result = _getTeamsQuery.Query(parameters);
            if (result.Teams == null || result.Teams.Count() == 0)
                return NotFound();
            
            return Ok();
        }
    }
}