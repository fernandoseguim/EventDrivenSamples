using System;

namespace CustomersService.Domain.ValueObjects
{
    public struct Name
    {
        public Name(string firstName, string surname)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        public string FirstName { get; }
        public string Surname { get; }
    }
}