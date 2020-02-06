using System.Collections.Generic;

namespace TeamManager.Admin.UseCases.Contracts.Teams.Commands
{
    public class CreateCommand
    {
        public CreateCommand()
        {
            Administrators = new List<Administrator>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool CreateSharePointSite { get; set; }
        public bool CreateTeamsChannel { get; set; }

        public IEnumerable<Administrator> Administrators { get; set; }

        public class Administrator
        {
            public string Name { get; set; }
            public string EmailAddress { get; set; }
        }
    }
}