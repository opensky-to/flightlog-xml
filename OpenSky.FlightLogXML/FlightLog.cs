// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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
        /// Initializes a new instance of the <see cref="FlightLog"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        public FlightLog()
        {
            this.NavLogWaypoints = new List<Waypoint>();
            this.PositionReports = new List<PositionReport>();
            this.TouchDowns = new List<TouchDown>();
            this.TrackingEventLogEntries = new List<TrackingEventLogEntry>();
            this.TrackingEventMarkers = new List<TrackingEventMarker>();

            this.Origin = new FlightLogAirport();
            this.Destination = new FlightLogAirport();
            this.Alternate = new FlightLogAirport();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the flight log XML elements.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The flight log XML root element.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GenerateFlightLog()
        {
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
            flightElement.Add(new XElement("AircraftRegistry", $"{this.AircraftRegistry}"));
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
                landingReport.Add(touchDown.GetXMLElement());
            }

            // Add nav log waypoints
            var navLogWaypoints = new XElement("NavLogWaypoints");
            log.Add(navLogWaypoints);
            foreach (var waypoint in this.NavLogWaypoints)
            {
                navLogWaypoints.Add(waypoint.GetXMLElement());
            }

            return log;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Restore the flight log from XML.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <param name="log">
        /// The log root XML element.
        /// </param>
        /// -------------------------------------------------------------------------------------------------
        public void RestoreFlightLog(XElement log)
        {
            var logVersion = log.EnsureChildElement("LogVersion").Value;
            if (logVersion != FlightLogFileVersion)
            {
                throw new Exception("This flight log is using an unsupported version number!");
            }

            // Restore flight log basics
            this.Agent = log.EnsureChildElement("Agent").Value;
            this.AgentVersion = log.EnsureChildElement("AgentVersion").Value;
            this.OpenSkyUser = log.EnsureChildElement("OpenSkyUser").Value;
            this.LocalTimeZone = double.Parse(log.EnsureChildElement("LocalTimeZone").Value);
            this.TrackingStarted = DateTime.ParseExact(log.EnsureChildElement("TrackingStarted").Value, "O", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            this.TrackingStopped = DateTime.ParseExact(log.EnsureChildElement("TrackingStopped").Value, "O", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            this.WasAirborne = bool.Parse(log.EnsureChildElement("WasAirborne").Value);
            this.TimeSavedBecauseOfSimRate = TimeSpan.Parse(log.EnsureChildElement("WarpTimeSaved").Value);
            this.TotalPaused = TimeSpan.Parse(log.EnsureChildElement("TotalPaused").Value);

            // Restore flight basics
            var flight = log.EnsureChildElement("Flight");
            this.FlightID = Guid.Parse(flight.EnsureChildElement("ID").Value);
            this.AircraftRegistry = flight.EnsureChildElement("AircraftRegistry").Value;
            this.UtcOffset = double.Parse(flight.EnsureChildElement("UtcOffset").Value);

            this.Origin = new FlightLogAirport(flight.EnsureChildElement("Origin"));
            this.Destination = new FlightLogAirport(flight.EnsureChildElement("Destination"));
            this.Alternate = new FlightLogAirport(flight.EnsureChildElement("Alternate"));

            this.FuelGallons = double.Parse(flight.EnsureChildElement("FuelGallons").Value);
            this.Payload = flight.EnsureChildElement("Payload").Value;
            this.PayloadPounds = double.Parse(flight.EnsureChildElement("PayloadPounds").Value);

            // Restore flight events
            var eventLog = log.EnsureChildElement("EventLog");
            this.TrackingEventLogEntries.AddRange(eventLog.Elements("LogEntry").Select(e => new TrackingEventLogEntry(e)));

            // Restore tacking map markers
            var trackingMapMarkers = log.EnsureChildElement("EventMapMarkers");
            this.TrackingEventMarkers.AddRange(trackingMapMarkers.Elements("Marker").Select(e => new TrackingEventMarker(e)));

            // Restore flight position reports
            var positionReports = log.EnsureChildElement("PositionReports");
            this.PositionReports.AddRange(positionReports.Elements("Position").Select(p => new PositionReport(p)));

            // Restore landing report
            var landingReport = log.EnsureChildElement("LandingReport");
            this.TouchDowns.AddRange(landingReport.Elements("Touchdown").Select(t => new TouchDown(t)));

            // Restore nav log waypoints
            var navLogWaypoints = log.EnsureChildElement("NavLogWaypoints");
            this.NavLogWaypoints.AddRange(navLogWaypoints.Elements("Waypoint").Select(w => new Waypoint(w)));
        }
    }
}