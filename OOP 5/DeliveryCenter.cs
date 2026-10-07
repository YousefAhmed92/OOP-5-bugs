using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    internal class DeliveryCenter
    {
        private Shipment[] shipments;
        private string _driverName;
        public string DriverName
        {
            get { return _driverName; }
            set { _driverName = value; }
        }

        public DeliveryCenter()
        {
            shipments = new Shipment[10];
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                    return shipments[index];

                return default;
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                    shipments[index] = value;
            }
        }
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                        return shipments[i];
                }
                return default;
            }
        }
        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    shipments[i] = null;
                    return true;
                }
            }
            return false;
        }
        public void PrintAllShipments()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Driver : {DriverName}");

            foreach (Shipment s in shipments)
            {
                if (s != null)
                {
                    s.PrintShipment();
                }
            }
            Console.WriteLine("==========================================");
        }
        public void PrintTrackingStatuses()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("Tracking Status");
            Console.WriteLine("==========================================");

            foreach (Shipment s in shipments)
            {
                if (s != null && s is ITrackable trackable)
                {
                    Console.WriteLine(trackable.GetTrackingStatus());
                }
            }
            Console.WriteLine("==========================================");
        }

        public void PrintInsuranceCosts()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("Insurance");
            Console.WriteLine("==========================================");

            foreach (Shipment s in shipments)
            {
                if (s != null && s is IInsurable insurable)
                {
                    decimal insurance = insurable.CalculateInsurance();
                    string shipmentType = s.GetType().Name;
                    Console.WriteLine($"{shipmentType} Insurance : {insurance:F2} EGP");
                }
            }
            Console.WriteLine("==========================================");

        }
    }
}
