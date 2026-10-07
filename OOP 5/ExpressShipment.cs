using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    internal class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        private double _extraFee;
        public double ExtraFee
        {
            get { return _extraFee; }
            set
            {
                if (value >= 0)
                    _extraFee = value;
            }
        }
        public ExpressShipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress destination, double _extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = _extraFee;
        }

        public override double EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + ExtraFee; }
        }
        public override void PrintShipment()
        {
            Console.WriteLine("\nExpress Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Weight : {Weight} KG");
            Console.WriteLine($"Delivery Fee : {DeliveryFee} EGP");
            Console.WriteLine($"Extra Fee : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Out for Delivery";
        }
        public decimal CalculateInsurance()
        {
            return (decimal)EstimatedCost * 0.08m;
        }


    }
}
