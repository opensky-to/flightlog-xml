// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionReport.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Position report.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class PositionReport
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the true airspeed.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Airspeed { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public int Altitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the fuel on board in gallons.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double FuelOnBoard { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the ground speed.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Groundspeed { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Heading { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Latitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Longitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the plane is on the ground.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool OnGround { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the radio altitude (AGL).
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double RadioAlt { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the simulation rate.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double SimulationRate { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the time of day.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public TimeOfDay TimeOfDay { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the timestamp of the location.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public DateTime Timestamp { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the position report XElement for the flight log XML file.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The position report.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GetXMLElement()
        {
            var position = new XElement("Position");
            position.SetAttributeValue("Timestamp", $"{this.Timestamp:O}");
            position.SetAttributeValue("Lat", $"{this.Latitude}");
            position.SetAttributeValue("Lon", $"{this.Longitude}");
            position.SetAttributeValue("Alt", $"{this.Altitude}");
            position.SetAttributeValue("Airspeed", $"{this.Airspeed:F0}");
            position.SetAttributeValue("Groundspeed", $"{this.Groundspeed:F0}");
            position.SetAttributeValue("OnGround", $"{this.OnGround}");
            position.SetAttributeValue("RadioAlt", $"{this.RadioAlt:F0}");
            position.SetAttributeValue("Heading", $"{this.Heading:F0}");
            position.SetAttributeValue("FuelOnBoard", $"{this.FuelOnBoard:F2}");
            position.SetAttributeValue("SimulationRate", $"{this.SimulationRate:F1}");
            position.SetAttributeValue("TimeOfDay", $"{this.TimeOfDay}");
            return position;
        }
    }
}