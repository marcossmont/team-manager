﻿using System;
using Microsoft.AspNetCore.Mvc;
using TeamManager.Admin.Queries.Contracts.Teams;
using TeamManager.Admin.UseCases.Contracts.Teams.Commands;

namespace TeamManager.Admin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ICreateCommandHandler _createCommandHandler;
        private readonly IGetAllQuery _getAllQuery;
        private readonly IGetQuery _getQuery;

        public TeamsController(ICreateCommandHandler createCommandHandler, IGetAllQuery getAllQuery, IGetQuery getQuery)
        {
            _createCommandHandler = createCommandHandler ?? throw new ArgumentNullException(nameof(createCommandHandler));
            _getAllQuery = getAllQuery ?? throw new ArgumentNullException(nameof(getAllQuery));
            _getQuery = getQuery ?? throw new ArgumentNullException(nameof(getQuery));
        }

        [HttpGet]
        public GetAllQueryResult GetAll()
        {
            var result = _getAllQuery.Query();
            return result;
        }

        [HttpGet]
        [Route("all")]
        public GetQueryResult Get(Guid id)
        {
            var result = _getQuery.Query(id);
            return result;
        }

        [HttpPost]
        public CreateCommandResult Create(CreateCommand createCommand)
        {
            var result = _createCommandHandler.Execute(createCommand);
            return result;
        }


    }
}