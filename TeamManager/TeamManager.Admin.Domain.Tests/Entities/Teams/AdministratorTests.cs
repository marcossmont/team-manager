using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.Entities.Teams;
using TeamManager.Admin.Domain.Entities.Teams.Exceptions;

namespace TeamManager.Admin.Domain.Tests.Entities.Teams
{
    [TestClass]
    public class AdministratorTests
    {
        [TestMethod]
        public void SuccessWhenCreateAdministratorWithNameAndEmail()
        {
            var name = "John Smith";
            var email = "jsmith@mail.com";

            Administrator administrator = new Administrator(name, email);

            Assert.AreEqual(name, administrator.Name);
            Assert.IsNotNull(administrator.Email);
        }

        [TestMethod]
        public void ErrorWhenCreateAdministratorWhitoutName()
        {
            var email = "jsmith@mail.com";

            Assert.ThrowsException<AdministratorNameIsRequiredException>(() => new Administrator(null, email));
        }
    }
}
