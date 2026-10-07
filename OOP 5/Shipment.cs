using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    public abstract partial class Shipment
    {
        private static int _totalShipmentsCreated = 0;
        internal string _trackingCode;
        internal string _description;
        internal double _weight;
        internal double _deliveryFee;
        public string TrackingStatus { get; set; }
        public DeliveryAddress destination { get; set; }

        static Shipment()
        {
            _totalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }
        public string TrackingCode
        {
            get { return _trackingCode; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _trackingCode = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _description = value;
            }
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }

        public double DeliveryFee
        {
            get { return _deliveryFee; }
            protected set
            {
                if (value > 0)
                    _deliveryFee = value;
            }
        }

        

        public abstract double EstimatedCost { get; }
        public Shipment(string trackingCode)
        {
            this.TrackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            destination = new DeliveryAddress("Unknown", "Unknown", 0);
            _totalShipmentsCreated++;
        }
        public Shipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress Destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            destination = Destination;
            _totalShipmentsCreated++;
        }
        public void UpdateDeliveryFee(double newFee)
        {
            if (newFee > 0)
                DeliveryFee = (double)newFee;
        }
        public void UpdateWeight(double newWeight)
        {
            if (newWeight > 0)
                Weight = newWeight;
        }
        public void UpdateWeight(double newWeight, double packingWeight)
        {
            if (newWeight > 0 && packingWeight > 0)
                Weight = newWeight + packingWeight;
        }
        public static int GetTotalShipmentsCreated()
        {
            return _totalShipmentsCreated;
        }
        public abstract void PrintShipment();

        public Shipment CopyShipment()
        {
            return this;
        }
        public Shipment ShallowCopy()
        {
            return (Shipment)MemberwiseClone();
        }
        public Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(
                this.destination.City,
                this.destination.Street,
                this.destination.BuildingNumber
            );
            Shipment deepCopy = (Shipment)this.MemberwiseClone();
            deepCopy.destination = newAddress;

            return deepCopy;
        }
    }
}
