using System;
using System.Collections.Generic;


namespace EventSenderFuncApp.Shared.SeedData
{
    public static class CustomerTypeSD
    {
        public static readonly List<string> CustomerTypes = new List<string>()
        {
            "Individual Customers", // regular consumers who make purchases for personal use.
            "Loyal Customers", //  regularly make repeat purchases
            "High-Value Customers", // spend a significant amount of money on products 
            "Low-Value Customers", // make smaller or infrequent purchases
            "Tech-Savvy Customers", // technologically inclined and comfortable using digital platforms 
            "International Customers" // located in different countries 
        };

        public static string GetCustomerType()
        {
            var random = new Random();
            int index = random.Next(CustomerTypes.Count);
            return CustomerTypes[index];
        }
    }
}
