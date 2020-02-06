using TeamManager.Admin.Domain.ValueObjects.Exceptions;
using TeamManager.Core.RegexValidator;

namespace TeamManager.Admin.Domain.ValueObjects
{
    public class Email
    {
        private const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public string Address { get; }

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new EmailAddressIsRequiredException($"{nameof(address)} is required");

            if (!RegexValidator.Match(EmailRegex, address))
                throw new InvalidEmailAdrressException($"invalid {nameof(address)}");

            Address = address;
        }
    }
}