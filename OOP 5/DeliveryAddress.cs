using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    public struct DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;
        public DeliveryAddress(string City, string Street, int BuildingNumber)
        {
            this.City = City;
            this.Street = Street;
            this.BuildingNumber = BuildingNumber;
        }
        public string GetFullAddress()
        {
            return $"The address {City}, {Street}, {BuildingNumber}";
        }
    }
}