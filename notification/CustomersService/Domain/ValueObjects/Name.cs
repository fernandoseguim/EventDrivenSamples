using System;

namespace CustomersService.Domain.ValueObjects
{
    public struct Name : IEquatable<Name>
    {
        public Name(string firstName, string surname)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        public string FirstName { get; }
        public string Surname { get; }

        public bool Equals(Name other) => string.Equals(FirstName, other.FirstName) && string.Equals(Surname, other.Surname);

        public override bool Equals(object obj) => obj is Name other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);
            }
        }

        public override string ToString() => $"{FirstName} {Surname}";
    }
}