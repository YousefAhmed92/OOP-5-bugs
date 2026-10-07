using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    public abstract partial class Shipmentt
    {
        private string _trackingStatus = "In Transit";
        public string TrackingStatus
        {
            get { return _trackingStatus; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _trackingStatus = value;
            }
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            if (!string.IsNullOrWhiteSpace(newStatus))
            {
                TrackingStatus = newStatus;
                OnTrackingStatusChanged(newStatus);
            }
        }

        partial void OnTrackingStatusChanged(string newStatus);
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }
    }
}
