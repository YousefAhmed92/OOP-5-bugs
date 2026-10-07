using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    internal class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        private string _destinationCountry;
        private double _customsFee;
        public string DestinationCountry
        {
            get { return _destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _destinationCountry = value;
            }
        }
        public double CustomsFee
        {
            get { return _customsFee; }
            set
            {
                if (value >= 0)
                    _customsFee = value;
            }
        }
        public InternationalShipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress destination, string destinationCountry, double customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public override double EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + CustomsFee; }
        }
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"\nCustoms Report for {TrackingCode}");
            Console.WriteLine($"Destination: {DestinationCountry}");
            Console.WriteLine($"Weight: {Weight} KG");
            Console.WriteLine($"Customs Fee: {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
        public override void PrintShipment()
        {
            Console.WriteLine("\nInternational Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Weight : {Weight} KG");
            Console.WriteLine($"Delivery Fee : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost : {EstimatedCost} EGP");
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been Delivered.";
        }

        public decimal CalculateInsurance()
        {
            return (decimal)EstimatedCost * 0.12m;
        }
    }
}
