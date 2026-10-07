using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP_5
{
    internal static class ShipmentExtentions
    {
        public static string GetSummary(this Shipment shipment)
        {
            if (shipment == null)
                return "Invalid Shipment";

            string shipmentType = shipment.GetType().Name;
            return $"{shipment.TrackingCode} | {shipmentType} | {shipment.Weight} KG | {shipment.TrackingStatus}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment == null)
                return false;

            return shipment.TrackingStatus == "Delivered";
        }
    }
}
