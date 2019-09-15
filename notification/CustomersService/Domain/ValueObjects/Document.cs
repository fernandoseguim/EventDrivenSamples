using System;

namespace CustomersService.Domain.ValueObjects
{
    public struct Document
    {
        public Document(string number, DocumentType type)
        {
            Number = number ?? throw new ArgumentNullException(nameof(number));
            Type = type;
        }

        public string Number { get; }
        public DocumentType Type { get; }

        public override string ToString() => Number;
    }
}