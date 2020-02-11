using System;
using System.Collections.Generic;
using TeamManager.Admin.Domain.Entities.Teams.Exceptions;
using TeamManager.Admin.Domain.ValueObjects;

namespace TeamManager.Admin.Domain.Entities.Teams
{
    public class Team
    {
        public Team(string name, string description = null, bool createSharePointSite = true, bool createTeamsChannel = true)
        {
            administrators = new List<Administrator>();

            if (string.IsNullOrEmpty(name))
                throw new TeamNameIsRequiredException($"{nameof(name)} is required");

            Name = name;
            Description = description;
            CreateSharePointSite = createSharePointSite;
            CreateTeamsChannel = createTeamsChannel;

        }

        public string Name { get; }
        public string Description { get; }
        public bool CreateSharePointSite { get; }
        public bool CreateTeamsChannel { get; }
        public Guid Id { get; }

        private IList<Administrator> administrators;

        public IReadOnlyList<Administrator> GetAdministrators()
        {
            return new List<Administrator>(administrators);
        }

        public void AddAdministrador(string name, string emailAddress)
        {
            administrators.Add(new Administrator(name, emailAddress));
        }
    }
}
