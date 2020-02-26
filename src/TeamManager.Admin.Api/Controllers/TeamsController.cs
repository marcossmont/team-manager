using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Admin.Queries.Contracts.Teams;
using TeamManager.Admin.UseCases.Contracts.Teams.Commands;

namespace TeamManager.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ICreateCommandHandler _createCommandHandler;
        private readonly IGetAllTeamsQuery _getAllQuery;
        private readonly IGetTeamQuery _getQuery;

        public TeamsController(ICreateCommandHandler createCommandHandler, IGetAllTeamsQuery getAllQuery, IGetTeamQuery getQuery)
        {
            _createCommandHandler = createCommandHandler ?? throw new ArgumentNullException(nameof(createCommandHandler));
            _getAllQuery = getAllQuery ?? throw new ArgumentNullException(nameof(getAllQuery));
            _getQuery = getQuery ?? throw new ArgumentNullException(nameof(getQuery));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _getAllQuery.Query();
            if (result.Teams == null || result.Teams.Count() == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _getQuery.Query(id);
            if (result.Team == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateCommand createCommand)
        {
            var result = _createCommandHandler.Execute(createCommand);
            return Created($"api/teams/{result.Id}", result);
        }
    }
}
