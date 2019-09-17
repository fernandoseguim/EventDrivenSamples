using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace CustomersService.Infra.Repositories.CustomerContext
{
    [DynamoDBTable("Customers")]
    public class CustomerData
    {
        public CustomerData()
        {
            Emails = new List<string>();
            ShippingAddresses = new List<string>();
        }

        [DynamoDBHashKey] public string DocumentNumber { get; set; }

        public string Name { get; set; }
        public List<string> Emails { get; set; }
        public string BillingAddresses { get; set; }
        public List<string> ShippingAddresses { get; set; }
        
        [DynamoDBVersion] public int? Version { get; set; }
    }
}
