using System;
using Newtonsoft.Json;

namespace CustomersService.Domain.Entities
{
    public class Email : IEquatable<Email>
    {
        public Email(string address, bool validated = false)
        {
            Address = address;
            Validated = validated;
        }

        public string Address { get; }
        public bool Validated { get; }

        public override string ToString() => Address;

        public bool Equals(Email other)
        {
            if (ReferenceEquals(null, other)) { return false; }

            if (ReferenceEquals(this, other)) { return true; }

            return string.Equals(Address, other.Address);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {  return false; }
            if (ReferenceEquals(this, obj)) { return true; }

            return obj.GetType() == GetType() && Equals((Email) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0) * 397) ^ Validated.GetHashCode();
            }
        }

        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}