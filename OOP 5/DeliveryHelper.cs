using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    public static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            if (shipment != null)
            {
                shipment.PrintShipment();
                Console.WriteLine();
            }
        }
    }
}
