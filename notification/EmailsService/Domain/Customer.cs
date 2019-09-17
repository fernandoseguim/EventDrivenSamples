using System;

namespace EmailsService.Domain
{
    public struct Customer : IEquatable<Customer>
    {
        public Customer(string document, string name)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
        public string Document { get; }

        public bool Equals(Customer other) => string.Equals(Name, other.Name) && string.Equals(Document, other.Document);

        public override bool Equals(object obj) => obj is Customer other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Document != null ? Document.GetHashCode() : 0);
            }
        }

        public override string ToString() => $"{Document}-{Name}";
    }
}