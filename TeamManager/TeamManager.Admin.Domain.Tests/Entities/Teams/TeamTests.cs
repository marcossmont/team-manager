using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;
using TeamManager.Admin.Domain.Entities.Teams.Exceptions;

namespace TeamManager.Admin.Domain.Tests.Entities.Teams
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void SuccessWhenCreateTeamWithName()
        {
            var name = "Engineering Team";
            Team team = new Team(name);
            var administrators = team.GetAdministrators();

            Assert.AreEqual(name, team.Name);
            Assert.IsNull(team.Description);
            Assert.IsTrue(team.CreateSharePointSite);
            Assert.IsTrue(team.CreateTeamsChannel);

            Assert.IsNotNull(administrators);
            Assert.AreEqual(0, administrators.Count);
        }

        [TestMethod]
        public void SuccessWhenCreateTeamWithCreateSharePointSiteAndTeamsChannelFalse()
        {
            var teamName = "Engineering Team";
            Team team = new Team(teamName, null, false, false);
            var administrators = team.GetAdministrators();

            Assert.IsFalse(team.CreateSharePointSite);
            Assert.IsFalse(team.CreateTeamsChannel);
        }

        [TestMethod]
        public void SuccessWhenCreateTeamWithDescription()
        {
            var teamName = "Engineering Team";
            var description = "Engineering Team Description";
            Team team = new Team(teamName, description);

            Assert.AreEqual(description, team.Description);
        }

        [TestMethod]
        public void SuccessWhenCreateTeamWithTeamAdministrator()
        {
            var teamName = "Engineering Team";
            Team team = new Team(teamName);

            team.AddAdministrador("John Smith", "jsmith@mail.com");
            var administrators = team.GetAdministrators();

            Assert.AreEqual(1, administrators.Count);
        }

        [TestMethod]
        public void ErrorWhenCreateTeamWithoutName()
        {
            Assert.ThrowsException<TeamNameIsRequiredException>(() => new Team(null));
        }
    }
}
