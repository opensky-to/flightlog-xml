// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionReport.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Globalization;
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
        /// Initializes a new instance of the <see cref="PositionReport"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        public PositionReport()
        {
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionReport"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <param name="position">
        /// The position report XML element.
        /// </param>
        /// -------------------------------------------------------------------------------------------------
        public PositionReport(XElement position)
        {
            this.Timestamp= DateTime.ParseExact(position.EnsureChildElement("Timestamp").Value, "O", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            this.Latitude = double.Parse(position.EnsureChildElement("Lat").Value);
            this.Longitude = double.Parse(position.EnsureChildElement("Lon").Value);
            this.Altitude = int.Parse(position.EnsureChildElement("Alt").Value);
            this.Airspeed = double.Parse(position.EnsureChildElement("AS").Value);
            this.Groundspeed = double.Parse(position.EnsureChildElement("GS").Value);
            this.OnGround = bool.Parse(position.EnsureChildElement("Ground").Value);
            this.RadioAlt = double.Parse(position.EnsureChildElement("RadAlt").Value);
            this.Heading = double.Parse(position.EnsureChildElement("Hdg").Value);
            this.FuelOnBoard = double.Parse(position.EnsureChildElement("Fuel").Value);
            this.SimulationRate = double.Parse(position.EnsureChildElement("SimR").Value);
            this.TimeOfDay = (TimeOfDay)int.Parse(position.EnsureChildElement("TOD").Value);
        }

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
            position.SetAttributeValue("AS", $"{this.Airspeed:F0}");
            position.SetAttributeValue("GS", $"{this.Groundspeed:F0}");
            position.SetAttributeValue("Ground", $"{this.OnGround}");
            position.SetAttributeValue("RadAlt", $"{this.RadioAlt:F0}");
            position.SetAttributeValue("Hdg", $"{this.Heading:F0}");
            position.SetAttributeValue("Fuel", $"{this.FuelOnBoard:F2}");
            position.SetAttributeValue("SimR", $"{this.SimulationRate:F1}");
            position.SetAttributeValue("TOD", $"{(int)this.TimeOfDay}");
            return position;
        }
    }
}