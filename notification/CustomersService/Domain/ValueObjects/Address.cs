using System;
using Newtonsoft.Json;

namespace CustomersService.Domain.ValueObjects
{
    public class Address : IEquatable<Address>
    {
        [JsonConstructor]
        public Address(string zipCode, string streetName, string buildNumber, string district, string complement, string city, string state, string country, bool isShippingAddress = false)
        {
            ZipCode = zipCode ?? throw new ArgumentNullException(nameof(zipCode));
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            BuildNumber = buildNumber ?? throw new ArgumentNullException(nameof(buildNumber));
            District = district ?? throw new ArgumentNullException(nameof(district));
            Complement = complement;

            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            IsShippingAddress = isShippingAddress;
        }

        public string ZipCode { get; }
        public string StreetName { get; }
        public string BuildNumber { get; }
        public string District { get; }
        public string Complement { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public bool IsShippingAddress { get; }
        

        public string ToJson() => JsonConvert.SerializeObject(this);

        public bool Equals(Address other)
        {
            if (ReferenceEquals(null, other)) { return false; }

            if (ReferenceEquals(this, other)) { return true; }

            return string.Equals(ZipCode, other.ZipCode) 
                   && string.Equals(StreetName, other.StreetName) 
                   && string.Equals(BuildNumber, other.BuildNumber) 
                   && string.Equals(District, other.District)
                   && string.Equals(Complement, other.Complement) 
                   && string.Equals(City, other.City) 
                   && string.Equals(State, other.State) 
                   && string.Equals(Country, other.Country);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }

            if (ReferenceEquals(this, obj)) { return true; }

            return obj.GetType() == GetType() && Equals((Address)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ZipCode != null ? ZipCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StreetName != null ? StreetName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BuildNumber != null ? BuildNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (District != null ? District.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Complement != null ? Complement.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}