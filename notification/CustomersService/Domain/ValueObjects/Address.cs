using System;

namespace CustomersService.Domain.ValueObjects
{
    public struct Address : IEquatable<Address>
    {
        public Address(string zipCode, string streetName, string buildNumber, string district, string complement, string city, string state, string country)
        {
            ZipCode = zipCode;
            StreetName = streetName;
            BuildNumber = buildNumber;
            District = district;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
        }

        public string ZipCode { get; }
        public string StreetName { get; }
        public string BuildNumber { get; }
        public string District { get; }
        public string Complement { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }

        public bool Equals(Address other) 
            => string.Equals(StreetName, other.StreetName) 
               && string.Equals(BuildNumber, other.BuildNumber) 
               && string.Equals(District, other.District) 
               && string.Equals(Complement, other.Complement) 
               && string.Equals(City, other.City) 
               && string.Equals(State, other.State) 
               && string.Equals(Country, other.Country) 
               && string.Equals(ZipCode, other.ZipCode);

        public override bool Equals(object obj) => obj is Address other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (StreetName != null ? StreetName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BuildNumber != null ? BuildNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (District != null ? District.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Complement != null ? Complement.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ZipCode != null ? ZipCode.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}