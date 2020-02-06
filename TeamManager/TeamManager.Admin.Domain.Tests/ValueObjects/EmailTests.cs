using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TeamManager.Admin.Domain.ValueObjects;
using TeamManager.Admin.Domain.ValueObjects.Exceptions;

namespace TeamManager.Admin.Domain.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void SuccessWhenCreateEmail()
        {
            var address = "jsmith@mail.com";
            Email email = new Email(address);

            Assert.AreEqual(address, email.Address);
        }

        [TestMethod]
        public void ErrorWhenCreateEmailWithoutAdrress()
        {
            Assert.ThrowsException<EmailAddressIsRequiredException>(() => new Email(null));
        }

        [TestMethod]
        public void ErrorWhenCreateEmailWithInvalidAdrress()
        {
            Assert.ThrowsException<InvalidEmailAdrressException>(() => new Email("jsmith"));
            Assert.ThrowsException<InvalidEmailAdrressException>(() => new Email("jsmith@mail"));
            Assert.ThrowsException<InvalidEmailAdrressException>(() => new Email("jsmith@mail."));
            Assert.ThrowsException<InvalidEmailAdrressException>(() => new Email("@mail.com"));
        }
    }
}
