// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TouchDown.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Touchdown.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class TouchDown
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the airspeed.
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
        /// Gets or sets the bank angle.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double BankAngle { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the cross wind.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double CrossWind { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the G-force.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double GForce { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the ground speed.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double GroundSpeed { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the head wind.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double HeadWind { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the landing rate.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double LandingRate { get; set; }

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
        /// Gets or sets the side slip angle.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double SideSlipAngle { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the timestamp of the landing.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public DateTime Timestamp { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the wind angle in degrees.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double WindAngle => Math.Atan2(this.CrossWind, this.HeadWind) * 180.0 / Math.PI;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the wind in knots (direction in WindAngle!).
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double WindKnots => Math.Sqrt(Math.Pow(this.CrossWind, 2) + Math.Pow(this.HeadWind, 2));

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the touchdown XElement for the flight log XML file.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The touchdown.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GetXMLElement()
        {
            var touchdown = new XElement("Touchdown");
            touchdown.SetAttributeValue("Timestamp", $"{this.Timestamp:O}");
            touchdown.SetAttributeValue("Lat", $"{this.Latitude}");
            touchdown.SetAttributeValue("Lon", $"{this.Longitude}");
            touchdown.SetAttributeValue("Alt", $"{this.Altitude}");
            touchdown.SetAttributeValue("LandingRate", $"{this.LandingRate:F0}");
            touchdown.SetAttributeValue("GForce", $"{this.GForce:F2}");
            touchdown.SetAttributeValue("SideSlipAngle", $"{this.SideSlipAngle:F2}");
            touchdown.SetAttributeValue("HeadWind", $"{this.HeadWind:F2}");
            touchdown.SetAttributeValue("CrossWind", $"{this.CrossWind:F2}");
            touchdown.SetAttributeValue("BankAngle", $"{this.CrossWind:F2}");
            touchdown.SetAttributeValue("GroundSpeed", $"{this.GroundSpeed:F0}");
            touchdown.SetAttributeValue("Airspeed", $"{this.Airspeed:F0}");
            return touchdown;
        }
    }
}