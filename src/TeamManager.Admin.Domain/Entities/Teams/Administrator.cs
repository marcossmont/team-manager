using System;
using TeamManager.Admin.Domain.Entities.Teams.Exceptions;
using TeamManager.Admin.Domain.ValueObjects;

namespace TeamManager.Admin.Domain.Entities.Teams
{
    public class Administrator
    {
        public Administrator(string name, Email email)
        {
            if (string.IsNullOrEmpty(name))
                throw new AdministratorNameIsRequiredException($"{nameof(name)} is required");

            Name = name;
            Email = email;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Email Email { get; }
    }
}