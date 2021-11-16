// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackingEventLogEntry.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// OpenSky tracking event.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class TrackingEventLogEntry
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackingEventLogEntry"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        public TrackingEventLogEntry()
        {
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackingEventLogEntry"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <param name="log">
        /// The log entry XML element.
        /// </param>
        /// -------------------------------------------------------------------------------------------------
        public TrackingEventLogEntry(XElement log)
        {
            this.EventType = (FlightTrackingEventType)int.Parse(log.EnsureChildElement("Type").Value);
            this.EventTime= DateTime.ParseExact(log.EnsureChildElement("Time").Value, "O", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            this.Latitude = double.Parse(log.EnsureChildElement("Lat").Value);
            this.Longitude = double.Parse(log.EnsureChildElement("Lon").Value);
            this.Altitude = int.Parse(log.EnsureChildElement("Alt").Value);
            this.EventColor = Color.FromArgb(int.Parse(log.EnsureChildElement("Color").Value));
            this.LogMessage = log.EnsureChildElement("Message").Value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public int Altitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the color of the event.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public Color EventColor { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the date/time of the event.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public DateTime EventTime { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public FlightTrackingEventType EventType { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Latitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the log message for the flight events log.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string LogMessage { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Longitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the log entry XElement for the flight log XML file.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The log entry.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GetXMLElement()
        {
            var log = new XElement("LogEntry");
            log.SetAttributeValue("Type", $"{(int)this.EventType}");
            log.SetAttributeValue("Time", $"{this.EventTime:O}");
            log.SetAttributeValue("Lat", $"{this.Latitude}");
            log.SetAttributeValue("Lon", $"{this.Longitude}");
            log.SetAttributeValue("Alt", $"{this.Altitude}");
            log.SetAttributeValue("Color", $"{this.EventColor.ToArgb()}");
            log.SetAttributeValue("Message", $"{this.LogMessage}");
            return log;
        }
    }
}