using System;

namespace CustomersService.Domain.ValueObjects
{
    public struct Document : IEquatable<Document>
    {
        public Document(string number, DocumentType type)
        {
            Number = number ?? throw new ArgumentNullException(nameof(number));
            Type = type;
        }

        public string Number { get; }
        public DocumentType Type { get; }

        public override string ToString() => Number;

        public bool Equals(Document other) => string.Equals(Number, other.Number) && Type == other.Type;

        public override bool Equals(object obj) => obj is Document other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Number != null ? Number.GetHashCode() : 0) * 397) ^ (int) Type;
            }
        }
    }
}