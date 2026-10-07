namespace OOP_5.Extensions
{
    public static class ShipmentExtension
    {
        public static void UpdateTrackingStatus(this Shipment shipment, string status)
        {
            shipment.TrackingStatus = status;

            Console.WriteLine($"Shipment {shipment.TrackingCode} status updated to: {status}");
        }
    }
}
