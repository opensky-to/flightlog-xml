// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Flight log handling.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public partial class FlightLog
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// The flight log file version.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        private const string FlightLogFileVersion = "1.0";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates a flight log.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The flight log.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GenerateFlightLog()
        {
            Debug.WriteLine("Generating flight log XML file...");
            var log = new XElement("OpenSky.FlightLog");
            log.Add(new XElement("LogVersion", FlightLogFileVersion));

            // Add some basic info about this log
            log.Add(new XElement("Agent", this.Agent));
            log.Add(new XElement("AgentVersion", this.AgentVersion));
            log.Add(new XElement("OpenSkyUser", this.OpenSkyUser));
            log.Add(new XElement("LocalTimeZone", $"{this.LocalTimeZone}"));
            log.Add(new XElement("TrackingStarted", $"{this.TrackingStarted:O}"));
            log.Add(new XElement("TrackingStopped", $"{this.TrackingStopped:O}"));
            log.Add(new XElement("WasAirborne", this.WasAirborne));
            log.Add(new XElement("WarpTimeSaved", $"{this.TimeSavedBecauseOfSimRate:c}"));
            log.Add(new XElement("TotalPaused", $"{this.TotalPaused:c}"));

            // Add flight basics
            var flightElement = new XElement("Flight");
            log.Add(flightElement);
            flightElement.Add(new XElement("ID", $"{this.FlightID}"));
            flightElement.Add(new XElement("PlaneRegistry", $"{this.AircraftRegistry}"));
            flightElement.Add(new XElement("UtcOffset", $"{this.UtcOffset:F1}"));

            flightElement.Add(this.Origin.GetXMLElement("Origin"));
            flightElement.Add(this.Destination.GetXMLElement("Destination"));
            flightElement.Add(this.Alternate.GetXMLElement("Alternate"));

            flightElement.Add(new XElement("FuelGallons", $"{this.FuelGallons:F2}"));
            flightElement.Add(new XElement("Payload", this.Payload));
            flightElement.Add(new XElement("PayloadPounds", $"{this.PayloadPounds:F2}"));

            // Add flight events
            var eventLog = new XElement("EventLog");
            log.Add(eventLog);
            foreach (var entry in this.TrackingEventLogEntries)
            {
                eventLog.Add(entry.GetXMLElement());
            }

            // Add tracking map markers
            var trackingMapMarkers = new XElement("EventMapMarkers");
            log.Add(trackingMapMarkers);
            foreach (var markerXML in this.TrackingEventMarkers.Select(marker => marker.GetXMLElement()).Where(markerXML => markerXML != null))
            {
                trackingMapMarkers.Add(markerXML);
            }

            // Add flight position reports
            var positionReports = new XElement("PositionReports");
            log.Add(positionReports);
            foreach (var position in this.PositionReports)
            {
                positionReports.Add(position.GetXMLElement());
            }

            // Add landing report
            var landingReport = new XElement("LandingReport");
            log.Add(landingReport);
            foreach (var touchDown in this.TouchDowns)
            {
                landingReport.Add(touchDown);
            }

            // Add nav log waypoints
            var navLogWaypoints = new XElement("NavLogWaypoints");
            log.Add(navLogWaypoints);
            foreach (var waypoint in this.NavLogWaypoints)
            {
                navLogWaypoints.Add(waypoint);
            }

            return log;
        }


    }
}